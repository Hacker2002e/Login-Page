using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;

namespace Login_Page
{
    public partial class FrmLogin : Form
    {
        private bool isLoginLegal = false;
        private bool isPasswordLegal = false;
        private bool doPasswordsMatch = false;

        private Random random = new Random();
        private string captcha = "";

        internal void UpdateCaptcha()
        {
            string captcha = "";
            for (int i = 0; i < random.Next(6, 10); i++)
            {
                if (random.Next(2) % 2 == 0)
                {
                    captcha += char.ConvertFromUtf32(random.Next(65, 91));
                    continue;
                }
                captcha += random.Next(0, 10).ToString();
            }
            this.captcha = captcha;
            labelCaptcha.Text = captcha;
        }

        public FrmLogin()
        {
            InitializeComponent();
        }
    





        private void FrmLogin_Load(object sender, EventArgs e)
        {
            UpdateCaptcha();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (textBoxCaptcha.Text==captcha)
            {
                AccountManager.Register(txtUsername.Text, txtPassword.Text);
                MessageBox.Show("Account created successfully!",
                    "Register success!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Captcha is incorrect! Try again","Captcha failure!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            UpdateCaptcha();
            textBoxCaptcha.Text = "";
            textBoxCaptcha.Focus();

         

          

        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';

            }
        }

        private void btn_Rclear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
            labelCaptcha.Text = "";
            UpdateCaptcha();
        }

        private void linklbl_reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SetCancelButton(Button button1)
        {
            this.CancelButton = button1;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateCaptcha();
        }
    }
}
