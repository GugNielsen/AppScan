using SccanApp.Models;
using SccanApp.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.Views.Services
{
	public class NavigationService : INavigationService
	{
		

		public async System.Threading.Tasks.Task NavigateToLogin()
		{
			await App.Current.MainPage.Navigation.PushAsync(new LoginView());
		}

		public async System.Threading.Tasks.Task NavigateToRegister()
		{
			await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
		}

		public async System.Threading.Tasks.Task NavigateToMain()
		{
			await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
			//await App.Current.MainPage.Navigation.PushAsync(new MainView());
		}

        public async Task NavigateToRetrieveAccount()
        {
			await App.Current.MainPage.Navigation.PushAsync(new RetrieveAccountView());
		}

        public async Task NavigateToProfile(User user)
        {
			await App.Current.MainPage.Navigation.PushAsync(new ProfileView(user));
		}

		public async Task NavigateToEditeUser(User user)
		{
			await App.Current.MainPage.Navigation.PushAsync(new EditeUserView(user));
		}

		public NavigationService()
		{
		}
	}
}