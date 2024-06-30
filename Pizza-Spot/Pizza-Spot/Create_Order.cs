using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication8
{
    public partial class Create_Order : Form
    {
        
        public Create_Order()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter de;
        DataSet ds;

        private void Create_Order_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Mahdev\\Documents\\pizza_spot.accdb");
            panel1.Hide();
            this.Hide();
            label5.Hide();
            this.Hide();
            label6.Hide();
            this.Hide();
            button2.Hide();
            this.Hide();
        }
        int total = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
            {
                if (radioButton4.Checked) 
                {
                    total += 1000;
                }
                else if (radioButton5.Checked)
                {
                    total += 1000;
                }
                else if (radioButton6.Checked)
                {
                    total += 1000;
                }
            }
            if (radioButton2.Checked)
            {
                if (radioButton4.Checked)
                {
                    total += 750;
                }
                else if (radioButton5.Checked)
                {
                    total += 750;
                }
                else if (radioButton6.Checked)
                {
                    total += 750;
                }
            }
            if (radioButton3.Checked)
            {
                if (radioButton4.Checked)
                {
                    total += 500;
                }
                else if (radioButton5.Checked)
                {
                    total += 500;
                }
                else if (radioButton6.Checked)
                {
                    total += 500;
                }
            }
            string insert = "INSERT INTO customer_order(Name,Contact,Address,Size_Flavour,Total_Bill)Values(@name, @contact, @address, @size_flavour, @total_bill)";
            cmd = new OleDbCommand(insert,con);
            cmd.Parameters.AddWithValue("@name",textBox1.Text);
            cmd.Parameters.AddWithValue("@contact", textBox2.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@size_flavour", textBox4.Text);
            cmd.Parameters.AddWithValue("@total_bill", total);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            label6.Text = total.ToString();
            button1.Hide();
            this.Hide();
            label10.Hide();
            textBox4.Hide();
            button2.Show();
            label5.Show();
            this.Show();
            label6.Show();
            this.Show();
            MessageBox.Show("Successfully Ordered");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
            this.Show();
            de = new OleDbDataAdapter("SELECT * FROM customer_order",con);
            ds = new DataSet();
            con.Open();
            de.Fill(ds, "customer_order");
            dataGridView1.DataSource = ds.Tables["customer_order"];
            con.Close();
        }
    }
}
