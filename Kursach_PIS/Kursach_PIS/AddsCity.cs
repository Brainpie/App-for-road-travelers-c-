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
    public partial class AddsCity : FormSample
    {
        public AddsCity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            var client = new RestClient("https://localhost:7123");
            var request = new RestRequest("api/City/", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                Name = name
            });
            RestResponse response = client.Execute(request);

            formManager.FormOpen(new City());
        }

        private void AddsCity_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label7.Left = (this.ClientSize.Width - label1.Width) / 2 - 100;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2 + 100;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button2.Left = (this.ClientSize.Width - button1.Width) / 2 + 400;
            label1.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formManager.FormOpen(new City());
        }
    }
}
