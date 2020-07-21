using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DeleteUpdateReservation : Form
    {
        private ReservationBusiness reservationBusiness;
        private UserBusiness userBusiness;
        public DeleteUpdateReservation()
        {
            InitializeComponent();
        }

        private void DeleteUpdateReservation_Load(object sender, EventArgs e)
        {
            this.reservationBusiness = new ReservationBusiness();
            this.userBusiness = new UserBusiness();
            fillCombo();
            fillReservations();
        }
        private void fillReservations()
        {
            var reservations = this.reservationBusiness.GetAllReservations();
            foreach (Reservation r in reservations)
            {
                this.user_list.Items.Add(r.code+"  -  " + r.username + " - " + r.date + "  " + r.time);
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_code.Text))
            {
                MessageBox.Show("Please insert date!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Reservation r = new Reservation();
                    r.code = Int32.Parse(tb_code.Text);
                    this.reservationBusiness.DeleteReservation(r);
                    

                    MessageBox.Show("Successfully deleted!");
                    user_list.Items.Clear();
                    fillReservations();
                }
                else
                {
                    return;
                }
            }
        }
        private void fillCombo()
        {
            var users = this.userBusiness.GetAllUsers();
            foreach (User us in users)
            {
                this.comboBox1.Items.Add(us.username);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservations res = new Reservations();
            res.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_code.Text) || String.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) ||
                String.IsNullOrEmpty(combo_time.SelectedItem.ToString()) ||
                String.IsNullOrEmpty(combo_time1.SelectedItem.ToString()))
            {
                MessageBox.Show("Please insert all required fields!");
            }
            else
            {
                if (!Regex.Match(tb_code.Text, @"^\d+$").Success)
                {
                    MessageBox.Show("Code must be a number!");
                    return;
                }
                else
                {
                    Reservation r = new Reservation();
                    r.code = Convert.ToInt32(tb_code.Text);
                    r.username = comboBox1.Text;
                    r.time = combo_time.Text + ":" + combo_time1.Text;
                    r.date = dateTimePicker1.Text;

                    this.reservationBusiness.UpdateReservation(r);
                    MessageBox.Show("Successfully updated!");
                    user_list.Items.Clear();
                    fillReservations();
                }
            }
        }
    }
}
