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
    public class RetrieveAccountViewModel : ViewModelBase
    {
		string email;
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
				this.Notify("UserName");
			}
		}

		public ICommand RetriveAccountCommand
		{
			get;
			set;
		}

		private readonly IMessageService _messageService;
		private readonly INavigationService _navigationService;
		private readonly IUserRepositoryMock _userRepositoryMock;

        public RetrieveAccountViewModel()
        {
			this.RetriveAccountCommand = new Command(this.RetriveAccount);

			this._messageService = DependencyService.Get<IMessageService>();
			this._navigationService = DependencyService.Get<INavigationService>();
			this._userRepositoryMock = DependencyService.Get<IUserRepositoryMock>();
		}

		private async void RetriveAccount()
        {
            var user = _userRepositoryMock.GetUserByEmailListMockRepository(Email);
            if (user != null)
            {
				user.Password = null;
				await this._messageService.ShowAsync($"Conta Recuperada sua conta é:  nome:{user.Name}, Telefone:{user.PhoneNumber}, Username:{user.UserName} mandamos a senha para seu email" );
				await this._navigationService.NavigateToLogin();
            }
            else
            {
				await this._messageService.ShowAsync($"Não exisite nenhum cadastro com esse email");
				await this._navigationService.NavigateToRegister();
			}
        }

    }
}
