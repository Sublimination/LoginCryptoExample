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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label1.Text = "User Name";
            label2.Text = "Password";
            button1.Text = "Login";
            button2.Text = "Create User";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = "";
            string storedHash = "";
            string currentUser = textBox1.Text;
            string plainTextPassword = textBox2.Text;
            
            if (currentUser == "" || plainTextPassword == "")
            {
                MessageBox.Show("Some data missing. Try again!");
                textBox1.Text = "";
                textBox2.Text = "";
            }

            SqlConnection dbConnect = new SqlConnection("Data Source=.\\SQLExpress;AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL12.SQLEXPRESS\\MSSQL\\DATA\\LoginExample.mdf;Database=LoginExample;Trusted_Connection=Yes;");
            {
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT FirstName, Hash FROM Login WHERE Username = @currentUser", dbConnect);
                    myCommand.Parameters.AddWithValue("@currentUser", currentUser);
                   
                    dbConnect.Open();
                    myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            firstName = myReader.GetString(0);
                            storedHash = myReader.GetString(1);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("User Not Found");
                    }

                }
                catch (Exception z)
                {
                    MessageBox.Show(z.ToString());
                }
                finally
                {
                    dbConnect.Close();
                }
                if (PasswordHash.PasswordHash.ValidatePassword(plainTextPassword, storedHash))
                {
                    MessageBox.Show("Passwords Match!! :) ");
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("Passwords DO NOT Match!! :) ");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
            
        }
    }
    
                
}
