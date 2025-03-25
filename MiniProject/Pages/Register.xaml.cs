using MiniProject.Model;
using MiniProject.ViewModel;
using MiniProjectSubject.Model;
using Newtonsoft.Json;

namespace MiniProject.Pages;

public partial class Register : ContentPage
{
    private RegisterViewModel _viewModel;

    public Register()
    {
        InitializeComponent();
        _viewModel = new RegisterViewModel();
        BindingContext = _viewModel;
    }
     
    
    
    private async void GoToRegister(object sender, EventArgs e)
    {
        if (Shell.Current.CurrentState.Location.OriginalString == $"//{nameof(Register)}")
        {
            await Shell.Current.GoToAsync(nameof(Register));
        }
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
    
    private void OnSubjectSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Subject selectedSubject)
        {
            _viewModel.AddSubjectCommand.Execute(selectedSubject);
            // Clear selection
            ((CollectionView)sender).SelectedItem = null;
        }
    }
    private async void GoToRegistrationHistory(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync(nameof(RegistrationHistory));
}
}