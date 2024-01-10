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
    public partial class MyReviews : FormSample
    {
        public MyReviews()
        {
            InitializeComponent();
        }

        private void MyReviews_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:7525/api/Reviews");
            var request = new RestRequest($"{Class1.login}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<List<ReviewsData>>(jsonText);
            dataGridView1.DataSource = result;
            dataGridView1.Columns[0].HeaderText = "Город отправления";
            dataGridView1.Columns[1].HeaderText = "Дата отправления";
            dataGridView1.Columns[2].HeaderText = "Город прибытия";
            dataGridView1.Columns[3].HeaderText = "Дата прибытия";
            dataGridView1.Columns[4].HeaderText = "Комментарий";
            dataGridView1.Columns[5].HeaderText = "Оценка";
            dataGridView1.Columns[6].HeaderText = "Имя";
            dataGridView1.Columns[7].HeaderText = "Фамилия";
            dataGridView1.Columns[8].HeaderText = "Отчество";
            dataGridView1.Columns[9].HeaderText = "Дата рождения";
            dataGridView1.Columns[10].HeaderText = "Номер телефона";
            dataGridView1.Columns[11].HeaderText = "Паспорт";
        }

        private void моиОценкиМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new MyGrades());
        }
    }
}
