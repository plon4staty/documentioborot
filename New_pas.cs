﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class New_pas : Form
    {
        DataBase DataBase = new DataBase();
        public New_pas()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button1.Enabled = false;
            textBox2.UseSystemPasswordChar = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.OpenConnection();
            var login = textBox1.Text;
            var password = textBox2.Text;

            var changequery = $"update users set password = '{password}' where login = '{login}'";

            var command = new SqlCommand(changequery, DataBase.GetConnection());

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно изменили пароль");
                textBox1.Text = "";
                textBox2.Text = "";
                Form1 frm = new Form1();
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Произошла ошибка");
            }
            DataBase.CloseConnection();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 15 & textBox2.Text.Contains("@") & textBox2.Text.Contains("#") & textBox2.Text.Contains("%") & textBox2.Text.Contains("(") & textBox2.Text.Contains(")") & textBox2.Text.Contains(".") & textBox2.Text.Contains("<"))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void New_pas_Load(object sender, EventArgs e)
        {

        }
    }
}
