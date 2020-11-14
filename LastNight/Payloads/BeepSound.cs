using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LastNight.Payloads
{
    public class BeepSound
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint dwFreq, uint dwDuration);

        int p = 0;

        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                while (true) {

                    Beep(Convert.ToUInt32(new Random().Next(500, 800)), 100);

                    Thread.Sleep(100);
                }
            }));
            thr.Start();
        }
        
    }
}
