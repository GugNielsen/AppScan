using SccanApp.Models;
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
    public class RegisterViewModel : ViewModelBase
    {
		User user = new User();
		public User User
		{
			get
			{
				return user;
			}
			set
			{
				user = value;
				this.Notify("User");
			}
		}

		public ICommand RegisterCommand
		{
			get;
			set;
		}

		private readonly IMessageService _messageService;
		private readonly INavigationService _navigationService;
		private readonly IUserRepositoryMock _userRepositoryMock;

        public RegisterViewModel()
        {
			this._messageService = DependencyService.Get<IMessageService>();
			this._navigationService = DependencyService.Get<INavigationService>();
			this._userRepositoryMock = DependencyService.Get<IUserRepositoryMock>();

			this.RegisterCommand = new Command(this.Register);

		}

		private async void Register()
		{
            if (User != null)
            {
				var userdb = _userRepositoryMock.GetUserByEmailListMockRepository(User.Email);
				if (userdb == null)
                {
					_userRepositoryMock.InsertUserMockrepistory(User);
					await _messageService.ShowAsync("Usuario Criado Com Sucesso");
					await _navigationService.NavigateToLogin();
				}
                else
                {
					await _messageService.ShowAsync("Usuario já criado em nossos sistema");
				}
			
			}
		}
	}
}
