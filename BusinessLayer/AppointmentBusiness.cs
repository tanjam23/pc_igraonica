using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AppointmentBusiness
    {
        private AppointmentRepository appointmentRepository;

        public AppointmentBusiness()
        {
            this.appointmentRepository = new AppointmentRepository();
        }

        public List<Appointment> GetAllAppointments()
        {
            return this.appointmentRepository.GetAllAppointments();
        }

       // public List<Appointment> GetAppointmentByCode(int res_code)
        //{
        //    return this.appointmentRepository.GetAllAppointments().Where(a => a.res_code.Contains(res_code)).ToList();
        //}

        public bool InsertAppointment(Appointment a)
        {
            int res = 0;
            if (a != null)
            {
                res = this.appointmentRepository.InsertAppointments(a);
            }
            if (res > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateAppointment(Appointment a)
        {
            int res = 0;
            if (a != null)
            {
                res = this.appointmentRepository.UpdateAppointment(a);
            }
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAppointment(int id)
        {
            int res = this.appointmentRepository.DeleteAppointment(id);
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}

