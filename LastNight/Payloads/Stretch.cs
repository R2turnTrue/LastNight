using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace LastNight.Payloads
{
    public class Stretch
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        public void StretchFunc()
        {
            IntPtr upWnd = GetDesktopWindow();
            IntPtr upHdc = GetDC(upWnd);
            IntPtr desktop = GetDC(IntPtr.Zero);
            int xs = GetSystemMetrics(0); //SM_CXSCREEN
            int ys = GetSystemMetrics(1); //SM_CYSCREEN

            StretchBlt(upHdc, 0, 0, xs, ys, upHdc, 0, 0, xs, ys, 0x00CC0020);
        }
        public void StretchFuncT()
        {
            IntPtr upWnd = GetDesktopWindow();
            IntPtr upHdc = GetDC(upWnd);
            IntPtr desktop = GetDC(IntPtr.Zero);
            int xs = GetSystemMetrics(0); //SM_CXSCREEN
            int ys = GetSystemMetrics(1); //SM_CYSCREEN

            StretchBlt(upHdc, 50, 50, xs - 100, ys - 100, upHdc, 0, 0, xs, ys, 0x00CC0020);
        }

        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(60000);
                Thread thr2 = new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(20000);
                    StretchFuncT();
                }));
                while (true)
                {
                    StretchFunc();
                    Thread.Sleep(10);
                }
            }));
            thr.Start();
        }
    }
}
