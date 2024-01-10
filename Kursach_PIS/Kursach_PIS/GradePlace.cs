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
    public partial class GradePlace : FormSample
    {
        public GradePlace()
        {
            InitializeComponent();
        }

        private void GradePlace_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label10.Left = (this.ClientSize.Width - label10.Width) / 2 - 200;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 - 200;
            label17.Left = (this.ClientSize.Width - label17.Width) / 2 - 100;
            label18.Left = (this.ClientSize.Width - label18.Width) / 2 - 100;
            label9.Left = (this.ClientSize.Width - label9.Width) / 2 - 230;
            label12.Left = (this.ClientSize.Width - label12.Width) / 2 - 200;
            label13.Left = (this.ClientSize.Width - label13.Width) / 2 + 150;
            label15.Left = (this.ClientSize.Width - label15.Width) / 2 + 170;
            label16.Left = (this.ClientSize.Width - label16.Width) / 2 + 170;
            label4.Left = (this.ClientSize.Width - label4.Width) / 2 + 80;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2 + 80;
            textBox2.Left = (this.ClientSize.Width - textBox2.Width) / 2 - 50;
            comboBox1.Left = (this.ClientSize.Width - comboBox1.Width) / 2 - 95;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
            label17.Text = Class1.Data1.ToString("dd/MM/yyyy");
            label18.Text = Class1.NameC1;
            label15.Text = Class1.Data2.ToString("dd/MM/yyyy");
            label16.Text = Class1.NameC2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7626");
            var request = new RestRequest("api/Grades/", Method.Post);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                Place = textBox2.Text,
                Rate = Convert.ToInt32(comboBox1.SelectedItem),
                CityFrom = Class1.NameC1,
                DateFrom = Class1.Data1,
                CityTo = Class1.NameC2,
                DateTo = Class1.Data2,
                ClientID = Class1.login
            });
            RestResponse response = client.Execute(request);
            label13.Visible = true;
            button1.Enabled = false;
        }

        private void моиОценкиМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyGrades());
        }

        private void моиОтзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyyReviews());
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
            formManager.FormOpen(new MyyTickets());
        }
    }
}
