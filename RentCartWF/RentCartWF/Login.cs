using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RentCartWF
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            RENTCARTEntities rc = new RENTCARTEntities();
            try
            {
                Employees User = rc.Employees.Where(em => em.IDCard == txtName.Text && em.Password == txtPass.Text).Single();
                if (User.ID != 0)
                {

                    App app = new App();
                    app.Show();
                    this.Hide();

                }
            }
            catch (Exception ex) {

                labelMessage.Text = "Datos incorrectos.";
                labelMessage.Visible = true;
            }
        }
    }
}
