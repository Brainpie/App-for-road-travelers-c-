using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_PIS
{
    public partial class Reviews : FormSample
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private void Reviews_Load(object sender, EventArgs e)
        {
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label10.Left = (this.ClientSize.Width - label10.Width) / 2 - 200;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 - 200;
            label17.Left = (this.ClientSize.Width - label17.Width) / 2 - 100;
            label18.Left = (this.ClientSize.Width - label18.Width) / 2 - 100;
            label4.Left = (this.ClientSize.Width - label4.Width) / 2 + 80;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2 + 80;
            label15.Left = (this.ClientSize.Width - label15.Width) / 2 + 170;
            label16.Left = (this.ClientSize.Width - label16.Width) / 2 + 170;
            label8.Left = (this.ClientSize.Width - label8.Width) / 2 + 150;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2 - 230;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2 - 220;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
            comboBox1.Left = (this.ClientSize.Width - comboBox1.Width) / 2 - 95;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label2.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;

            label17.Text = Class1.Data1.ToString("dd/MM/yyyy");
            label18.Text = Class1.NameC1;
            label15.Text = Class1.Data2.ToString("dd/MM/yyyy");
            label16.Text = Class1.NameC2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7525");
            var request = new RestRequest("api/Reviews/", Method.Post);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                CityFrom = Class1.NameC1,
                DateFrom = Class1.Data1,
                CityTo = Class1.NameC2,
                DateTo = Class1.Data2,
                Comment = textBox1.Text,
                Rate = Convert.ToInt32(comboBox1.SelectedItem),
                ClientID = Class1.login
            });
            RestResponse response = client.Execute(request);
            label8.Visible = true;
            button1.Enabled = false;
        }

        private void личныйКабинетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyCabinet());
        }

        private void списокГородовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new City());
        }

        private void пToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new Ticket());
        }

        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyyTickets());
        }

        private void моиОтзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyyReviews());
        }

        private void моиОценкиМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyGrades());
        }
    }
}
