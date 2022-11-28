using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsan
{
    public partial class Form1 : Form
    {
        List<string> User = new autheticate().attainUser();// fetches data from file using the class
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please enter Username!!!");
                    return;
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter Password!!!", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error)
                      ;
                    return; 
                }
                else
                {
                    for (int i = 0; i < User.Count; i++) //checks if login details are correct
                    {
                        if (User[i].Trim() == txtUsername.Text && User[i + 1].Trim() == txtPassword.Text)
                        {
                            StreamWriter Log = new StreamWriter("dailylog.txt", true);// saves ldetails of login in file

                            Log.Write(txtUsername.Text + "#" + Convert.ToString(DateTime.Now) + "#");
                            Log.Close();
                            MessageBox.Show("log in succesfull");

                            this.Hide();
                            MainMenu mn = new MainMenu();
                            mn.Show();
                            return;
                            
                        }

                        else
                        {
                            MessageBox.Show("Incorrect Username or Password");
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                    
                      
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// catch errors
            }
        }
    }
}
