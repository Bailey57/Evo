using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo
{
    [System.Serializable]
    public class GameTime
    {

        //military time
        private int day;
        private int month;
        private int year;
        private int hour;
        private double minute;
        private double second;



        //2049 starts on a friday 
        public GameTime()
        {
            this.day = 1;
            this.month = 1;
            this.year = 2094;
            this.hour = 9;
            this.minute = 0;
            this.second = 0;

        }




        public void PassSeconds(double seconds)
        {
            this.second += seconds;

            for (double i = second; i >= 60; i = second)
            {
                if (second >= 60)
                {
                    second -= 60;
                    minute += 1;
                    if (minute >= 60)
                    {
                        minute -= 60;
                        hour += 1;
                        if (hour >= 24)
                        {
                            hour -= 24;
                            day += 1;
                            if (day >= 25)
                            {
                                day -= 25;
                                month += 1;
                                if (month >= 12)
                                {
                                    month -= 12;
                                    year += 1;
                                }

                            }
                        }
                    }
                }
            }
        }




        /*
         * 
         * private int day;
        private int month;
        private int year;
        private int hour;
        private double minute;
        private double second;
         * 
         */


        public override string ToString()
        {

            string output = "";
            string hourStr = "";
            string minuteStr = "";

            if (hour < 10)
            {
                hourStr = "0" + hour;
            }
            else 
            {
                hourStr = "" + hour;
            }

            if (minute < 10) 
            {
                minuteStr = "0" + minute;
            }
            else
            {
                minuteStr = "" + minute;
            }



            output = "\n" + day + "/" + month + "/" + year + "\n" + hourStr + ":" + minuteStr + "\n";


            return output;
        }
        // static void Main(string[] args)
        // {
        //     GameTime gt = new GameTime();
        //     gt.PassSeconds(889920);
        //     Console.WriteLine(gt.ToString());

        // }



    }
}
