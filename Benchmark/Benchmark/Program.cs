using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //  CalibrateLocks();

            var summary = BenchmarkRunner.Run<CalibrationFixed>();
           // var summaryOriginal = BenchmarkRunner.Run<CalibrationOriginal>();

        }


        //int NumberOfItems = 100000;

        //[Benchmark]
        //public string ConcatStringsUsingGenericList()
        //{
        //    var list = new List<string>(NumberOfItems);
        //    for (int i = 0; i < NumberOfItems; i++)
        //    {
        //        list.Add("Hello World!" + i);
        //    }
        //    return list.ToString();
        //}


        // test 1


        [MemoryDiagnoser]
        public class CalibrationFixed
        {

            [Benchmark]
            public void CalibrateLocks()
            {
                var stuff = 99999999;
                var partsHash = stuff.GetHashCode();
                var lockSetting = GoBig(partsHash % 3, partsHash % 10);
            }

            public int GoBig(int m, int n)
            {
                if (m > 0)
                {
                    var v = GCD(m, n);

                    if (n > 0)
                    {
                        return GoBig(m - v, n - v);
                    }
                    else if (n == 0)
                        return GoBig(m - v, v);
                }
                else if (m == 0 && n >= 0)
                {
                    return n + 1;
                }
                throw new ArgumentOutOfRangeException();
            }

            public int GCD(int a, int b)
            {
                if (b == 0)
                {
                    return a;
                }
                else
                {
                    return GCD(b, a % b);
                }
            }

            public int GCD99(int a, int b)
            {
             var dd =   System.Numerics.BigInteger.GreatestCommonDivisor(a, b);

                if (b == 0)
                {
                    return a;
                }
                else
                {
                    return GCD(b, a % b);
                }
            }


            // GreatestCommonDivisor



            [Benchmark]
            public void CalibrateLocksOriginal()
            {
                var stuff = 99999999;
                var partsHash = stuff.GetHashCode();
                var lockSetting = GoBigOriginal(partsHash % 3, partsHash % 10);
            }

            public long GoBigOriginal(long m, long n)
            {
                if (m > 0)
                {
                    if (n > 0)
                        return GoBigOriginal(m - 1, GoBigOriginal(m, n - 1));
                    else if (n == 0)
                        return GoBigOriginal(m - 1, 1);
                }
                else if (m == 0)
                {
                    if (n >= 0)
                        return n + 1;
                }
                throw new ArgumentOutOfRangeException();
            }
        }


        
    }
}
