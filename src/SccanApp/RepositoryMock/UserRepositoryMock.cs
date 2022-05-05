using SccanApp.Models;
using SccanApp.RepositoryMock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.RepositoryMock
{
    public class UserRepositoryMock : IUserRepositoryMock
    {
        public List<User> UserList { get; set; }

        public UserRepositoryMock()
        {
            UserList = UserList == null ? ListUserMockRepository() : UserList;
        }


        private static List<User> ListUserMockRepository()
        {
            return new List<User> {
                    new User
                    {
                        Name = "Gustavo Nielsen",
                        UserName  ="gugnielsen",
                        Email= "gug@gmail.com",
                        Password= "123456",
                        PhoneNumber = "21 997658398"

                    },
                     new User
                     {
                         Name = "Ricardo Aleluia",
                         UserName  ="ric24",
                         Email= "ric@gmail.com",
                         Password= "123456",
                         PhoneNumber = "21 987658398"
                     },
                      new User
                      {
                          Name = "Joasley Ferreira",
                          UserName  ="fererinha.docs",
                          Email= "fererinha@gmail.com",
                          Password= "123456",
                          PhoneNumber = "21 977658398"

                      },
                       new User
                        {
                            Name = "Junior Paludo",
                            UserName  ="Junior.345",
                            Email= "345@gmail.com",
                            Password= "123456",
                            PhoneNumber = "21 967658398"
                        },
                        new User
                        {
                            Name = "Juliana Camara",
                            UserName  ="Camara23",
                            Email= "Camara23@gmail.com",
                            Password= "123456",
                            PhoneNumber = "21 957658398"

                        },
            };
        }

        public List<User> InsertUserMockrepistory(User user)
        {
            this.UserList.Add(user);
            return this.UserList;
        }

        public List<User> RemoveUserMockrepistory(User user)
        {
            this.UserList.Remove(user);
            return this.UserList;
        }

        public List<User> GetAllUserListMockRepository()
        {
            return this.UserList;
        }

        public User GetUserByEmailListMockRepository( string email)
        {
          var userlist =  this.UserList;

            var user = userlist.FirstOrDefault(x=>x.Email.Equals(email));
            return user;
        }
    }
}
