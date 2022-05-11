using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordMessenger;
using DiscordWebhookSender;

namespace DiscordWebhookSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int mouseX, mouseY;
        public static void webhookYolla(string wbURL,string json)
        {
            var req = WebRequest.Create(wbURL);
            req.ContentType = "application/json";
            req.Method = "POST";
            using (var writer = new StreamWriter(req.GetRequestStream()))
                writer.Write(json);
            req.GetResponse();

        }
        int discordcolor = 1;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DiscordMessage()
                .SetUsername("Ex-DF Webhook-Sender")
                .SetAvatar("https://static-cdn.jtvnw.net/jtv_user_pictures/f2ca0d32-1809-4057-af22-d32a3f0b02fb-profile_banner-480.jpeg")
                .AddEmbed()
                .SetTimestamp(DateTime.Now)
                .SetImage(textBox2.Text)
                .SetTitle(textBox1.Text)
                .SetDescription(textBox3.Text)
                .SetColor(1)
                .SetFooter("Made by ExDF")
                .Build()
                .SendMessage(textBox5.Text);

            var message = new DiscordMessage
            {
                Content = "Ehehehe",
                Embeds = new List<Embed>()
                     {
                         new Embed
                         {
                             Description="Ehehehe"
                         }
                     }
            };
            

        }
    }
}
