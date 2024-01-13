using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Регистрация_база_данных_с_почтой.Forms
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        public int kod;
        public bool regis = false;
        public static string adres;
        public bool zareg=false;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                generetion();
                otpavka();                
                Verification ver = new Verification();
                adres = textBox3.Text;
                ver.Owner = this;
                ver.Show();
                
                
                    DataRow nRow = main.database4DataSet.Tables[0].NewRow();
                    int rc = main.dataGridView1.RowCount + 1;
                    nRow[0] = rc;
                    nRow[1] = textBox1.Text;
                    nRow[2] = textBox2.Text;
                    nRow[3] = textBox3.Text;
                    main.database4DataSet.Tables[0].Rows.Add(nRow);
                    main.table1TableAdapter.Update(main.database4DataSet.table1);
                    main.database4DataSet.Tables[0].AcceptChanges();
                    main.dataGridView1.Refresh();
                
                
                                                               
            }
           
        }
       private void generetion()
        {
            Random rand = new Random();
            int value=rand.Next(0,999);
            kod = value;
        }

        private void otpavka()
        {
            MailAddress fromAdres = new MailAddress("pavel.c.net@mail.ru", "Подтверждение адреса электронной почты");
            MailAddress toAdres = new MailAddress(textBox3.Text);
            MailMessage message = new MailMessage(fromAdres, toAdres);
            SmtpClient smtpClient = new SmtpClient();
            try
            {

                message.Body = "Ваш код подтверждения: "+ kod;                        
                message.Subject = "Подтверждение адреса почты";                               
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Приложение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                smtpClient.Host = "smtp.mail.ru";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromAdres.Address, "yLZ6KxhNiBRCttsngEeB");
                smtpClient.Send(message);
            }
            catch
            {
                MessageBox.Show("Ошибка протокола!", "Приложение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

             
        }
    }
}
