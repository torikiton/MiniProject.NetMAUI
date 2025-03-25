using System.Collections.ObjectModel;
using System.Text.Json;
using Newtonsoft.Json;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniProject.Pages;
using MiniProject.Model;

using MiniProjectSubject.Model;
using RegisteredSubject.Model;

namespace MiniProject.ViewModel;

public partial class RegisterViewModel : ObservableObject
{
    // อ็อบเซอร์วะเบิลพรอพเพอร์ตี้สำหรับเก็บข้อมูลวิชาทั้งหมด
    [ObservableProperty]
    ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
    
    // อ็อบเซอร์วะเบิลพรอพเพอร์ตี้สำหรับเก็บข้อมูลวิชาที่กรองแล้ว (จากการค้นหา)
    [ObservableProperty]
    ObservableCollection<Subject> filteredSubjects = new ObservableCollection<Subject>();
    
    // อ็อบเซอร์วะเบิลพรอพเพอร์ตี้สำหรับเก็บข้อมูลวิชาที่เลือก
    [ObservableProperty]
    ObservableCollection<Subject> selectedSubjects = new ObservableCollection<Subject>();
    
    // อ็อบเซอร์วะเบิลพรอพเพอร์ตี้สำหรับเก็บข้อความที่ใช้ค้นหา
    [ObservableProperty]
    string searchText = string.Empty;
    
    // อ่านข้อมูลวิชาจากไฟล์ JSON
    async Task<List<Subject>> ReadJsonAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("subjects.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            List<Subject> subjectList = Subject.FromJson(contents);
            return subjectList;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return new List<Subject>();
        }
    }
    
    // คอนสตรัคเตอร์
    public RegisterViewModel()
    {
        LoadSubjects();
    }
    
    // โหลดข้อมูลวิชาทั้งหมด
    private async void LoadSubjects()
    {
        var subjectList = await ReadJsonAsync();
        if (subjectList != null && subjectList.Count > 0)
        {
            foreach (var subject in subjectList)
            {
                Subjects.Add(subject);
            }
            
            // เริ่มต้นให้แสดงวิชาทั้งหมด
            FilteredSubjects.Clear();
            foreach (var subject in Subjects)
            {
                FilteredSubjects.Add(subject);
            }
        }
        else
        {
            // ถ้าไม่มีข้อมูลจากไฟล์ JSON ให้เพิ่มข้อมูลตัวอย่าง
            var sampleSubjects = new List<Subject>
            {
                new Subject { CourseCode = 1234L, SubjectName = "เขียนโปรแกรม", Credit = 3, Year = 2566, Term = 1 },
                new Subject { CourseCode = 1111L, SubjectName = "โครงสร้างข้อมูล", Credit = 3, Year = 2566, Term = 1 },
                new Subject { CourseCode = 123123L, SubjectName = "คณิตศาสตร์วิศวกรรม", Credit = 4, Year = 2566, Term = 1 },
                new Subject { CourseCode = 44232L, SubjectName = "ภาษาอังกฤษเพื่อการสื่อสาร", Credit = 3, Year = 2566, Term = 1 },
                new Subject { CourseCode = 234532L, SubjectName = "ฟิสิกส์วิศวกรรม", Credit = 4, Year = 2566, Term = 1 }
            };
            
            foreach (var subject in sampleSubjects)
            {
                Subjects.Add(subject);
                FilteredSubjects.Add(subject);
            }
        }
    }
    
    // คำสั่งสำหรับเพิ่มวิชาที่เลือกลงในรายการที่เลือก
    [RelayCommand]
    private void AddSubject(Subject subject)
    {
        // ตรวจสอบว่าวิชานี้ถูกเลือกไปแล้วหรือยัง
        var existingSubject = SelectedSubjects.FirstOrDefault(s => s.CourseCode == subject.CourseCode);
        if (existingSubject == null)
        {
            SelectedSubjects.Add(subject);
        }
    }
    
    // คำสั่งสำหรับลบวิชาที่เลือกออกจากรายการที่เลือก
    [RelayCommand]
    private void RemoveSubject(Subject subject)
    {
        if (subject != null)
        {
            SelectedSubjects.Remove(subject);
        }
    }
    
    // คำสั่งสำหรับค้นหาวิชา
    [RelayCommand]
    private void Search()
    {
        FilteredSubjects.Clear();
        
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            // ถ้าไม่มีข้อความค้นหา ให้แสดงวิชาทั้งหมด
            foreach (var subject in Subjects)
            {
                FilteredSubjects.Add(subject);
            }
        }
        else
        {
            // ถ้ามีข้อความค้นหา ให้กรองวิชาตามรหัสวิชาหรือชื่อวิชา
            var searchResults = Subjects.Where(s => 
                s.CourseCode.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase) || 
                s.SubjectName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            
            foreach (var subject in searchResults)
            {
                FilteredSubjects.Add(subject);
            }
        }
    }
    
    // คำสั่งสำหรับล้างรายการวิชาที่เลือก
    [RelayCommand]
    private void ClearSelectedSubjects()
    {
        SelectedSubjects.Clear();
    }
    
    // คำสั่งสำหรับยืนยันการลงทะเบียน
    // Add these methods to your existing RegisterViewModel.cs

