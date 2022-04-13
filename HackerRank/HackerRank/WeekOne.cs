using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class WeekOne
    {
        /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static void plusMinus()
        {
            Console.Clear();
            Console.WriteLine("************************ PLUS MINUS ********************************");
            Console.WriteLine("Code by: Kreis");
            Console.WriteLine("Insert n integers separated by commas:");
            string userNumbers = Console.ReadLine();

            List<int> arr = new List<int>();
            int lastCommaIndex = 0;

            try
            {
                //CREATING ARRAY OF INTS FROM STRING
                for (int i = 0; i < userNumbers.Length; i++)
                {
                    if (userNumbers[i] == ',')
                    {
                        if (lastCommaIndex == 0)
                        {
                            string number = userNumbers.Substring(lastCommaIndex, i);
                            arr.Add(Convert.ToInt32(number));
                            lastCommaIndex = i;
                        }
                        else if (i == userNumbers.Length - 1)
                        {
                            int startIndex = lastCommaIndex + 1;
                            int lenght = i - startIndex;
                            string number = userNumbers.Substring(startIndex, lenght);
                            arr.Add(Convert.ToInt32(number));
                            lastCommaIndex = i;
                        }
                        else
                        {
                            int startIndex = lastCommaIndex + 1;
                            int lenght = i - startIndex;
                            string number = userNumbers.Substring(startIndex, lenght);
                            arr.Add(Convert.ToInt32(number));
                            lastCommaIndex = i;
                        }
                    }
                }

                int n = arr.Count();
                float countPositive = arr.Where(x => x > 0).Count();
                float countNegative = arr.Where(x => x < 0).Count();
                float countZero = arr.Where(x => x == 0).Count();

                Console.WriteLine(Math.Round((countPositive / n), 6));
                Console.WriteLine(Math.Round((countNegative / n), 6));
                Console.WriteLine(Math.Round((countZero / n), 6));
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    Console.WriteLine("Please enter just integer numbers next time.");
                }
            }
            
        }

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            List<int> repetitions = new List<int>();

            foreach (string item in queries)
            {

                repetitions.Add(strings.Where(x => x == item).Count());

            }

            return repetitions;
        }

        public static string timeConversion(string s)
        {
            string timeFormat = s.Substring(s.Length - 2);
            string timeReturned = "";

            if (timeFormat == "AM")
            {
                string hour = s.Substring(0, 2);

                if (hour == "12")
                {
                    timeReturned += "00";
                }
                else
                {
                    timeReturned += hour;
                }

                timeReturned += s.Substring(2, s.Length - 4);
            }
            else
            {
                int hour = Convert.ToInt32(s.Substring(0, 2));

                if (hour == 12)
                {
                    timeReturned += hour.ToString();
                    timeReturned += s.Substring(2, s.Length - 4);
                }
                else
                {
                    hour += 12;
                    timeReturned += hour.ToString();
                    timeReturned += s.Substring(2, s.Length - 4);
                }

            }

            Console.WriteLine(timeReturned);
            return timeReturned;
        }

        public static void miniMaxSum(List<int> arr)
        {
            long minSum = 0;
            long maxSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {

                List<long> tempArray = arr.ConvertAll(x => (long)x);
                tempArray.RemoveAt(i);
                long sum = tempArray.Sum();

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                else if (sum < minSum || minSum == 0)
                {
                    minSum = sum;
                }
            }

            Console.WriteLine($"{minSum} {maxSum}");
        }

    }
}
