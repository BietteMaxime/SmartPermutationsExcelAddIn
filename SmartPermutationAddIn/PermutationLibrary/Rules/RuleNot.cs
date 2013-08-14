using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationLibrary.Rules
{
    public class RuleNot: Rule
    {
        public string RawRule { get; private set; }
        public string[] Values { get; private set; }
        public RuleNot(string rule, string[] possibilityList)
        {
            this.RawRule = rule;
            var regEx = new Regex(@"(?<=\()(.+)(?=\))");
            var results = regEx.Matches(rule);
            var regEx2 = new Regex(@"(?:(?<=')([\w\d\s#@&$]+?)(?='))+");
            var results2 = regEx2.Matches(results[0].Value);
            
            //Intersection between the values extracted and the list of possible values
            //Then adding it to the saved list of Values
            var valueList = new List<string>();
            for (int i = 0; i < results2.Count; i++)
            {
                valueList.Add(results2[i].Value);
            }
            Values = possibilityList.Except(valueList).ToArray();
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
            var regEx = new Regex(@" ?NOT ?\((.+)\)");

            return regEx.IsMatch(rule);
        }
    }
}
