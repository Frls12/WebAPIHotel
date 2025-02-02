﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
	public class BookingManager : IBookingService
	{

		private readonly IBookingDal _bookingDal;
		public BookingManager(IBookingDal bookingDal)
		{
			_bookingDal = bookingDal;
		}

        public void TBookingStatusChangeApproved(int id)
        {
			_bookingDal.BookingStatusChangeApproved(id);
        }

        public void TBookingStatusChangeCancel(int id)
        {
			_bookingDal.BookingStatusChangeCancel(id);
        }

        public void TBookingStatusChangeWait(int id)
        {
			_bookingDal.BookingStatusChangeWait(id);
        }

        public void TDelete(Booking t)
		{
			_bookingDal.Delete(t);
		}

		public int TGetBookingCount()
		{
			return _bookingDal.GetBookingCount();
		}

		public Booking TGetById(int id)
		{
			return _bookingDal.GetById(id);
		}

		public List<Booking> TGetList()
		{
			return _bookingDal.GetList();
		}

		public void TInsert(Booking t)
		{
			_bookingDal.Add(t);
		}

		public List<Booking> TLast6Booking()
		{
			return _bookingDal.Last6Booking();
		}

		public void TUpdate(Booking t)
		{
			_bookingDal.Update(t);
		}
	}
}
