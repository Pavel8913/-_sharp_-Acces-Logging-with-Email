using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Регистрация_база_данных_с_почтой.Database4DataSetTableAdapters;

namespace Регистрация_база_данных_с_почтой.Forms
{
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
            
        }
        int a;
       
        public void button1_Click(object sender, EventArgs e)
        {
            AddForm Add = this.Owner as AddForm;
            if (Add != null)
            {
                a = Convert.ToInt32(textBox1.Text);
                if (a == Add.kod)
                {
                    MessageBox.Show("Успех!");
                    Add.regis = true;
                    Add.zareg=true;
                    Properties.Settings.Default.Registr = true;
                    Properties.Settings.Default.Save();
                    
                    AddForm addForm = new AddForm();
                    addForm.Close();
                    Verification verification = new Verification();
                    verification.Close();
                    Form1 f = new Form1();
                    f.Close();
                    Form1 form1 = new Form1();  
                    form1.Show();
                    
                }
                else
                {
                    MessageBox.Show("Неверный код!");
                }

                    }
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            label1.Text += AddForm.adres;
        }
    }
}
