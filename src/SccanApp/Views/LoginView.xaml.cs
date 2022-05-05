using SccanApp.ViewModels;

namespace SccanApp;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
		this.BindingContext = new LoginViewModel();
	}
}