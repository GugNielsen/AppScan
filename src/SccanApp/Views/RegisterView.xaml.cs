using SccanApp.ViewModels;

namespace SccanApp;

public partial class RegisterView : ContentPage
{
	public RegisterView()
	{
		InitializeComponent();
		this.BindingContext = new RegisterViewModel();
	}
}