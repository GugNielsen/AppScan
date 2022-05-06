using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.ViewModels.Interfaces
{
	public interface IMessageService
	{
		Task ShowAsync(string message);
		Task<bool> ShowBoolAssyn(string message);
	}
}