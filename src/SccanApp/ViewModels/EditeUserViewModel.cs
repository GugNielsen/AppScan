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
    public class EditeUserViewModel : ViewModelBase
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

        public ICommand EditeUserCommand
        {
            get;
            set;
        }

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly IUserRepositoryMock _userRepositoryMock;

        public EditeUserViewModel(User user)
        {
            this.User = user;

            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();
            this._userRepositoryMock = DependencyService.Get<IUserRepositoryMock>();

            this.EditeUserCommand = new Command(this.EditeUser);


        }

        private async void EditeUser()
        {
            _userRepositoryMock.UpdateUserMockRepository(user);
            await _messageService.ShowAsync("Atualizado com Sucesso");
            await _navigationService.NavigateToProfile(user);
        }
    }
}
