using Newtonsoft.Json;
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
    public partial class MyGrades : FormSample
    {
        public MyGrades()
        {
            InitializeComponent();
        }

        private void MyGrades_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            dataGridView1.Left = (this.ClientSize.Width - dataGridView1.Width) / 2;
            label1.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
            var client = new RestClient("https://localhost:7626/api/Grades");
            var request = new RestRequest($"{Class1.login}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<List<GradeData>>(jsonText);
            dataGridView1.DataSource = result;
            dataGridView1.Columns[0].HeaderText = "Место";
            dataGridView1.Columns[1].HeaderText = "Оценка";
            dataGridView1.Columns[3].HeaderText = "Город отправления";
            dataGridView1.Columns[2].HeaderText = "Дата отправления";
            dataGridView1.Columns[5].HeaderText = "Город прибытия";
            dataGridView1.Columns[4].HeaderText = "Дата прибытия";
            dataGridView1.Columns[6].HeaderText = "Имя";
            dataGridView1.Columns[7].HeaderText = "Фамилия";
            dataGridView1.Columns[8].HeaderText = "Отчество";
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

        private void моиОтзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyyReviews());
        }

        private void моиОценкиМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyGrades());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
