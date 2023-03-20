using Scheduler.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Login : Form
    {
        public Login()
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=net-8.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.lcid?view=net-8.0
            // var FormMainMenu = new FormMainMenu();
            // FormMainMenu.Show();

            InitializeComponent();
            changeLanguage(CultureInfo.CurrentCulture.Name);

        }
        private void changeLanguage(string name)
        {
            if (name == "es-ES")
            {
                labelPassword.Text = "Contraseña";
                labelUsername.Text = "Nombre de usuario";
                buttonSubmit.Text = "Enviar";
                var Login = new Login();
                Login.Text = "Iniciar sesión";


            }

        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click_1(object sender, EventArgs e)
        {
            bool validInfo = DB.successfulLogIn(textBoxUsername.Text, textBoxPassword.Text);
            if (validInfo == true)
            {
                var FormMainMenu = new FormMainMenu();
                FormMainMenu.Show();
                

                var Login = new Login();
                //Login.Close();
                //record success to text file
            }
            else
            {
                //record failure to text file
                if (labelPassword.Text == "Contraseña")
                {
                    MessageBox.Show("Nombre de usuario o contraseña no válidos. Inténtalo de nuevo.");
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                    return;
                }

            }
        }
    }
}
