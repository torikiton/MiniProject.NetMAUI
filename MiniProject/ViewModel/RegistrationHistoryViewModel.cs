using System.Collections.ObjectModel;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics; // ใช้ Debug.WriteLine แทน Console.WriteLine
using RegisteredSubject.Model;

namespace MiniProject.ViewModel;

public partial class RegistrationHistoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<RegisteredSubject.Model.RegisteredSubject> registeredSubjects = new();

    [ObservableProperty]
    private ObservableCollection<string> termOptions = new();

    private string _selectedTerm;
    public string SelectedTerm
    {
        get => _selectedTerm;
        set
        {
            if (SetProperty(ref _selectedTerm, value))
            {
                Debug.WriteLine($"SelectedTerm changed to: {value}");
                OnPropertyChanged(nameof(SelectedTerm)); // เพิ่มการเรียก OnPropertyChanged ที่นี่
                
                if (!string.IsNullOrEmpty(value))
                {
                    LoadRegisteredSubjects();
                }
            }
        }
    }

    [ObservableProperty]
    private string termDisplayText = "ภาคเรียนปัจจุบัน";

    [ObservableProperty]
    private string totalCreditsText = "จำนวนหน่วยกิตรวม: 0";

    private int currentYear = 2566;
    private int currentTerm = 1;
    private Dictionary<string, List<RegisteredSubject.Model.RegisteredSubject>> mockRegistrationData = new();

    public RegistrationHistoryViewModel()
    {
        Debug.WriteLine("RegistrationHistoryViewModel constructor called");
        InitializeMockData();
        LoadTermOptions();
    }
    
    private void InitializeMockData()
    {
        // ข้อมูลจำลองเทอมปัจจุบัน
        mockRegistrationData.Add($"{currentYear}/{currentTerm}", new List<RegisteredSubject.Model.RegisteredSubject>
        {
            new RegisteredSubject.Model.RegisteredSubject
            { 
                CourseCode = 1234L, 
                SubjectName = "เขียนโปรแกรม", 
                Credit = 3, 
                Year = currentYear, 
                Term = currentTerm, 
                RegistrationDate = "01/02/2566", 
                Status = "Active",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 1111L, 
                SubjectName = "โครงสร้างข้อมูล", 
                Credit = 3, 
                Year = currentYear, 
                Term = currentTerm, 
                RegistrationDate = "01/02/2566", 
                Status = "Active",
                CanWithdraw = true
            },new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 3333L, 
                SubjectName = "คณิตศาสตร์วิศวกรรม 1", 
                Credit = 3, 
                Year = currentYear, 
                Term = 2, 
                RegistrationDate = "01/09/2566", 
                Status = "Active",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 4444L, 
                SubjectName = "ฟิสิกส์วิศวกรรม 1", 
                Credit = 3, 
                Year = currentYear, 
                Term = 2, 
                RegistrationDate = "01/09/2566", 
                Status = "Active",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 5555L, 
                SubjectName = "ภาษาอังกฤษพื้นฐาน", 
                Credit = 3, 
                Year = currentYear, 
                Term = 2, 
                RegistrationDate = "01/09/2566", 
                Status = "Active",
                CanWithdraw = true
            }
        });
        
        // ข้อมูลจำลองเทอมที่แล้ว
        mockRegistrationData.Add($"{currentYear-1}/{2}", new List<RegisteredSubject.Model.RegisteredSubject>
        {
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 3333L, 
                SubjectName = "คณิตศาสตร์วิศวกรรม 1", 
                Credit = 3, 
                Year = currentYear-1, 
                Term = 2, 
                RegistrationDate = "01/09/2565", 
                Status = "Completed",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 4444L, 
                SubjectName = "ฟิสิกส์วิศวกรรม 1", 
                Credit = 3, 
                Year = currentYear-1, 
                Term = 2, 
                RegistrationDate = "01/09/2565", 
                Status = "Completed",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 5555L, 
                SubjectName = "ภาษาอังกฤษพื้นฐาน", 
                Credit = 2, 
                Year = currentYear-1, 
                Term = 2, 
                RegistrationDate = "01/09/2565", 
                Status = "Completed",
                CanWithdraw = true
            }
        });
        
        // ข้อมูลจำลองเทอมก่อนหน้าอีก
        mockRegistrationData.Add($"{currentYear-1}/{1}", new List<RegisteredSubject.Model.RegisteredSubject>
        {
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 6666L, 
                SubjectName = "การเขียนโปรแกรมเบื้องต้น", 
                Credit = 3, 
                Year = currentYear-1, 
                Term = 1, 
                RegistrationDate = "01/05/2565", 
                Status = "Completed",
                CanWithdraw = true
            },
            new RegisteredSubject.Model.RegisteredSubject 
            { 
                CourseCode = 7777L, 
                SubjectName = "คณิตศาสตร์ทั่วไป", 
                Credit = 2, 
                Year = currentYear-1, 
                Term = 1, 
                RegistrationDate = "01/05/2565", 
                Status = "Completed",
                CanWithdraw = true
            }
        });
    }
    
    public void LoadTermOptions()
    {
        TermOptions.Clear();
        foreach (var key in mockRegistrationData.Keys.OrderByDescending(k => k))
        {
            TermOptions.Add(key);
            Debug.WriteLine($"Added term option: {key}");
        }
        
        Debug.WriteLine($"Total term options: {TermOptions.Count}");
        
        if (TermOptions.Count > 0)
        {
            SelectedTerm = TermOptions[0];
            Debug.WriteLine($"Selected initial term: {SelectedTerm}");
        }
        
        // เรียก OnPropertyChanged เพื่อให้แน่ใจว่า UI จะอัพเดท
        OnPropertyChanged(nameof(TermOptions));
    }
 
    [RelayCommand]
    private async Task SelectTerm(string term)
    {
        Debug.WriteLine($"SelectTerm called with parameter: {term}");
        if (term == null || !mockRegistrationData.ContainsKey(term))
        {
            Debug.WriteLine($"Invalid term selected: {term}");
            return;
        }
        
        SelectedTerm = term;
        
        // รอให้ UI ได้อัพเดตก่อน
        await Task.Delay(100);
        
        // ทำการโหลดข้อมูลใหม่ตาม term ที่เลือก
        LoadRegisteredSubjects();
        
        // แจ้งเตือน UI ให้อัพเดต
        OnPropertyChanged(nameof(SelectedTerm));
        OnPropertyChanged(nameof(RegisteredSubjects));
        OnPropertyChanged(nameof(TermDisplayText));
        OnPropertyChanged(nameof(TotalCreditsText));
        
        Debug.WriteLine($"After SelectTerm, RegisteredSubjects count: {RegisteredSubjects.Count}");
        foreach (var subject in RegisteredSubjects)
        {
            Debug.WriteLine($"Subject: {subject.SubjectName}");
        }
    }

