using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kursach_PIS
{
    public partial class Ticket : FormSample
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label2.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2 - 200;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 + 100;
            label4.Left = (this.ClientSize.Width - label4.Width) / 2 + 100;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2 - 200;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2 - 200;
            label7.Left = (this.ClientSize.Width - label7.Width) / 2 - 200;
            label8.Left = (this.ClientSize.Width - label8.Width) / 2 + 170;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2 - 100;
            textBox2.Left = (this.ClientSize.Width - textBox2.Width) / 2 - 100;
            comboBox1.Left = (this.ClientSize.Width - comboBox1.Width) / 2 - 100;
            comboBox2.Left = (this.ClientSize.Width - comboBox2.Width) / 2 + 200;
            dateTimePicker1.Left = (this.ClientSize.Width - dateTimePicker1.Width) / 2 - 100;
            dateTimePicker2.Left = (this.ClientSize.Width - dateTimePicker2.Width) / 2 + 200;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            menuStrip1.BackColor = Color.Transparent;
            var client = new RestClient("https://localhost:7123/api/City");
            var request = new RestRequest();
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var result = JsonConvert.DeserializeObject<List<CityData>>(jsonText);

            result.ForEach(x =>
            {
                comboBox1.Items.Add(x.Name);
                comboBox2.Items.Add(x.Name);
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameCity1 = comboBox1.SelectedItem.ToString();
            string nameCity2 = comboBox2.SelectedItem.ToString();
            DateTime date1 = dateTimePicker1.Value.Date;
            DateTime date2 = dateTimePicker2.Value.Date;
            int price = Convert.ToInt32(textBox1.Text);
            string typetransport = textBox2.Text;

            //Получение id города отправления по названию
            var client1 = new RestClient("https://localhost:7123/api/City");
            var request1 = new RestRequest($"{nameCity1}");
            RestResponse response1 = client1.Execute(request1);

            var jsonText1 = response1.Content.ToString();
            var json1 = JArray.Parse(jsonText1);

            int city1 = (int)json1[0]["id"];

            //Получение id города прибытия по названию
            var request2 = new RestRequest($"{nameCity2}");
            RestResponse response2 = client1.Execute(request2);

            var jsonText2 = response2.Content.ToString();
            var json2 = JArray.Parse(jsonText2);

            int city2 = (int)json2[0]["id"];
            string LoginClient = Class1.login;

            var client = new RestClient("https://localhost:7121");
            var request = new RestRequest("api/Tiket/", Method.Post);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                Data1 = date1,
                CityId1 = city1,
                CityName1 = nameCity1,
                Data2 = date2,
                CityId2 = city2,
                CityName2 = nameCity2,
                Price = price,
                Typetransport = typetransport,
                LoginClient = Class1.login
            });
            RestResponse response = client.Execute(request);
            label8.Visible = true;
            button1.Enabled = false;
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new Form1());
        }

        private void списокГородовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new City());
        }

        private void покупкаБилетаToolStripMenuItem_Click(object sender, EventArgs e)
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
