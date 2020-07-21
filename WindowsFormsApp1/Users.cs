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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllUsers allUsers = new AllUsers();
            allUsers.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertUser insertUser = new InsertUser();
            insertUser.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 usr = new Form1();
            usr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteUser deleteUpdateUser = new DeleteUser();
            deleteUpdateUser.Show();
        }
    }
}
