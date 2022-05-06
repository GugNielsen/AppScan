using SccanApp.Models;
using SccanApp.ViewModels;

namespace SccanApp;

public partial class EditeUserView : ContentPage
{
	public EditeUserView(User user)
	{
		InitializeComponent();
		this.BindingContext = new EditeUserViewModel(user);
	}
}