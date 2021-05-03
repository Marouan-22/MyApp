using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class TimerPage : ContentPage
    {
        Stopwatch stopwatch;
        public TimerPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();

            lblStopwatch.Text = "00:00:00.00000";
        }

        private void btnStart_Clicked(object sender, System.EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();
                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }

        private void btnStop_Clicked(object sender, EventArgs e)
        {
            btnStart.Text = "Resume";
            stopwatch.Stop();
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch.Text = "00:00:00.00000";
            btnStart.Text = "Start";
            stopwatch.Reset();
        }
    }
}
