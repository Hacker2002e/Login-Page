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
using System.Text.RegularExpressions;
using System.Security.Principal;

namespace Login_Page
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Account signedInAcc = AccountManager.Login(txtUsername.Text, txtPassword.Text);
            if (signedInAcc == null)
            {
                MessageBox.Show("User credentials are invalid!", "Sign in error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                return;
            }

            MessageBox.Show("You've successfully logged in!",
                "Login Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Lclear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
               
            }
            else
            {
                txtPassword.PasswordChar = '*';
             }
        }

        private void linklbl_log_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            bool isTextLegal = Regex.IsMatch(txtUsername.Text, @"[A-Za-z0-9-_]");

            bool isTextLongEnough = txtUsername.TextLength > 3 && txtUsername.TextLength < 21;

            if (!isTextLegal || !isTextLongEnough)
            {
                labelLoginFlavourText.Text = "Login must be 4-20 alphanumeric letters, '_' or '-'";
                btn_log.Enabled = false;
            }
            else
            {
                labelLoginFlavourText.Text = "";
               btn_log.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}