using MiniProject.ViewModel;

namespace MiniProject.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
	}
}
public class LoginData
{
	public string Uname { get; set; } = "";
	public string Pwd { get; set; } = "";
}