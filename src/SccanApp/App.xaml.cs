using SccanApp.RepositoryMock;
using SccanApp.RepositoryMock.Interfaces;
using SccanApp.ViewModels.Interfaces;
using SccanApp.Views.Services;

namespace SccanApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DependencyService.Register<IMessageService, MessageService>();
		DependencyService.Register<INavigationService, NavigationService>();
		DependencyService.Register<IUserRepositoryMock, UserRepositoryMock>();
		DependencyService.Register<IHomeWorckRepositoryMock, HomeWorckRepositoryMock>();

		MainPage = new NavigationPage(new LoginView());
	}
}
