using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1.AsyncFallaciesPart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int before = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(100);

            int after = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
