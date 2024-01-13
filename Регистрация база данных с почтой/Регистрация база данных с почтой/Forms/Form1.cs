using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Регистрация_база_данных_с_почтой.Forms;
using Label = System.Windows.Forms.Label;

namespace Регистрация_база_данных_с_почтой
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            if(Properties.Settings.Default.Registr==false)
            {                
                dataGridView1.Visible = false;
               
                new_label();
            }
            else
            {               
                dataGridView1.Visible = true;
               
            }

                    
           
           
        }
        public void new_label()
        {
            float fonts = 25f;
            Label lb = new Label();
            lb.ForeColor = Color.Red;
            lb.Text = "Вы не зарегистрированы!";
            lb.Font = new Font(lb.Font.FontFamily, fonts, lb.Font.Style);
            lb.Location = new Point(53, 101);
            lb.Size = new Size(431, 39);
            this.Controls.Add(lb);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "database4DataSet.table1". При необходимости она может быть перемещена или удалена.
                this.table1TableAdapter.Fill(this.database4DataSet.table1);
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных!");
                
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm();
            add.Owner = this;
            add.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table1BindingSource.EndEdit();
            table1TableAdapter.Update(database4DataSet);            
        }
    }
}
