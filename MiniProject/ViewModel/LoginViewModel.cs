using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniProject.Model;
using MiniProject.Pages;
using System.Collections.ObjectModel;
using Microsoft.Maui.Storage;
namespace MiniProject.ViewModel;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    string username = "";

    [ObservableProperty]
    string password = "";
    [ObservableProperty]
    ObservableCollection<User> users = new ObservableCollection<User>();
    
    // Read users from the JSON file
    async Task<List<User>> ReadJsonAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            List<User> users = User.FromJson(contents);
            return users;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return new List<User>();
        }
    } // Import Preferences

    [ObservableProperty]
    int userId = 0; // เก็บค่า ID ของ User ที่ล็อกอิน

    [RelayCommand]
    async Task Login()
    {
        var allUsers = await ReadJsonAsync();
        if (allUsers != null && allUsers.Count > 0)
        {
            var foundUser = allUsers.FirstOrDefault(u => u.Email == Username && u.Password == Password);
            
            if (foundUser != null)
            {   
                // เก็บค่า UserID ลง Preferences
                Preferences.Set("UserID", foundUser.Idx);

                await Application.Current.MainPage.DisplayAlert("เข้าสู่ระบบสำเร็จ", $"ยินดีต้อนรับ {foundUser.Firstname}", "ตกลง");
                await GoToPage($"{nameof(Profile)}?id={foundUser.Idx}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("เข้าสู่ระบบล้มเหลว", "อีเมลหรือรหัสผ่านไม่ถูกต้อง", "ตกลง");
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("ข้อผิดพลาด", "ไม่พบข้อมูลผู้ใช้", "ตกลง");
        }
    }

    // Navigate to a specific page
    [RelayCommand]
    async Task GoToPage(string page)
    {
        await Shell.Current.GoToAsync(page);
    }
}