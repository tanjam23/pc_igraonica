using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AllReservations : Form
    {
        private ReservationBusiness reservationBusiness;
        public AllReservations()
        {
            InitializeComponent();
            
        }
        private void AllReservations_Load(object sender, EventArgs e)
        {
            this.reservationBusiness = new ReservationBusiness();
            fillReservations();
        }

        private void fillReservations()
        {
            var reservation = this.reservationBusiness.GetAllReservations();
            foreach (Reservation r in reservation)
            {
                this.lb_code.Items.Add(r.code);
                this.lb_username.Items.Add(r.username);
                this.lb_time.Items.Add(r.time);
                this.lb_date.Items.Add(r.date);
            }

        }
        private void fillReservationsByDate()
        {
            var reservation = this.reservationBusiness.GetAllReservationsByDate(dateTimePicker1.Text);
            foreach (Reservation r in reservation)
            {
                this.lb_code.Items.Add(r.code);
                this.lb_username.Items.Add(r.username);
                this.lb_time.Items.Add(r.time);
                this.lb_date.Items.Add(r.date);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lb_code.Items.Clear();
            lb_username.Items.Clear();
            lb_time.Items.Clear();
            lb_date.Items.Clear();
            fillReservationsByDate();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservations res = new Reservations();
            res.Show();
        }
    }
}
