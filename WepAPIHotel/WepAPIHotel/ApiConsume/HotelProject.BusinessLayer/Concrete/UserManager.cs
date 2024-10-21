using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void TDelete(AppUser t)
        {
          _userDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
          return _userDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _userDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            _userDal.Add(t);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
       
        public List<AppUser> TUserListWithWorkLocation()
        {
            return _userDal.UserListWithWorkLocation();
        }

		public int TGetUserCount()
		{
            return _userDal.GetUserCount();
		}
	}
}
