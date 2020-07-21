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
    public partial class DeleteUser : Form
    {
        private UserBusiness userBusiness;
        public DeleteUser()
        {
            InitializeComponent();

        }
        private void fillUsers()
        {
            var users = this.userBusiness.GetAllUsers();
            foreach (User u in users)
            {
                this.user_list.Items.Add(u.username);
            }

        }
        private void ClearTextboxes()
        {
            tb_username.Clear();
            tb_name.Clear();
            tb_surname.Clear();
            tb_address.Clear();
            tb_phone.Clear();
            tb_gender.Clear();

        }


        private void DeleteUser_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
            fillUsers();
        }
        

        private void btn_about_Click_1(object sender, EventArgs e)
        {
            var users = this.userBusiness.GetAllUsersByUsername(user_list.GetItemText(user_list.SelectedItem));
            foreach (User us in users)
            {
                tb_username.Text = us.username;
                tb_name.Text = us.name;
                tb_surname.Text = us.surname;
                tb_address.Text = us.address;
                tb_phone.Text = Convert.ToString(us.phone_number);
                tb_gender.Text = us.gender;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_username.Text))
            {
                MessageBox.Show("Please insert username!");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    User u = new User();
                    u.username = tb_username.Text;
                    this.userBusiness.DeleteUser(u);


                    MessageBox.Show("Successfully deleted!");
                    user_list.Items.Clear();
                    fillUsers();
                    ClearTextboxes();
                }
                else
                {
                    return;
                }
            }

        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Users usr = new Users();
            usr.Show();
        }

    }
}
