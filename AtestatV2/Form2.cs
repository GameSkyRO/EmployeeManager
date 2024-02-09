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
    public partial class Form2 : KryptonForm
    {
        public Form2(angajat employee)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = employee.LinkImagine;
            NumeAngajat.Text = employee.Nume;
            EmailAngajat.Text = employee.Email;
            DepartamentAngajat.Text = employee.Departament;
            EchipaAngajat.Text = employee.Echipa;
            FunctieAngajat.Text = employee.Functie;
            AnAngajare.Text = employee.An.ToString();

        }
    }
}
