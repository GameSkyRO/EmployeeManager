using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atestat;
using ComponentFactory.Krypton.Toolkit;
using static System.Net.Mime.MediaTypeNames;

namespace AtestatV2
{
    public partial class Form1 : KryptonForm

    {
        public List<app> apps = new List<app>();
        public List<echipa> echipe = new List<echipa>();
        public List<angajat> angajati = new List<angajat>();
        public List<echipa> resEch = new List<echipa>();

        public List<KryptonButton> buttonsL1 = new List<KryptonButton>();
        public List<KryptonButton> buttonsL2 = new List<KryptonButton>();
        public List<KryptonButton> buttonsL3 = new List<KryptonButton>();

        public List<Panel> panelsL1 = new List<Panel>();
        public List<Panel> panelsL2 = new List<Panel>();

        public int indice = 0;
        public int index = -1;


        public Form1(int acces)
        {
            InitializeComponent();
            GetApps(acces);
            GetTeams();
            GetEmployees();
            if (acces == 1)
            {
                panel1.Height = 40;
                AddApp.Visible = true;
                AddEmp.Visible = true;
            }
            else
            {
                panel1.Height = 0;
                AddApp.Visible = false;
                AddEmp.Visible = false;
            }
        }

        public void showHide(int k)
        {
            if (panelsL1[k].Visible)
                panelsL1[k].Visible = false;
            else panelsL1[k].Visible = true;
        }

        public void showHide2(int k)
        {
            if (panelsL2[k].Visible)
                panelsL2[k].Visible = false;
            else panelsL2[k].Visible = true;
        }

        public void GetApps(int acces)
        {
            AppDAO appDAO = new AppDAO();
            apps = appDAO.GetApps(acces);

            foreach (app aplication in apps)
            {
                this.Shown += (sender, e) => CreateButtonDelegateL1(aplication);
            }

        }

        public void GetTeams()
        {

            AppDAO appDAO = new AppDAO();
            echipe = appDAO.GetEchipe();

            foreach (app aplication in apps)
            {
                foreach (echipa ech in echipe)
                {
                    if (ech.prioritateAcc <= aplication.Acces)
                    {
                        this.Shown += (sender, e) => CreateButtonDelegateL2(ech, aplication);
                    }

                    else continue;
                }
                
            }
        }

        public void GetEmployees()
        {
            AppDAO appDAO = new AppDAO();
            angajati = appDAO.GetAngajati();
            int pindex = 0;
            foreach (app aplication in apps)
            {
                resEch = new List<echipa>();
                foreach (echipa ech in echipe) { if (ech.prioritateAcc <= aplication.Acces)
                    {
                        resEch.Add(ech);
                    }
                }

                foreach (echipa ech in resEch)
                {
                    
                    foreach(angajat employee in angajati) 
                    {
                        
                        if (ech.Nume == employee.Echipa)
                        {
                            var i = pindex;
                            this.Shown += (sender, e) => CreateButtonDelegateL3(i, employee);
                        }

                        else continue;
                    }

                    pindex++;
                }

            }
        }

        private void CreateButtonDelegateL1(app application)
        {

            KryptonButton newButton = new KryptonButton();
            buttonsL1.Add(newButton);
            Panel newPanel = new Panel();
            panelsL1.Add(newPanel);

            int i = apps.IndexOf(application);
            this.Controls.Add(panelsL1[i]);
            this.Controls.Add(buttonsL1[i]);

            if(application.Stare == "Published")
            {
                panelsL1[i].Parent = PublishedPanel;
                buttonsL1[i].Parent = PublishedPanel;
            }
            else if (application.Stare == "Beta")
            {
                panelsL1[i].Parent = BetaPanel;
                buttonsL1[i].Parent = BetaPanel;
            }
            else
            {
                panelsL1[i].Parent = AlphaPanel;
                buttonsL1[i].Parent = AlphaPanel;
            }

            panelsL1[i].BackColor = Color.LightCyan;

            panelsL1[i].Visible = false;
            panelsL1[i].Dock = DockStyle.Top;
            panelsL1[i].AutoSize = true;

            buttonsL1[i].StateCommon.Back.Color1 = Color.White;
            buttonsL1[i].StateCommon.Back.Color2 = Color.White;
            buttonsL1[i].ButtonStyle = ButtonStyle.ButtonSpec;
            buttonsL1[i].Text = application.Nume.ToString();
            buttonsL1[i].Size = new Size(90, 50);

            buttonsL1[i].Dock = DockStyle.Top;

            buttonsL1[i].Click += (sender, e) => showHide(i);
        }

        private void CreateButtonDelegateL2(echipa ech, app aplication)
        {

            KryptonButton newButton = new KryptonButton();
            buttonsL2.Add(newButton);
            Panel newPanel = new Panel();
            panelsL2.Add(newPanel);

            this.Controls.Add(buttonsL2[indice]);
            this.Controls.Add(panelsL2[indice]);

            panelsL2[indice].BackColor = Color.FromArgb(179, 255, 255);
            panelsL2[indice].MinimumSize = new Size(90, 40); //todelete

            panelsL2[indice].Parent = panelsL1[apps.IndexOf(aplication)];
            buttonsL2[indice].Parent = panelsL1[apps.IndexOf(aplication)];
            

            panelsL2[indice].Visible = false;
            panelsL2[indice].Dock = DockStyle.Top;
            panelsL2[indice].AutoSize = true;

            buttonsL2[indice].StateCommon.Back.Color1 = Color.White;
            buttonsL2[indice].StateCommon.Back.Color2 = Color.White;
            buttonsL2[indice].ButtonStyle = ButtonStyle.ButtonSpec;
            buttonsL2[indice].Text = ech.Nume.ToString();
            buttonsL2[indice].Size = new Size(90, 40);

            buttonsL2[indice].Dock = DockStyle.Top;

            buttonsL2[indice].Click += (sender, e) => showHide2(buttonsL2.IndexOf(newButton));
            indice++;
        }

        private void CreateButtonDelegateL3(int i, angajat employee)
        {

            KryptonButton newButton = new KryptonButton();
            buttonsL3.Add(newButton);
            this.Controls.Add(newButton);

            newButton.Parent = panelsL2[i];
            
            newButton.StateCommon.Back.Color1 = Color.White;
            newButton.StateCommon.Back.Color2 = Color.White;
            newButton.ButtonStyle = ButtonStyle.ButtonSpec;
            newButton.Text = employee.Nume.ToString();
            newButton.Size = new Size(90, 30);
            
            newButton.Dock = DockStyle.Top;

            newButton.Click += (sender, e) =>
            {
                Form2 detalii = new Form2(employee);
                detalii.Show();
                
            };

            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addApp_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void AddEmp_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
