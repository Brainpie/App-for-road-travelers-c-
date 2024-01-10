using Newtonsoft.Json.Linq;
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
    public partial class Autorization : FormSample
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2 + 170;
            label3.Left = (this.ClientSize.Width - label1.Width) / 2 - 180;
            label3.Top = (this.ClientSize.Height - label1.Height) / 2 + 300;
            label6.Left = (this.ClientSize.Width - label6.Width) / 2 - 110;
            label7.Left = (this.ClientSize.Width - label7.Width) / 2 - 110;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
            textBox2.Left = (this.ClientSize.Width - textBox2.Width) / 2;
            linkLabel1.Left = (this.ClientSize.Width - linkLabel1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            linkLabel1.BackColor = Color.Transparent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formManager.FormOpen(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.login = textBox1.Text;
            var client = new RestClient("https://localhost:7122/api/Client");
            var request = new RestRequest($"{Class1.login}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var json = JArray.Parse(jsonText);
            if (json.Count == 0)
            {
                label2.Visible = true;
            }
            else { formManager.FormOpen(new MyCabinet()); }
        }
    }
}
