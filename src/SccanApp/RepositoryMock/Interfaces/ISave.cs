using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.RepositoryMock.Interfaces
{
    public interface ISave
    {
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}
