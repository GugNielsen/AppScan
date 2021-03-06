using SccanApp.Models;
using SccanApp.RepositoryMock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SccanApp.RepositoryMock
{
    public class HomeWorckRepositoryMock : IHomeWorckRepositoryMock
    {
        public List<HomeWork> HomeWorkList;

        public HomeWorckRepositoryMock()
        {
            HomeWorkList = HomeWorkList == null ? ListHomeWorkListRepository() : HomeWorkList;
        }

        private static List<HomeWork> ListHomeWorkListRepository()
        {
            return new List<HomeWork> {
                new HomeWork { FileName = "salao_speakingmeeting.docx" },
                new HomeWork { FileName = "cozinha_writingnotes.docx" },
                new HomeWork { FileName = "contaluz_writingnotes.docx" }
            };
        }

        public List<HomeWork> InsertHomeWorkMockrepistory(HomeWork homeWork)
        {
            this.HomeWorkList.Add(homeWork);
            return this.HomeWorkList;
        }

        public List<HomeWork> RemoveHomeWorkMockrepistory(HomeWork homeWork)
        {
            var item = this.HomeWorkList.FirstOrDefault(x => x.FileName == homeWork.FileName);
            if (item != null)
            {
                HomeWorkList.Remove(item);
            }
         
            return this.HomeWorkList;
        }

        public List<HomeWork> GetAllHomeWorkListMockRepository()
        {
            return this.HomeWorkList;
        }

        public HomeWork GetHomeWorkByObj (Object obj)
        {
            var list  = GetAllHomeWorkListMockRepository();

            var homeWork = list.FirstOrDefault(x=>x.Equals(obj));

            return homeWork;
        }


    }
}
