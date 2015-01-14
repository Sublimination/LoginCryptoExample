using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginCryptoExample
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
            label1.Text = "Name";
            label2.Text = "Username";
            label3.Text = "Password";
            button1.Text = "Create User";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string userName = textBox2.Text;
            string password = textBox3.Text;

            if (name == "" || userName == "" || password == "")
            {
                MessageBox.Show("Some data missing. Try again!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            string hashedPassword = PasswordHash.PasswordHash.CreateHash(password);
            

            SqlConnection dbConnect = new SqlConnection("Data Source=.\\SQLExpress;AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL12.SQLEXPRESS\\MSSQL\\DATA\\LoginExample.mdf;Database=LoginExample;Trusted_Connection=Yes;");
            {
                SqlCommand dbInsert = new SqlCommand("Insert into Login(FirstName, Username, Hash)values(@FirstName, @UserName, @Hash)", dbConnect);

                dbInsert.Parameters.AddWithValue("@FirstName", name);
                dbInsert.Parameters.AddWithValue("@UserName", userName);
                dbInsert.Parameters.AddWithValue("@Hash", hashedPassword);
          
                dbConnect.Open();

                dbInsert.ExecuteNonQuery();

                dbConnect.Close();

                MessageBox.Show("Added new user.\n\nClick OK to close.");
                this.Close();
                
            }

        }
    }
}
