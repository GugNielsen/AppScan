using SccanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.ViewModels.Interfaces
{
	public interface INavigationService
	{
		Task NavigateToLogin();
		Task NavigateToRegister();
		Task NavigateToRetrieveAccount();
		Task NavigateToMain();
		Task NavigateToProfile(User user);
	}
}
