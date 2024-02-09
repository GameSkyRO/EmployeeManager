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
    public partial class Form3 : KryptonForm
    {
        public Form3()
        {

            
            InitializeComponent();
            this.ActiveControl = label1;
            //placeholder nume
            NumeToAdd.Enter += (sender,e) => NumeToAdd_Enter();
            NumeToAdd.Leave += (sender,e) => NumeToAdd_Leave();

            //placeholder stare
            StareToAdd.Enter += (sender, e) => StareToAdd_Enter();
            StareToAdd.Leave += (sender, e) => StareToAdd_Leave();

            //placeholder pagina
            PaginaToAdd.Enter += (sender, e) => PaginaToAdd_Enter();
            PaginaToAdd.Leave += (sender, e) => PaginaToAdd_Leave();

            //placeholder acces
            AccesToAdd.Enter += (sender, e) => AccesToAdd_Enter();
            AccesToAdd.Leave += (sender, e) => AccesToAdd_Leave();

            
        }
 

        private void AddApp_Click(object sender, EventArgs e)
        {
            try {
                app appToAdd = new app
                {
                    Nume = NumeToAdd.Text,
                    Stare = StareToAdd.Text,
                    Pagina = PaginaToAdd.Text,
                    Acces = Int32.Parse(AccesToAdd.Text)
                };

                AppDAO appDAO = new AppDAO();
                appDAO.addApp(appToAdd);
                MessageBox.Show("App added successfully!");
                this.Hide();
            }
            catch
            {
                MessageBox.Show("The app could not be added!");
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

        private void StareToAdd_Enter()
        {
            if (StareToAdd.Text == "Stare")
            {
                StareToAdd.Text = "";
                StareToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void StareToAdd_Leave()
        {
            if (StareToAdd.Text == "")
            {
                StareToAdd.Text = "Stare";
                StareToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void AccesToAdd_Enter()
        {
            if (AccesToAdd.Text == "Acces")
            {
                AccesToAdd.Text = "";
                AccesToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void AccesToAdd_Leave()
        {
            if (AccesToAdd.Text == "")
            {
                AccesToAdd.Text = "Acces";
                AccesToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }

         private void PaginaToAdd_Enter()
        {
            if (PaginaToAdd.Text == "Pagina")
            {
                PaginaToAdd.Text = "";
                PaginaToAdd.StateCommon.Content.Color1 = Color.Black;
            }
        }

        void PaginaToAdd_Leave()
        {
            if (PaginaToAdd.Text == "")
            {
                PaginaToAdd.Text = "Pagina";
                PaginaToAdd.StateCommon.Content.Color1 = Color.Gray;
            }
        }
    }
}
