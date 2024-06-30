using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApplication8
{
    class customer_data
    {
        OleDbConnection con;
        OleDbCommand cmd;
        public void connection() 
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Mahdev\\Documents\\pizza_spot.accdb");
        }
        public void CustomerData(TextBox n, TextBox c, TextBox a, int t)
        {
            string name = n.Text;
            string contact = c.Text;
            string address = a.Text;
            int total = Convert.ToInt32(t);

            OleDbCommand command = con.CreateCommand();
            
            try
            {
                con.Open();
                command.CommandText = "Insert Into customer_order(Name,Contact,Address,Total_Bill)Values('" + name + "','" + contact + "','" + address + "','" + total + "')";
                command.Connection = con;
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
