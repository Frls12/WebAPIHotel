using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFreamwork
{
    public class EfUserDal : GenericRepository<AppUser>, IUserDal
    {
        public EfUserDal(Context context) : base(context)
        {
        }

		public int GetUserCount()
		{
			var context = new Context();
            var values = context.Users.Count();
            return values;
		}

		public List<AppUser> UserListWithWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
            
        }
    }
}
