using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IUserService
    {
        List<User> GetList();
        List<User> GetListPassive();
        List<User> GetSearchList(string p);//liste içinde isime göre arama yapmak için
        void UserAdd(User user);
        User GetByID(int id);     
        void UserDelete(User user);
        void UserUpdate(User user);
        User GetUser(string username, string password);
    }
}
