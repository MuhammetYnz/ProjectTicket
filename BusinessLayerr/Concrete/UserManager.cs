
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x => x.UserID== id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public List<User> GetSearchList(string p)
        {
            return _userDal.List(x=>x.UserName.Contains(p));
        }

        public User GetUser(string username, string password)
        {
            return _userDal.Get(x => x.UserMail == username && x.UserPassword == password);
        }

        public void UserAdd(User user)
        {
            _userDal.Insert(user);
        }

        public void UserDelete(User user)
        {
            throw new NotImplementedException();
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }
    }
}
