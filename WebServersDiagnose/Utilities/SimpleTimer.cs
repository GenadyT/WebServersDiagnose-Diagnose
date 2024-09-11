using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WebServersManager.Utilities
{
    public class SimpleTimer : IDisposable
    {
        private System.Timers.Timer aTimer = null;
        private Action<string> timeHandler;

        public SimpleTimer(Action<string> timeHandler) 
        {
            if (timeHandler == null)
            {
                throw new ArgumentException("Timer handler is null");
            }
            
            this.timeHandler = timeHandler;
            initTimer();
        }

        public void Start(double interval)
        {
            aTimer.Interval = interval;
            aTimer.Start();
        }

        public void Stop()
        {
            aTimer.Stop();
        }

        private void initTimer()
        {
            aTimer = new System.Timers.Timer();
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Stop();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            /*Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);*/

            timeHandler("Yes");
        }

        public void Dispose()
        {
            aTimer.Dispose();
        }

        ~SimpleTimer()
        {
            Dispose();
        }
    }
}
