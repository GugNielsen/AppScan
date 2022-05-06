using SccanApp.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.Views.Services
{
	public class MessageService : IMessageService
	{

		public async System.Threading.Tasks.Task ShowAsync(string message)
		{
			await App.Current.MainPage.DisplayAlert("SccanApp", message, "ok");
		}

		public async Task<bool> ShowBoolAssyn(string message)
        {
			return await App.Current.MainPage.DisplayAlert("SccanApp", message, "Yes","No");
		}


		public MessageService()
		{
		}
	}
}
