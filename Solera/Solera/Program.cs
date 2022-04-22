using System;
using System.Text.RegularExpressions;

namespace Solera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] argsTest = { "--hELp", "--count", "10" };

            var val = new ValidateArguments();
            var result = val.Validate(argsTest);

            Console.WriteLine(result);
        }
    }

    class ValidateArguments
    {
        public int Validate(string[] args)
        {
            int returnedValue = -1;
            bool helpRequested = false;

            if (args == null || args.Length == 0)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (Regex.IsMatch(args[i].ToLower(), @"\bhelp\b"))
                    {
                        helpRequested = true;
                    }
                    else if (Regex.IsMatch(args[i].ToLower(), @"\bname\b"))
                    {
                        if ((i + 1) < args.Length)
                        {
                            returnedValue = ValidateName(args[i + 1]);
                        }
                    }
                    else if (Regex.IsMatch(args[i].ToLower(), @"\bcount\b"))
                    {
                        if ((i + 1) < args.Length)
                        {
                            returnedValue = ValidateCount(args[i + 1]);
                        }
                    }
                }

                if (helpRequested && returnedValue == 0)
                {
                    return 1;
                }
            }

            return returnedValue;
        }

        public int ValidateName(string s)
        {
            if (s.Length > 2 && s.Length < 11)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public int ValidateCount(string s)
        {
            int number;

            if (Int32.TryParse(s, out number))
            {
                if (number >= 10 && number <= 100)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
