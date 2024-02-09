using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atestat;
using ComponentFactory.Krypton.Toolkit;

namespace AtestatV2
{
    public partial class Form4 : KryptonForm
    {
        public Form4()
        {
            InitializeComponent();
            this.ActiveControl = label1;
            //placeholder nume
            NumeToAdd.Enter += (sender, e) => NumeToAdd_Enter();
            NumeToAdd.Leave += (sender, e) => NumeToAdd_Leave();

            //placeholder email
            EmailToAdd.Enter += (sender, e) => EmailToAdd_Enter();
            EmailToAdd.Leave += (sender, e) => EmailToAdd_Leave();

            //placeholder an
            AnToAdd.Enter += (sender, e) => AnToAdd_Enter();
            AnToAdd.Leave += (sender, e) => AnToAdd_Leave();

            //placeholder departament
            DeptToAdd.Enter += (sender, e) => DeptToAdd_Enter();
            DeptToAdd.Leave += (sender, e) => DeptToAdd_Leave();

            //placeholder echipa
            EchipaToAdd.Enter += (sender, e) => EchipaToAdd_Enter();
            EchipaToAdd.Leave += (sender, e) => EchipaToAdd_Leave();

            //placeholder functie
            FunctieToAdd.Enter += (sender, e) => FunctieToAdd_Enter();
            FunctieToAdd.Leave += (sender, e) => FunctieToAdd_Leave();

            //placeholder an
            LinkToAdd.Enter += (sender, e) => LinkToAdd_Enter();
            LinkToAdd.Leave += (sender, e) => LinkToAdd_Leave();
        }

        private void AddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                angajat employeeToAdd = new angajat
                {
                    Nume = NumeToAdd.Text,
                    Email = EmailToAdd.Text,
                    An = Int32.Parse(AnToAdd.Text),
                    Departament = DeptToAdd.Text,
                    Echipa = EchipaToAdd.Text,
                    Functie = FunctieToAdd.Text,
                    LinkImagine = LinkToAdd.Text
                };

                AppDAO appDAO = new AppDAO();
                appDAO.addEmployee(employeeToAdd);
                MessageBox.Show("Employee added successfully!");
                this.Hide();
            }
            catch
            {
                MessageBox.Show("The employee could not be added!");
                this.Hide();
            }
        }

        //
        //Functii destinate designului textbox
        //

        private void NumeToAdd_Enter()
        {
            if (NumeToAdd.Text == "Nume")
            {
                NumeToAdd.Text = "";
                NumeToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void NumeToAdd_Leave()
        {
            if (NumeToAdd.Text == "")
            {
                NumeToAdd.Text = "Nume";
                NumeToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void EmailToAdd_Enter()
        {
            if (EmailToAdd.Text == "Email")
            {
                EmailToAdd.Text = "";
                EmailToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void EmailToAdd_Leave()
        {
            if (EmailToAdd.Text == "")
            {
                EmailToAdd.Text = "Email";
                EmailToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void AnToAdd_Enter()
        {
            if (AnToAdd.Text == "An angajare")
            {
                AnToAdd.Text = "";
                AnToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void AnToAdd_Leave()
        {
            if (AnToAdd.Text == "")
            {
                AnToAdd.Text = "An angajare";
                AnToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void DeptToAdd_Enter()
        {
            if (DeptToAdd.Text == "Departament")
            {
                DeptToAdd.Text = "";
                DeptToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void DeptToAdd_Leave()
        {
            if (DeptToAdd.Text == "")
            {
                DeptToAdd.Text = "Departament";
                DeptToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void EchipaToAdd_Enter()
        {
            if (EchipaToAdd.Text == "Echipa")
            {
                EchipaToAdd.Text = "";
                EchipaToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void EchipaToAdd_Leave()
        {
            if (EchipaToAdd.Text == "")
            {
                EchipaToAdd.Text = "Echipa";
                EchipaToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void FunctieToAdd_Enter()
        {
            if (FunctieToAdd.Text == "Functie")
            {
                FunctieToAdd.Text = "";
                FunctieToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void FunctieToAdd_Leave()
        {
            if (FunctieToAdd.Text == "")
            {
                FunctieToAdd.Text = "Functie";
                FunctieToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void LinkToAdd_Enter()
        {
            if (LinkToAdd.Text == "Link imagine")
            {
                LinkToAdd.Text = "";
                LinkToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void LinkToAdd_Leave()
        {
            if (LinkToAdd.Text == "")
            {
                LinkToAdd.Text = "Link imagine";
                LinkToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

    }
}
