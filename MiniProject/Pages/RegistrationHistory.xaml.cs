using MiniProject.ViewModel;
using System.Diagnostics;

namespace MiniProject.Pages;

public partial class RegistrationHistory : ContentPage
{
    private RegistrationHistoryViewModel _viewModel;
    
    public RegistrationHistory()
    {
        InitializeComponent();
        _viewModel = new RegistrationHistoryViewModel();
        BindingContext = _viewModel;
        Debug.WriteLine("RegistrationHistory page initialized");
    }
    
    private async void GoToRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Register));
    }
    
    private async void GoToProfile(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Profile));
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
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine("RegistrationHistory OnAppearing called");
        
        // ทำให้แน่ใจว่ามีการโหลดข้อมูลเมื่อเปิดหน้า
        _viewModel.LoadTermOptions();
        _viewModel.LoadRegisteredSubjects();
        
        // เพิ่ม Force refresh
        if (_viewModel.SelectedTerm != null)
        {
            _viewModel.SelectTermCommand.Execute(_viewModel.SelectedTerm);
        }
        
        Debug.WriteLine($"After OnAppearing, RegisteredSubjects count: {_viewModel.RegisteredSubjects.Count}");
    }
}