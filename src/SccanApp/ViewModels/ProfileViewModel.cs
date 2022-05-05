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

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly IHomeWorckRepositoryMock _homeWorckRepositoryMock;
        public ObservableCollection<HomeWork> HomeWorksList { get; set; }
        public ProfileViewModel()
        {
            HomeWorksList = new ObservableCollection<HomeWork>()
            {
                new HomeWork { FileName = "salao_speakingmeeting.docx" },
                new HomeWork { FileName = "cozinha_writingnotes.docx" },
                new HomeWork { FileName = "contaluz_writingnotes.docx" }
            };
        }

        public ProfileViewModel(User user)
        {
            this.User = user;
            InicialName = RegexUtilities.ExtractInitialsFromName(user.Name);
            this._messageService = DependencyService.Get<IMessageService>();
            this._navigationService = DependencyService.Get<INavigationService>();
            this._homeWorckRepositoryMock = DependencyService.Get<IHomeWorckRepositoryMock>();

        
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
    }
}
