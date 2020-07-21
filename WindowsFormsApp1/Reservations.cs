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
    public partial class Reservations : Form
    {
        public Reservations()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AllReservations allReservations = new AllReservations();
            allReservations.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            InsertReservations insertReservations = new InsertReservations();
            insertReservations.Show();
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 res = new Form1();
            res.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteUpdateReservation deleteReservation = new DeleteUpdateReservation();
            deleteReservation.Show();
        }
    }
}
