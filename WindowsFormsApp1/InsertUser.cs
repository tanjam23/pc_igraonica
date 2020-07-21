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
    public partial class InsertUser : Form
    {
        private UserBusiness userBusiness;
        public InsertUser()
        {
            InitializeComponent();
        }
        private void InsertUser_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users usr = new Users();
            usr.Show();
        }
        private void ClearTextboxes()
        {
            tb_username.Clear();
            tb_name.Clear();
            tb_surname.Clear();
            tb_address.Clear();
            tb_phone.Clear();

        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_username.Text) || String.IsNullOrWhiteSpace(tb_name.Text) || String.IsNullOrEmpty(tb_surname.Text) ||  String.IsNullOrEmpty(tb_phone.Text))
            {
                MessageBox.Show("Please insert all required fields!");
            }
            else
            {
                  if (!Regex.Match(tb_phone.Text, @"^\d+$").Success)
                    {
                        MessageBox.Show("Phone must be a number!");
                        return;
                    }
                    User u = new User();
                u.username = tb_username.Text;
                u.name = tb_name.Text;
                u.surname = tb_surname.Text;
                u.address = tb_address.Text;
                u.phone_number= Int32.Parse(tb_phone.Text);

                if (rb_male.Checked)
                {
                    u.gender = "Male";
                }
                else
                {
                    u.gender = "Female";
                }
                var users = this.userBusiness.InsertUser(u);

                MessageBox.Show("Successfully inserted!");
                ClearTextboxes();
            }
        }

        
    }
}

