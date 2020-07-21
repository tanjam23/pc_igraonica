using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReservationBusiness
    {
        private ReservationRepository reservationRepository;

        public ReservationBusiness()
        {
            this.reservationRepository = new ReservationRepository();
        }

        public List<Reservation> GetAllReservations()
        {
            return this.reservationRepository.GetAllReservations();
        }

        public List<Reservation> GetAllReservationsByDate(string date)
        {
            return this.reservationRepository.GetAllReservations().Where(r => r.date.Contains(date)).ToList();
        }
        

        public bool InsertReservation(Reservation r)
        {
            int res = 0;
            if (r != null)
            {
                res = this.reservationRepository.InsertReservation(r);
            }
            if (res > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateReservation(Reservation r)
        {
            int res = 0;
            if (r != null)
            {
                res = this.reservationRepository.UpdateReservation(r);
            }
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public void DeleteReservation(Reservation r)
        {
            this.reservationRepository.DeleteReservation(r);
        }
    }
}
