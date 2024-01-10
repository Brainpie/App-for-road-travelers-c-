using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_PIS
{
    public partial class City : FormSample
    {
        public City()
        {
            InitializeComponent();
        }

        private void City_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            dataGridView1.Left = (this.ClientSize.Width - dataGridView1.Width) / 2;
            label1.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
            var client = new RestClient("https://localhost:7123/api/City");
            var request = new RestRequest();
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<List<CityData>>(jsonText);
            dataGridView1.DataSource = result;
            dataGridView1.Columns[0].HeaderText = "Название";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new AddsCity());
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
