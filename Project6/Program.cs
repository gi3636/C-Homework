using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project6
{     //2.使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。*/
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.clock.Click(0,0,10);
            Console.ReadKey();
        }
    }

    public delegate void AlarmEventHandler(object sender, AlarmEventArgs args);
    public class AlarmEventArgs
    {
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
    }


    public class Clock
    {
        public event AlarmEventHandler onClick;


        public void Click(int hour, int minute, int second)
        {
            Console.WriteLine("你设置了" + (hour = hour % 24).ToString() + ":" + (minute = minute % 60).ToString() + ":" + (second = second % 60).ToString());
           
            AlarmEventArgs args = new AlarmEventArgs()
            {
                Hour = hour,
                Minute = minute,
                Second = second
            };

                onClick(this, args);         
        }


        public void Tick(AlarmEventArgs args)
        {
            int hour = args.Hour;
            int minute = args.Minute;
            int second = args.Second;
            while (hour != 0 && minute != 0 && second != 0)
            {
                Console.WriteLine("时间还剩" + hour + ":" + minute + ":" + second);
                Thread.Sleep(1000);
                second -= 1;
                if (second == 0 && minute != 0 || hour !=0) {
                    second += 60;
                    minute -= 1;
                    if (minute<=0 && hour!=0)
                    {
                        minute += 60;
                        hour -= 1;
                    }
                }
                

            }
        }
    }
    public class Form
    {
        public Clock clock = new Clock();


        public Form()
        {
            clock.onClick += new AlarmEventHandler(Alarm_onClick);
        }

        void Alarm_onClick(object sender, AlarmEventArgs args)
        {
            clock.Tick(args);
            Console.WriteLine($"时间已到了！");
        }
   
    }
}
