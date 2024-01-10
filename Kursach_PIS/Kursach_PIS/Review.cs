using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_PIS
{
    public partial class Review : FormSample
    {
        public Review()
        {
            InitializeComponent();
        }

        private void личныйКабинетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyCabinet());
        }

        private void списокГородовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new City());
        }

        private void покупаБилетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new Ticket());
        }

        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyTickets());
        }

        private void Review_Load(object sender, EventArgs e)
        {
            label2.Text = Class1.Data1.ToString("dd/MM/yyyy");
            label7.Text = Class1.NameC1;
            label4.Text = Class1.Data2.ToString("dd/MM/yyyy");
            label5.Text = Class1.NameC2;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7525");
            var request = new RestRequest("api/Reviews/", Method.Post);
            request.RequestFormat = DataFormat.Json;
            /*string CityFrom = Class1.NameC1;
            DateTime DateFrom = Class1.Data1;
            string CityTo = Class1.NameC2;
            DateTime DateTo = Class1.Data2;
            string Comment = textBox2.Text;
            int Rate = Convert.ToInt32(comboBox1.SelectedItem);
            int ClientID = Class1.login;*/

            request.AddBody(new
            {
                CityFrom = Class1.NameC1,
                DateFrom = Class1.Data1,
                CityTo = Class1.NameC2,
                DateTo = Class1.Data2,
                Comment = textBox2.Text,
                Rate = Convert.ToInt32(comboBox1.SelectedItem),
                ClientID = Class1.login
            });

            label13.Visible = true;
            //RestResponse response = client.Execute(request);
        }

        private void моиОтзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyReviews());
        }
    }
}
