using System;
using System.Threading;
using System.Windows.Forms;

namespace Data_Monitor_GUI
{
    class Timer
    {
        private Main main;
        private long endTimeMillis;
        private Thread t;

        public Timer(long endTimeMillis, Main main)
        {
            this.main = main;
            this.endTimeMillis = endTimeMillis;
            ThreadStart ts = new ThreadStart(timer);
            t = new Thread(ts);
            t.IsBackground = true;
            t.Start();
        }

        // Main method that runs the timer.
        private void timer()
        {
            long tick = (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds;
            update();

            while ((long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds < endTimeMillis)
            {
                // Updates the timer label every second.
                if ((long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds - tick >= 1000)
                {
                    update();
                    tick = (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds;
                }
            }

        }

        // Returns the timer in the correct format given the time left in milliseconds.
        private String formatTimer(long millis)
        {
            millis /= 1000;
            int temp;
            String output = "";

            temp = (int)(millis / 3600);
            if (temp < 10) output += "0" + temp;
            else output += temp;
            temp = (int)(millis / 60 % 60);
            if (temp < 10) output += ":0" + temp;
            else output += ":" + temp;
            temp = (int)(millis % 60);
            if (temp < 10) output += ":0" + temp;
            else output += ":" + temp;

            return output;
        }

        // Stop the timer and reset the display.
        public void stop()
        {
            if(main.IsHandleCreated)
                main.timerLabel.BeginInvoke((MethodInvoker)delegate
                {
                    main.timerLabel.Text = "00:00:00";
                    
                });
            if (t != null) t.Abort();
        }

        private void update()
        {
            if(main.IsHandleCreated)
                main.timerLabel.BeginInvoke((MethodInvoker)delegate
                {
                    main.timerLabel.Text = formatTimer(endTimeMillis - (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds);
                });
        }
    }
}
