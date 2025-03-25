using MiniProject.Model;
using MiniProject.ViewModel;

namespace MiniProject.Pages;

using System.Collections.ObjectModel;
using MiniProject.ViewModel;
using Newtonsoft.Json;

public partial class Profile : ContentPage
{
    public User CurrentUser { get; set; }
    public Profile()
    {
        InitializeComponent();
        LoadUserData();
    }
    private async void LoadUserData()
    {
        if (Preferences.ContainsKey("UserID"))
        {
            int userId = Preferences.Get("UserID", 0);
            var user = await GetUserById(userId);

            if (user != null)
            {
                CurrentUser = user;
                BindingContext = CurrentUser;
            }
        }
    }

    // อ่าน JSON และค้นหา User ตาม ID
    private async Task<User> GetUserById(int userId)
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(contents);

            return users?.FirstOrDefault(u => u.Idx == userId);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading user: {ex.Message}");
            return null;
        }
    }

    private async void GoToRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Register));
    }
    private async void GoToProfile(object sender, EventArgs e)
    {
        if (Shell.Current.CurrentState.Location.OriginalString == $"//{nameof(Profile)}")
        {
            await Shell.Current.GoToAsync(nameof(Profile));
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Logout", "คุณต้องการออกจากระบบหรือไม่?", "ใช่", "ไม่");
        if (confirm)
        {
            Preferences.Remove("UserID");
            await Shell.Current.GoToAsync(nameof(Login));
        }
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
{
    base.OnNavigatedTo(args);

    if (Preferences.ContainsKey("UserID"))
    {
        int userId = Preferences.Get("UserID", 0); // ดึงค่า UserID
        System.Diagnostics.Debug.WriteLine($"User ID: {userId}");
    }
}

}