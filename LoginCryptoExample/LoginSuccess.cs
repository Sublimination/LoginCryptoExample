using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCryptoExample
{
    public partial class LoginSuccess : Form
    {
        public LoginSuccess()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "Successful Login";
            button1.Text = "Close";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
