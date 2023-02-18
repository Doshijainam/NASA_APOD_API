using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace NASA_APOD
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://api.nasa.gov/planetary/apod";
            string api_key = "eBsR4tngUVTn1n35m7cNJhHV7Unavw8jZq6xawGl";
            var client = new RestClient(url);
            var request = new RestRequest(url,Method.Get);
            request.AddParameter("api_key", api_key);

            var response = client.Execute(request);
            var apod = JsonConvert.DeserializeObject<dynamic>(response.Content);

            string imageUrl = apod.url;
            string explanation = apod.explanation;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(imageUrl);
                using (var ms = new MemoryStream(imageBytes))
                {
                    // Display the image in the PictureBox conrol
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }

            textBox1.Text = explanation;

        }
    }
}
