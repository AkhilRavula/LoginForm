using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                if
                (MessageBox.Show("Quit the Application", "Exit Application Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Click(object sender, EventArgs e)
        {

            if(CheckConnectivity())
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }

        }

        private bool CheckConnectivity()
        {
                try
                {
                     using (OracleConnection con = new OracleConnection("Data Source=PT315PDB01_PIA;User Id=" + Username.Text + ";Password=" + Password.Text + ";"))
                     {
                           con.Open();
                           return true;
                     }
                }
                catch (OracleException ex)
                {
                    switch (ex.Number)
                    {
                        case 4060:
                            MessageBox.Show("Invalid Database");                      
                       break;
                        case 18456:
                        MessageBox.Show("Login Failed");
                        break;
                        default:
                        MessageBox.Show("Unable to open Connection");
                        break;
                        //SELECT* FROM master.dbo.sysmessages


                    }
                      return false;
                }
            

        }
    }
}
