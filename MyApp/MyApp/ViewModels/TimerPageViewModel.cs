using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class TimerPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Stopwatch stopwatch = new Stopwatch();
        private string _stopWatchHours;
        private string _stopWatchMinutes;
        private string _stopWatchSeconds;
        public TimerPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Timer";

            Start = new Command(OnStartTimerExecute);
            Stop = new Command(OnStop);
            Reset = new Command(onReset);

            StopWatchHours = stopwatch.Elapsed.Hours.ToString();
            StopWatchMinutes = stopwatch.Elapsed.Minutes.ToString();
            StopWatchSeconds = stopwatch.Elapsed.Seconds.ToString();
        }

        public string StopWatchHours
        {
            get { return _stopWatchHours; }
            set { _stopWatchHours = value; OnPropertyChanged("StopWatchHours"); }
        }
        public string StopWatchMinutes
        {
            get { return _stopWatchMinutes; }
            set { _stopWatchMinutes = value; OnPropertyChanged("StopWatchMinutes"); }
        }
        public string StopWatchSeconds
        {
            get { return _stopWatchSeconds; }
            set { _stopWatchSeconds = value; OnPropertyChanged("StopWatchSeconds"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }
        public ICommand Reset { get; set; }
        private void OnStartTimerExecute()
        {

            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                StopWatchHours = stopwatch.Elapsed.Hours.ToString();
                StopWatchMinutes = stopwatch.Elapsed.Minutes.ToString();
                StopWatchSeconds = stopwatch.Elapsed.Seconds.ToString();
                return true;
            });

        }
        private void OnStop()
        {
            stopwatch.Stop();
        }
        private void onReset()
        {
            stopwatch.Reset();
        }
    }    
}
