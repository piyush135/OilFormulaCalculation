using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using Microsoft.Owin.Logging;

namespace OilCompanyFormulation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // register exception handler
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            var oilFormula = new OilInputModel();
            ulong p;
            ulong outZero;
            ulong r;
            ulong d;
            GetValidInput(out d, out p, out outZero, out r);

            var tmax = OilFormula.CalculateTmax(d, p, outZero, r);

            Console.WriteLine(string.Format("Tmax: {0} days company takes to reach its mamimun production level",tmax));

            Console.WriteLine(string.Format("Company's peak oil production : {0} barrels",OilFormula.CalculateOutTmax(d, tmax, p, outZero, r)));
            Console.ReadLine();
        }

        private static void GetValidInput(out ulong d, out ulong p, out ulong outZero, out ulong r)
        {
            d = 0;
            p = 0;
            outZero = 0;
            r = 0;
            bool isNotVaildInput = true;
            Console.WriteLine("\n Number of drills :");
            var dTemp = Console.ReadLine();
            Console.WriteLine("Period");
            var pTemp = Console.ReadLine();
            Console.WriteLine("Initial OutPut Out(0) barrels oil per day");
            var outZeroTemp = Console.ReadLine();
            Console.WriteLine("Depreciation rate");
            var rTemp = Console.ReadLine();

            while (isNotVaildInput)
            {
                if (!ulong.TryParse(dTemp, out d))
                {
                    Console.Write(string.Format("{0} is not valid drill count, Please enter again :", dTemp));
                    dTemp = Console.ReadLine();
                    continue;
                }
                if (!ulong.TryParse(pTemp, out p))
                {
                    Console.Write(string.Format("\n {0} is not a valid period, Please enter again :", pTemp));
                    pTemp = Console.ReadLine();
                    continue;
                }
                if (!ulong.TryParse(outZeroTemp, out outZero))
                {
                    Console.Write(string.Format("\n {0} is not valid Initial output, Please enter again :", outZeroTemp));
                    outZeroTemp = Console.ReadLine();
                    continue;
                }
                if (!ulong.TryParse(rTemp, out r))
                {
                    Console.Write(string.Format("\n {o} is not valid Depreciation rate, Please enter again :", rTemp));
                    rTemp = Console.ReadLine();
                    continue;
                }
                isNotVaildInput = false;
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // handle exception
            Console.WriteLine(e.ExceptionObject.ToString());
        }
    }

    //Consideration
    //p period and t are in day
    //Unit of Out(0) and r is same

    //Formula
    //tmax = how long company takes to reach its maximum production level
    //tmax = p +(Out(0)/r)

    //Out(tmax) = What is the company's peak oil production in barrels.
    //Consideration:- Here Out(tmax) is total product on that day.
    //Out(tmax) = tmax -p /2(2*out(0) - (tmax-p-1)r) 
    public class OilFormula
    {
        public static float CalculateTmax(ulong d, ulong p, ulong OutZero, ulong r)
        {
            if(d >0)
               return r == 0 ? p + OutZero : p + (float)OutZero / r;
            return 0;
        }

        public static float CalculateOutTmax(ulong d, float tmax, ulong p, ulong OutZero, ulong r)
        {
            return r == 0 ? d * ((float)(Math.Abs((long)(tmax - p))) / 2 * 2 * OutZero) : d * ((float)(Math.Abs((long)(tmax - p))) / 2 * (float)Math.Abs((long)(2 * OutZero - (tmax - p - 1) * r)));
        }
    }

    public class OilInputModel
    {
        public ulong NumerbOfDrills { get; set; }
        public ulong Period { get; set; }
        public ulong InitialOutPut { get; set; }
        public ulong DepreciationRate { get; set; }
    }
}