public void LoadRegisteredSubjects()
    {
        Debug.WriteLine($"LoadRegisteredSubjects called with SelectedTerm: {SelectedTerm}");
        
        if (string.IsNullOrEmpty(SelectedTerm))
        {
            Debug.WriteLine("SelectedTerm is null or empty");
            return;
        }
        
        if (!mockRegistrationData.ContainsKey(SelectedTerm))
        {
            Debug.WriteLine($"No data found for term: {SelectedTerm}");
            RegisteredSubjects.Clear();
            TotalCreditsText = "จำนวนหน่วยกิตรวม: 0";
            return;
        }
        
        var subjects = mockRegistrationData[SelectedTerm];
        Debug.WriteLine($"Found {subjects.Count} subjects for term: {SelectedTerm}");
        
        // สร้าง collection ใหม่แทนการ Clear เพื่อให้ UI รับรู้การเปลี่ยนแปลง
        var newSubjects = new ObservableCollection<RegisteredSubject.Model.RegisteredSubject>();
        foreach (var subject in subjects)
        {
            newSubjects.Add(subject);
            Debug.WriteLine($"Added subject: {subject.SubjectName}");
        }
        
        RegisteredSubjects = newSubjects;
        
        decimal totalCredits = RegisteredSubjects.Where(s => s.Status == "Active" || s.Status == "Completed").Sum(s => s.Credit);
        TotalCreditsText = $"จำนวนหน่วยกิตรวม: {totalCredits}";
        
        // ตั้งค่า TermDisplayText
        var termParts = SelectedTerm.Split('/');
        if (termParts.Length == 2)
        {
            int year = int.Parse(termParts[0]);
            int term = int.Parse(termParts[1]);
            TermDisplayText = (year == currentYear && term == currentTerm)
                ? "ภาคเรียนปัจจุบัน"
                : $"ปีการศึกษา {year} ภาคเรียนที่ {term}";
            
            Debug.WriteLine($"Set TermDisplayText to: {TermDisplayText}");
        }
        
        // แจ้งเตือน UI ให้อัพเดต
        OnPropertyChanged(nameof(RegisteredSubjects));
        OnPropertyChanged(nameof(TotalCreditsText));
        OnPropertyChanged(nameof(TermDisplayText));
    }
    
    [RelayCommand]
    private async Task WithdrawSubject(RegisteredSubject.Model.RegisteredSubject subject)
    {
        if (subject == null || !subject.CanWithdraw)
            return;
        
        bool confirm = await Application.Current.MainPage.DisplayAlert("ยืนยันการถอนรายวิชา", 
            $"คุณต้องการถอนรายวิชา {subject.SubjectName} ใช่หรือไม่?", 
            "ยืนยัน", "ยกเลิก");
        
        if (confirm)
        {
            // ในระบบจริงควรจะบันทึกข้อมูลการถอนรายวิชาลงในฐานข้อมูล
            // แต่ในตัวอย่างนี้เราจะจำลองโดยการเปลี่ยนสถานะในข้อมูลจำลอง
            var registrations = mockRegistrationData[SelectedTerm];
            var subjectToUpdate = registrations.FirstOrDefault(s => s.CourseCode == subject.CourseCode);
            
            if (subjectToUpdate != null)
            {
                subjectToUpdate.Status = "Withdrawn";
                subjectToUpdate.CanWithdraw = false;
                
                await Application.Current.MainPage.DisplayAlert("สำเร็จ", 
                    $"ถอนรายวิชา {subject.SubjectName} เรียบร้อยแล้ว", "ตกลง");
                
                // อัพเดทหน้าจอ
                LoadRegisteredSubjects();
            }
        }
    }
    
}