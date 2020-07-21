using BusinessLayer;
using DataLayer;
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
    public partial class AllUsers : Form
    {
        private UserBusiness userBusiness;
        public AllUsers()
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


        private void AllUsers_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
            fillUsers();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            
            var users = this.userBusiness.GetAllUsersByUsername(user_list.GetItemText(user_list.SelectedItem));
            foreach(User us in users)
            {
                tb_username.Text = us.username;
                tb_name.Text = us.name;
                tb_surname.Text = us.surname;
                tb_address.Text = us.address;
                tb_phone.Text = Convert.ToString(us.phone_number);
                tb_gender.Text = us.gender;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users usr = new Users();
            usr.Show();
        }

       
    }
}
