using SccanApp.Models;

namespace SccanApp;

public partial class ProfileView : ContentPage
{
	public ProfileView(User user)
	{
		InitializeComponent();
		BindingContext = new ViewModels.ProfileViewModel(user);
	}
}