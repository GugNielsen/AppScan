using SccanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.RepositoryMock.Interfaces
{
    public interface IHomeWorckRepositoryMock
    {
        List<HomeWork> InsertHomeWorkMockrepistory(HomeWork homeWork);

        List<HomeWork> RemoveHomeWorkMockrepistory(HomeWork homeWork);

         List<HomeWork> GetAllHomeWorkListMockRepository();
    }
}
