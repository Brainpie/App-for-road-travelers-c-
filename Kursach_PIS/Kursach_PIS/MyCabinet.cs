using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Kursach_PIS
{
    public partial class MyCabinet : FormSample
    {
        public MyCabinet()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MyCabinet_Load(object sender, EventArgs e)
        {
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label10.Left = (this.ClientSize.Width - label10.Width) / 2 - 70;
            label17.Left = (this.ClientSize.Width - label17.Width) / 2 + 60;
            label18.Left = (this.ClientSize.Width - label18.Width) / 2 + 70;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 - 70;
            label4.Left = (this.ClientSize.Width - label4.Width) / 2 - 70;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2 - 70;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2 - 70;
            label7.Left = (this.ClientSize.Width - label7.Width) / 2 - 70;
            label14.Left = (this.ClientSize.Width - label14.Width) / 2 + 85;
            label15.Left = (this.ClientSize.Width - label15.Width) / 2 + 80;
            label16.Left = (this.ClientSize.Width - label16.Width) / 2 + 60;
            label13.Left = (this.ClientSize.Width - label13.Width) / 2 + 105;
            label2.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
            var client = new RestClient("https://localhost:7122/api/Client");
            var request = new RestRequest($"{Class1.login}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var json = JArray.Parse(jsonText);
           
            label18.Text = (string)json[0]["surname"];
            label17.Text = (string)json[0]["name"];
            label16.Text = (string)json[0]["lastname"];
            label15.Text = ((DateTime)json[0]["dateborn"]).ToString("dd/MM/yyyy");
            label14.Text = (string)json[0]["number"];
            label13.Text = (string)json[0]["pasport"];

        }

        private void городаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            City city = new City();
            this.Enabled = false;
            city.Show();
        }

        private void покупаБилетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new Ticket());
        }

        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyyTickets());
        }

        private void списокГородовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new City());
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
