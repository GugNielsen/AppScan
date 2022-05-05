using SccanApp.RepositoryMock.Interfaces;
using SccanApp.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SccanApp.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		string userName;
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				this.Notify("UserName");
			}
		}

		string password;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				this.Notify("Password");
			}
		}

		

		public ICommand LoginCommand
		{
			get;
			set;
		}

		public ICommand RegisterCommand
		{
			get;
			set;
		}

		public ICommand RetriveAccountCommand
		{
			get;
			set;
		}

		private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
		private readonly IUserRepositoryMock _userRepositoryMock;
		public LoginViewModel()
		{
			this.LoginCommand = new Command(this.Login);
			this.RegisterCommand = new Command(this.Register);
			this.RetriveAccountCommand = new Command(this.RetriveAccount);

			this._messageService = DependencyService.Get<IMessageService>();
			this._navigationService = DependencyService.Get<INavigationService>();
			this._userRepositoryMock = DependencyService.Get<IUserRepositoryMock>();
		}

		private async void Login()
        {
            var userlist = _userRepositoryMock.GetAllUserListMockRepository();

			var user = userlist.FirstOrDefault(x => x.UserName == this.UserName && x.Password == this.Password);

			if (user != null)
			{
				await this._navigationService.NavigateToProfile(user);
			}
			else
			{
				await this._messageService.ShowAsync("Email e/ou Senha inválidos...");
			}
		}

		private async void Register()
		{
			await this._navigationService.NavigateToRegister();
		}

		private async void RetriveAccount()
		{
			await this._navigationService.NavigateToRetrieveAccount();
		}
	}
}
