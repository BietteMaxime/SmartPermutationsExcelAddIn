using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PermutationLibrary.Rules
{
    public class RuleBetween: Rule
    {
        public string RawRule { get; private set; }
        public string[] Values { get; private set; }

        public RuleBetween(string rule, string[] possibilityList)
        {
            this.RawRule = rule;
            var regEx = new Regex(@"(?<=\()(.+)(?=\))");
            var results = regEx.Matches(rule);
            var regEx2 = new Regex(@"(?:(?<=')([\d\s\.]+?)(?='))+");
            var results2 = regEx2.Matches(results[0].Value);

            // Reading the between values
            double lowerValue = double.Parse(results2[0].Value, CultureInfo.InvariantCulture);
            double upperValue = double.Parse(results2[1].Value, CultureInfo.InvariantCulture);

            // Converting the possibility list to doubles
            var valueList = new List<double>();
            for (int i = 0; i < possibilityList.Length; i++)
            {
                valueList.Add(double.Parse(possibilityList[i], CultureInfo.InvariantCulture));
            }

            // Getting the right values.
            var where = valueList.Where(x => x >= lowerValue && x <= upperValue);
            var cast = where.Select(x => Convert.ToString(x, CultureInfo.InvariantCulture));
            var array = cast.ToArray();
            Values = array;
        }

        public override bool IsFinal()
        {
            return true;
        }

        public override string[] GetPossibleValues()
        {
            return Values;
        }

        public static bool IsMatch(string rule)
        {
            var regEx = new Regex(@" ?BETWEEN ?\((.+)\)");

            return regEx.IsMatch(rule);
        }
    }
}
