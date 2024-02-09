using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atestat;
using ComponentFactory.Krypton.Toolkit;

namespace AtestatV2
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
            //placeholder username
            Username.Enter += (sender, e) => Username_Enter();
            Username.Leave += (sender, e) => Username_Leave();

            //placeholder password
            Password.Enter += (sender, e) => Password_Enter();
            Password.Leave += (sender, e) => Password_Leave();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            
            AppDAO appDAO = new AppDAO();
            int AccesValue = appDAO.Login(username, password);
            if (AccesValue != 0)
            {
                Form1 mainform = new Form1(AccesValue);
                mainform.Show();

                this.Hide();
            }
            else { MessageBox.Show("Incorrect username or password!"); }

        }

        //
        //Functii destinate designului textbox
        //

        void Username_Enter()
        {
            if (Username.Text == "Username")
            {
                Username.Text = "";
                Username.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void Username_Leave()
        {
            if (Username.Text == "")
            {
                Username.Text = "Username";
                Username.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        void Password_Enter()
        {
            if (Password.Text == "Password")
            {
                Password.Text = "";
                Password.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void Password_Leave()
        {
            if (Password.Text == "")
            {
                Password.Text = "Password";
                Password.StateCommon.Content.Color1 = Color.Gray;
            }
        }
    }
}
