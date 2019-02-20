using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internals.SynchronizationContext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void OnAwaitButtonClicked(object sender, EventArgs e)
        {
            Await.Text = "Hello";
            await AsyncComputation(2000);
            Await.Text = "World!";
        }

        private void OnWaitButtonClicked(object sender, EventArgs e)
        {
            Wait.Text = "Hello";
            AsyncComputation(2000).Wait();
            Wait.Text = "World!";
        }

        static async Task<int> AsyncComputation(int waitTime)
        {
            await Task.Delay(waitTime);
            return 42;
        }
    }
}
