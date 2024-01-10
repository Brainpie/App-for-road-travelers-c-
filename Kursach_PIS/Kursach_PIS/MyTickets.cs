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
    public partial class MyTickets : FormSample
    {
        public MyTickets()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            Class1.Data1 = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            Class1.NameC1 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Class1.Data2 = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            Class1.NameC2 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            formManager.FormOpen(new Review());
        }

        private void MyTickets_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7121/api/Tiket");
            var request = new RestRequest($"{Class1.login}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<List<TicketData>>(jsonText);
            dataGridView1.DataSource = result;
            dataGridView1.Columns[0].HeaderText = "Действие";
            dataGridView1.Columns[1].HeaderText = "Дата отправления";
            dataGridView1.Columns[2].HeaderText = "Город отправления";
            dataGridView1.Columns[3].HeaderText = "Дата прибытия";
            dataGridView1.Columns[4].HeaderText = "Город прибытия";
            dataGridView1.Columns[5].HeaderText = "Цена";
            dataGridView1.Columns[6].HeaderText = "Тип транспорта";
            dataGridView1.Columns[7].HeaderText = "Имя";
            dataGridView1.Columns[8].HeaderText = "Фамилия";
            dataGridView1.Columns[9].HeaderText = "Отчество";
            dataGridView1.Columns[10].HeaderText = "Дата рождения";
            dataGridView1.Columns[11].HeaderText = "Номер телефона";
            dataGridView1.Columns[12].HeaderText = "Паспорт";
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

        private void моиОтзывыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyReviews());
        }

        private void моиОценкиМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyGrades());
        }
    }
}
