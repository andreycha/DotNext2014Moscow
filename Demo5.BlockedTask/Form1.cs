using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo5.BlockedTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Waiting";
            DelayAsync().Wait();
            label1.Text = "Waiting completed";
        }

        private async Task DelayAsync()
        {
            await Task.Delay(2000);
        }
    }
}
