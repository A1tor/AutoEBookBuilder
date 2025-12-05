using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEBookBuilder
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DbLoader.isValidId(textBox1.Text, false))
            {
                this.Close();
            }
            else
            {
                label2.Text = "Несуществующий код";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DbLoader.isValidId(textBox1.Text, true))
            {
                label2.Text = "Код создан";
            }
            else
            {
                label2.Text = "Некорректный код";
            }
        }
    }
}
