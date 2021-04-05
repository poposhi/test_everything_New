using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace test_everything
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        long Last_second = DateTimeOffset.Now.ToUnixTimeSeconds();
        DateTime time = DateTime.Now;

        private void timer1_Tick(object sender, EventArgs e)
        {
            long Now_second = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (Now_second - Last_second >0)
            {
                DateTime now = DateTime.Now;
                //Console.WriteLine(now.Second + " "+now.Millisecond );
                Console.WriteLine("{0} seconds", now.ToString("s.ffff"));
                Last_second = Now_second;
            }
        }
        private void measure_time(string texxt, ref DateTime last_time) //用來測試跟這次動作花費的時間 
        {
            DateTime now = DateTime.Now;
            int sec = 0, msec = 0;
            //sec = now.Second - last_time.Second;
            msec = now.Second * 1000 + now.Millisecond - last_time.Second * 1000 - last_time.Millisecond;
            //lv_Print(listView1, texxt + "使用                 " + msec.ToString() + "毫秒");//+ now.Millisecond 

            Debug.Print(texxt + "使用                 " + msec.ToString() + "毫秒");
            last_time = now;
        }
    }
}