[RelayCommand]
private async Task ConfirmRegistration()
{
    if (SelectedSubjects.Count == 0)
    {
        await Application.Current.MainPage.DisplayAlert("แจ้งเตือน", "กรุณาเลือกรายวิชาที่ต้องการลงทะเบียน", "ตกลง");
        return;
    }
    
    // คำนวณหน่วยกิตรวม
    int totalCredits = (int)SelectedSubjects.Sum(s => s.Credit);
    
    bool confirmed = await Application.Current.MainPage.DisplayAlert("ยืนยันการลงทะเบียน", 
        $"คุณต้องการลงทะเบียนเรียน {SelectedSubjects.Count} วิชา รวม {totalCredits} หน่วยกิต ใช่หรือไม่?", 
        "ยืนยัน", "ยกเลิก");
    
    if (confirmed)
    {
        // บันทึกข้อมูลการลงทะเบียน (จำลอง)
        // ในโปรแกรมจริงควรบันทึกลงฐานข้อมูล
        // แต่ในตัวอย่างนี้เราจะบันทึกลงใน Preferences เพื่อจำลองการทำงาน
        SaveRegisteredSubjects();
        
        await Application.Current.MainPage.DisplayAlert("สำเร็จ", 
            "ลงทะเบียนเรียนเรียบร้อยแล้ว", "ตกลง");
        
        // หลังจากลงทะเบียนสำเร็จ ล้างข้อมูลวิชาที่เลือก
        SelectedSubjects.Clear();
        
        // ไปที่หน้าประวัติการลงทะเบียน
        await Shell.Current.GoToAsync(nameof(RegistrationHistory));
    }
}

private void SaveRegisteredSubjects()
{
    // ในโปรแกรมจริงควรจะบันทึกลงฐานข้อมูล
    // แต่ในตัวอย่างนี้เราจะจำลองการบันทึกโดยบันทึกลงใน Preferences
    
    // อ่านข้อมูลการลงทะเบียนที่มีอยู่ (ถ้ามี)
    var json = Preferences.Get("RegisteredSubjects", string.Empty);
    var registeredSubjects = string.IsNullOrEmpty(json) 
        ? new List<RegisteredSubject.Model.RegisteredSubject>() 
        : System.Text.Json.JsonSerializer.Deserialize<List<RegisteredSubject.Model.RegisteredSubject>>(json);
    
    // เพิ่มรายวิชาที่ลงทะเบียนใหม่
    foreach (var subject in SelectedSubjects)
    {
        var newRegistration = new RegisteredSubject.Model.RegisteredSubject
        {
            CourseCode = subject.CourseCode,
            SubjectName = subject.SubjectName,
            Credit = (int)subject.Credit,
            Year = 2566, // ค่าคงที่ในตัวอย่าง (ในระบบจริงควรใช้ค่าจากระบบ)
            Term = 1, // ค่าคงที่ในตัวอย่าง (ในระบบจริงควรใช้ค่าจากระบบ)
            RegistrationDate = DateTime.Now.ToString("dd/MM/yyyy"),
            Status = "Active",
            CanWithdraw = true
        };
        
        registeredSubjects.Add(newRegistration);
    }
    
    // บันทึกข้อมูลกลับไป
    var updatedJson = System.Text.Json.JsonSerializer.Serialize(registeredSubjects);
    Preferences.Set("RegisteredSubjects", updatedJson);
}
    
}