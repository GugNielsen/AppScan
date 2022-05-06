using SccanApp.Controls;
using SccanApp.Models;
using SccanApp.RepositoryMock.Interfaces;
using SccanApp.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SccanApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
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

        string initialName;
        public string InicialName
        {
            get
            {
                return initialName;
            }
            set
            {
                initialName = value;
                this.Notify("InicialName");
            }
        }

        public ICommand RemoveUserCommand
        {
            get;
            set;
        }

        public ICommand EditeUserCommand
        {
            get;
            set;
        }

        public ICommand RemoveHomeWorkCommand
        {
            get;
            set;
        }

        public ICommand GetSccanCommand
        {
            get;
            set;
        }

        public ICommand OpenPDFCommand
        {
            get;
            set;
        }


        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly IHomeWorckRepositoryMock _homeWorckRepositoryMock;
        private readonly IUserRepositoryMock _userRepositoryMock;
        public ObservableCollection<HomeWork> HomeWorksList { get; set; }
     

        public ProfileViewModel(User user)
        {
            this.User = user;
            InicialName = RegexUtilities.ExtractInitialsFromName(user.Name);
            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();
            this._homeWorckRepositoryMock = DependencyService.Get<IHomeWorckRepositoryMock>();
            this._userRepositoryMock = DependencyService.Get<IUserRepositoryMock>();

            this.RemoveUserCommand = new Command(this.LoadRemoveUser);
            this.EditeUserCommand = new Command(this.LoadEditeUser);
            this.RemoveHomeWorkCommand = new Command<object>((x) => this.RemoveHomeWork(x));

            this.GetSccanCommand = new Command(this.GetSccan);
            this.OpenPDFCommand = new Command(this.OpenPDF);



            LoadList();

        }

   

        void LoadList()
        {
            HomeWorksList = new ObservableCollection<HomeWork>();
            var list = _homeWorckRepositoryMock.GetAllHomeWorkListMockRepository();

            foreach (var item in list)
            {
                HomeWorksList.Add(item);
            }
        }

        private async void LoadRemoveUser()
        {
            RemoveUser(user);
        }
        private async void RemoveUser(User user)
        {
            var resMsg = await _messageService.ShowBoolAssyn("Deseja Deletar sua conta");

            if (resMsg)
            {
                _userRepositoryMock.RemoveUserMockrepistory(user);

                await _messageService.ShowAsync("Conta deletada com Sucesso");

                await _navigationService.NavigateToLogin();
            }
        }

        private async void LoadEditeUser()
        {
            EditeUser(user);
        }
        private async void EditeUser(User user)
        {
          await _navigationService.NavigateToEditeUser(user);
        }

        private  async void RemoveHomeWork (object obt)
        {
            var resMsg = await _messageService.ShowBoolAssyn("Deseja Deletar esse item");
           
            if (resMsg)
            {
                var eventArgs = obt as Syncfusion.Maui.ListView.ItemTappedEventArgs;
                var homeWork = (eventArgs.ItemData as HomeWork);

                _homeWorckRepositoryMock.RemoveHomeWorkMockrepistory(homeWork);
                this.HomeWorksList.Remove(homeWork);

                await _messageService.ShowAsync("Item deletado com Sucesso");

            }

        }

        private async void GetSccan()
        {
            await _messageService.ShowAsync("Não foi possivel acessar devido a baixa funcionalidade do preview do MAIU");
        }


        private async void OpenPDF()
        {
            await _messageService.ShowAsync("Não foi possivel acessar devido a baixa funcionalidade do preview do MAIU");
        }
    }
}
