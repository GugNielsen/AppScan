using SccanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.RepositoryMock.Interfaces
{
    public interface IUserRepositoryMock
    {
        List<User> InsertUserMockrepistory(User user);
        List<User> RemoveUserMockrepistory(User user);
        List<User> GetAllUserListMockRepository();
        User UpdateUserMockRepository(User user);
       User GetUserByEmailListMockRepository(string email);



    }
}
