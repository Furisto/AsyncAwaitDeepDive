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

namespace Internals.AsyncExtensions
{
    public partial class Form1 : Form
    {
        private AsyncMultiRouter myRouter = new AsyncMultiRouter();

        public Form1()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            Button.Text = "Hello";

            await myRouter.SwitchToThreadPoolThread();
            Thread.Sleep(3000);

            await myRouter.SwitchToUIThread();
            Button.Text = "Await!";

            await myRouter.SwitchToMessageLoopThread();
            Thread.Sleep(3000);

            await myRouter.SwitchToUIThread();
            Button.Text = "!";
        }
    }
}
