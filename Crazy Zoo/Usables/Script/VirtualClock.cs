using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Crazy_Zoo.Usables.Script
{
    public class VirtualClock
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        //hours and minutes
        int[] curTime = new int[2] { 12, 0 };
        public EventHandler<int[]>? timeChange;

        public VirtualClock(int h =0, int m =0, int s =1)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(h,m,s);
        }

        public void startClock()
        {
            dispatcherTimer.Start();
        }
        public void stopClock()
        {
            dispatcherTimer.Stop();
        }

        public string GetTimeText()
        {
            string timeText = "";
            if (curTime[0] < 10)
            {
                timeText += "0";
            }
            timeText += curTime[0].ToString() + ":";

            if (curTime[1] < 10)
            {
                timeText += "0";
            }
            timeText += curTime[1].ToString();
            return timeText;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int increacer = 25; // seconds per tick (please, do not place higher than 60)
            int span = 0;

            curTime[1] += increacer;
            if (curTime[1] >= 60)
            {
                span = curTime[1] - 60;
                curTime[0]++;
                curTime[1] = 0;
                if (curTime[0] >= 24)
                {
                    curTime[0] = 0;
                }
            }
            curTime[1] += span;

            timeChange?.Invoke(this, curTime);
        }
    }
}
