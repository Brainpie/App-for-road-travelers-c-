using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursach_PIS
{
    public partial class Form1 : FormSample
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void личныйКабинетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyCabinet mycabinet = new MyCabinet();
            this.Enabled = false;
            mycabinet.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string name = textBox2.Text;
            string lastname = textBox3.Text;
            DateTime dateborn = Convert.ToDateTime(textBox4.Text);
            string number = textBox5.Text;
            string pasport = textBox6.Text;
            string password = textBox8.Text;
            Class1.login = textBox7.Text;
            var client = new RestClient("https://localhost:7122");
            var request = new RestRequest("api/Client/", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                Name = name,
                Surname = surname,
                Lastname = lastname,
                Dateborn = dateborn,
                Number = number,
                Pasport = pasport,
                Password = password,
                Login = Class1.login
            });
            RestResponse response = client.Execute(request);

            formManager.FormOpen(new MyCabinet());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2 - 100;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 - 100;
            label4.Left = (this.ClientSize.Width - label4.Width) / 2 - 100;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2 - 100;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2 - 100;
            label7.Left = (this.ClientSize.Width - label7.Width) / 2 - 100;
            label8.Left = (this.ClientSize.Width - label8.Width) / 2 - 100;
            label9.Left = (this.ClientSize.Width - label9.Width) / 2 - 100;
            label10.Left = (this.ClientSize.Width - label10.Width) / 2;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2 + 100;
            textBox2.Left = (this.ClientSize.Width - textBox2.Width) / 2 + 100;
            textBox3.Left = (this.ClientSize.Width - textBox3.Width) / 2 + 100;
            textBox4.Left = (this.ClientSize.Width - textBox4.Width) / 2 + 100;
            textBox5.Left = (this.ClientSize.Width - textBox5.Width) / 2 + 100;
            textBox6.Left = (this.ClientSize.Width - textBox6.Width) / 2 + 100;
            textBox7.Left = (this.ClientSize.Width - textBox7.Width) / 2 + 100;
            textBox8.Left = (this.ClientSize.Width - textBox8.Width) / 2 + 100;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
     
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
        }

        private void списокГородовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            City city = new City();
            this.Enabled = false;
            city.Show();
        }

        private void покупаБилетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new Ticket());
        }

        private void списокГородовToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            City city = new City();
            this.Enabled = false;
            city.Show();
        }

        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTickets mytickets = new MyTickets();
            this.Enabled = false;
            mytickets.Show();
        }
    }
}
