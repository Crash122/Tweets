using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                tweet a;

                tweet[] TW = new tweet[10];
                TW = text(TW);
                TW = time(TW);
                
                Console.WriteLine("Введите время твита");
                string[] vrema = Console.ReadLine().Split('-');
               int minhours = vremya(vrema,0,0);
                int minminutes = vremya(vrema, 0, 1);
                int maxhours = vremya(vrema, 1, 0);
                int maxminutes = vremya(vrema, 1, 1);


                bool righttime = false;
                string yo = "";
               
                for (int i = 0; i < TW.Length; i++)
                {  if (maxhours > 24 || maxminutes > 60 || minminutes > 60 || minhours.ToString().Length != 2 || minminutes.ToString().Length != 2 || maxhours.ToString().Length != 2 || maxminutes.ToString().Length != 2)
                    {
                        righttime = true;
                        break; }
                    
                    string[] tweettime = TW[i].time.Split(':');
                    int tweettimehours = Convert.ToInt32(tweettime[0]);
                    int tweettimeminutes = Convert.ToInt32(tweettime[1]);
                    if (minhours < tweettimehours && maxhours > tweettimehours)
                    {
                        yo = yo + TW[i].text;
                    }
                    else if ((minhours == tweettimehours && minminutes >= tweettimeminutes) || (maxhours == tweettimehours && maxminutes > tweettimeminutes))
                    {
                        yo = yo + TW[i].text;

                    }

                }
                if (righttime == false)
                {  if (yo != "")
                    {
                        Console.WriteLine(yo);
                    }
                else
                    { Console.WriteLine("В данный промежуток времени твитов не было."); }
                }
                else { Console.WriteLine("Вы ошиблись при введении времени."); }
            }
            catch { Console.WriteLine("Были введены некорректные символы"); }

           
            Console.ReadKey();
        }
        public struct tweet  {
            public string text;
            public string time;}
        static tweet[] text(tweet[] a)
        {
            
            for (int i = 0; i < a.Length; i++)
            {
                
                a[i].text = "hello " + i.ToString() + " ";
            }
            return a;

        }
        static tweet[] time(tweet[] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
            {

                int y = r.Next(0, 24);
            int f = r.Next(0, 60);
            if (y <= 9)
            {
                string h = "0" + y.ToString();
                a[i].time = h;

            }
            else { a[i].time = y.ToString(); }
            if (f <= 9)
            {
                string w = "0" + f.ToString();
                a[i].time = a[i].time + ":" + w;

            }
            else { a[i].time = a[i].time + ":" + f.ToString(); }
            }
            return a;
        }
        static int vremya(string[] a,int i,int y)
        {
            string[] time = a[i].Split(':');
            int number = Convert.ToInt32(time[y]);

            return number;

        }
    }
}
