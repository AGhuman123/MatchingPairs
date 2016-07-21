using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String username = usernameText.Text;
            String password = passwordText.Text;
            String temp = null;
            int res = 0;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Work Preperation\MatchingPairs\MatchingPairs\Database1.mdf;Integrated Security=True;";
            conn.Open(); 
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Password FROM UserTable WHERE Username='" + username + "'";
            OleDbDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                //result.Text = "Password Correct. Login Succesful";

            }
            else
            {
                //result.Text = "Password field cannot be blank";
            }
            conn.Close();
        
        Form1 myForm = new Form1();
            myForm.Show();
        }
    }
}
