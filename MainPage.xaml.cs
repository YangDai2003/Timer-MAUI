using System.Diagnostics;

namespace Timer
{
    public partial class MainPage : ContentPage
    {
        private bool isRunning = false;
        private TimeSpan currentTime;
        private Stopwatch stopwatch;

        public MainPage()
        {
            InitializeComponent();
            currentTime = TimeSpan.Zero;
            UpdateTimeDisplay(currentTime);
            stopwatch = new Stopwatch();
        }

        [Obsolete]
        private void StartPauseButton_Clicked(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startPauseButton.Text = "Pause";
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }
                Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    currentTime = stopwatch.Elapsed;
                    UpdateTimeDisplay(currentTime);
                    return isRunning;
                });
            }
            else
            {
                isRunning = false;
                startPauseButton.Text = "Start";
                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                }
            }
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            isRunning = false;
            startPauseButton.Text = "Start";
            currentTime = TimeSpan.Zero;
            UpdateTimeDisplay(currentTime);
            stopwatch.Reset();
        }

        private void UpdateTimeDisplay(TimeSpan time)
        {
            hourLabel.Text = time.Hours.ToString("D2");
            minuteLabel.Text = time.Minutes.ToString("D2");
            secondLabel.Text = time.Seconds.ToString("D2");
        }
    }
}
