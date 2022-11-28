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
    public partial class MainMenu : Form
    {


        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Pw = Convert.ToInt32(txtPWaterUsed.Text);
            int P_Bill;
            int W_Bill;
            string vat = "14";
            int total;

            if (txtUserType.Text == "domestic")
            {
                if (Pw <= 5)
                {
                    P_Bill = (int)(Pw * 3.60);
                    W_Bill = (int)(Pw * 0.65);
                    total = P_Bill + W_Bill;
                }
                else if (Pw > 5 && Pw <= 15)
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 13.43);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 3.36);
                    total = P_Bill + W_Bill;

                }
                else if (Pw > 15 && Pw <= 25)
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 23.51);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 5.03);
                    total = P_Bill + W_Bill;

                }
                else if (Pw > 25 && Pw <= 40)
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 36.16);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 6.71);
                    total = P_Bill + W_Bill;

                }
                else
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 45.21);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 8.39);
                    total = P_Bill + W_Bill;

                }
                MessageBox.Show("name:" + txtFname.Text + txtSname.Text + "   " + "plot no.:" + txtPnum.Text + "\n" + "portable water used:" + txtPWaterUsed.Text + "\n" + "Portable water cost:" + Convert.ToString(P_Bill) + "\n" + "waste water cost:" + Convert.ToString(W_Bill) + "\n" + "vat:" + vat + "\n" + "total:" + Convert.ToString(total));
                StreamWriter Log = new StreamWriter("billing.txt", true);// saves ldetails of login in file

                Log.Write("name:" + txtFname.Text + txtSname.Text + "#" + "plot no.:" + txtPnum.Text + "#" + "portable water used:" + txtPWaterUsed.Text + "#" + "Portable water cost:" + Convert.ToString(P_Bill) + "#" + "waste water cost:" + Convert.ToString(W_Bill) + "#" + "vat:" + vat + "#" + "total:" + Convert.ToString(total)+"#");
                Log.Close();
            }
            if (txtUserType.Text == "business" || txtUserType.Text == "comercial" || txtUserType.Text == "industrial")
            {
                if (Pw <= 5)
                {
                    P_Bill = (int)(Pw * 4.92);
                    W_Bill = (int)(Pw * 0.74);
                    total = P_Bill + W_Bill;

                }
                else if (Pw > 5 && Pw <= 15)
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 14.16);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 3.36);
                    total = P_Bill + W_Bill;

                }
                else if (Pw > 15 && Pw <= 25)
                {

                    P_Bill = (int)((Pw * 3.60) + (Pw - 5) * 25.58);
                    W_Bill = (int)((Pw * 0.65) + (Pw - 5) * 5.03);
                    total = P_Bill + W_Bill;

                }
                else if (Pw > 25 && Pw <= 40)
                {
                    P_Bill = (int)((Pw * 3.60) + (Pw - 5) * 39.35);
                    W_Bill = (int)((Pw * 0.65) + (Pw - 5) * 6.71);
                    total = P_Bill + W_Bill;

                }
                else
                {
                    P_Bill = (int)((5 * 3.60) + (Pw - 5) * 49.20);
                    W_Bill = (int)((5 * 0.65) + (Pw - 5) * 8.39);
                    total = P_Bill + W_Bill;

                }

                MessageBox.Show("name:" + txtFname.Text + txtSname.Text + "   " + "plot no.:" + txtPnum.Text + "\n" + "portable water used:" + txtPWaterUsed.Text + "\n" + "Portable water cost:" + Convert.ToString(P_Bill) + "\n" + "waste water cost:"+Convert.ToString(W_Bill)+ "\n"+ "vat:"+ vat +"\n" +"total:" + Convert.ToString(total));
                StreamWriter Log = new StreamWriter("billing.txt", true);// saves ldetails of login in file

                Log.Write("name:" + txtFname.Text + txtSname.Text + "#" + "plot no.:" + txtPnum.Text + "#" + "portable water used:" + txtPWaterUsed.Text + "#" + "Portable water cost:" + Convert.ToString(P_Bill) + "#" + "waste water cost:" + Convert.ToString(W_Bill) + "#" + "vat:" + vat + "#" + "total:" + Convert.ToString(total)+"#");
                Log.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("billing.txt");
            string[] columnnames = file.ReadLine().Split('#');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;
        }
    }
}

