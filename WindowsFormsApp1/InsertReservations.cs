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
    public partial class InsertReservations : Form
    {
        private ReservationBusiness reservationBusiness;
        private UserBusiness userBusiness;
        public InsertReservations()
        {
            InitializeComponent();
        }
        private void InsertReservations_Load(object sender, EventArgs e)
        {
            this.reservationBusiness = new ReservationBusiness();
            this.userBusiness = new UserBusiness();
            fillCombo();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservations res = new Reservations();
            res.Show();
        }

        private void fillCombo()
        {
            var users = this.userBusiness.GetAllUsers();
            foreach (User us in users)
            {
                this.comboBox1.Items.Add(us.username);
    
            }
        }
        private void ClearTextboxes()
        {
            tb_code.Clear();
            
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_code.Text) || String.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) ||
                 String.IsNullOrEmpty(combo_time.SelectedItem.ToString()) ||
                 String.IsNullOrEmpty(combo_time1.SelectedItem.ToString()) )
            {
                MessageBox.Show("Please insert all required fields!");
            }
            else
            {
                if (!Regex.Match(tb_code.Text, @"^\d+$").Success)
                {
                    MessageBox.Show("ID must be a number!");
                    return;
                }
                else
                {

                Reservation r = new Reservation();
                r.code = Int32.Parse(tb_code.Text);
                r.username = comboBox1.Text;
                r.time = combo_time.Text + ":" + combo_time1.Text;
                r.date = dateTimePicker1.Text;


                var users = this.reservationBusiness.InsertReservation(r);

                MessageBox.Show("Successfully inserted!");
                ClearTextboxes();
                }
            }
            
                
            }
        }

    }

        


