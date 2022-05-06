using SccanApp.Models;
using SccanApp.RepositoryMock.Interfaces;
using SccanApp.ViewModels;
using Syncfusion.Maui.ListView;

namespace SccanApp;

public partial class ProfileView : ContentPage
{
	public ProfileView(User user)
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel(user);
	
	}

}