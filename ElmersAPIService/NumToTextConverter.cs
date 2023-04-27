using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService
{
    public class NumToTextConverter : INumToTextConverter
    {      
        public string ConvertNumberToWords(string number)
        {
            //clean input
            number = number.Trim().Replace(" ", "").Replace(",", "");
            //perform validation      
            int numToConvert = 0; 
            if (int.TryParse(number, out numToConvert))
            {
                string result = NumberToWords(numToConvert);
                result = result.Trim();
                //find the last index of "hundred" then add "and"
                int lastIndex = result.LastIndexOf("hundred");
                if (lastIndex != -1)
                {
                    if ((lastIndex + 7) < result.Length)
                        result = result.Insert(lastIndex + 8, "and ");
                }
                else
                {
                    //find the last index of thousand then add "and"
                    lastIndex = result.LastIndexOf("thousand");
                    if (lastIndex != -1)
                    {
                        if ((lastIndex + 8) < result.Length)
                            result = result.Insert(lastIndex + 9, "and ");
                    }
                    else
                    {
                        //find the last index of million then add "and"
                        lastIndex = result.LastIndexOf("million");
                        if (lastIndex != -1)
                        {
                            if ((lastIndex + 7) < result.Length)
                                result = result.Insert(lastIndex + 8, "and ");
                        }
                        else
                        {
                            //find the last index of billion then add "and"
                            lastIndex = result.LastIndexOf("billion");
                            if (lastIndex != -1)
                            {
                                if ((lastIndex + 7) < result.Length)
                                    result = result.Insert(lastIndex + 8, "and ");
                            }
                        }
                    }
                }
                
                result = result.Substring(0,1).ToUpper() + result.Substring(1);
                return result;
            }
            return string.Empty; //return empty string
        }
        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "negative " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            } 

            words = SmallNumberToWord(number, words);
           
            return words;
        }

        private string SmallNumberToWord(int number, string words)
        {
            if (number <= 0) return words;
            //if (words != "")
            //    words += " ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
            return words;
        }      
    }
}
