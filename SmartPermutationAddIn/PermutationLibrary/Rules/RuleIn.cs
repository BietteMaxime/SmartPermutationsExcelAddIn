using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationLibrary.Rules
{
    public class RuleIn: Rule
    {
        public string RawRule { get; private set; }
        public string[] Values { get; private set; }
        public RuleIn(string rule, string[] possibilityList)
        {
            this.RawRule = rule;
            var regEx = new Regex(@"(?<=\()(.+)(?=\))");
            var results = regEx.Matches(rule);
            var regEx2 = new Regex(@"(?:(?<=')([\w\d\s]+?)(?='))+");
            var results2 = regEx2.Matches(results[0].Value);
            
            //Checking if the values extracted exist in the list of possible values
            //Then adding it to the saved list of Valuess
            var valueList = new List<string>();
            for (int i = 0; i < results2.Count; i++)
            {
                if (possibilityList.Contains(results2[i].Value))
                    valueList.Add(results2[i].Value);
                else
                    throw new ExceptionInvalidData(string.Format("Error in creating RuleIn '{0}'. Data '{1}' is not in the list of possible values.",RawRule,results2[i].Value));
            }
            Values = valueList.ToArray();
        }

        public override string[] GetPossibleValues()
        {
            return Values;
        }

        public override bool IsFinal()
        {
            return true;
        }

        public static bool IsMatch(string rule)
        {
            var regEx = new Regex(@" ?IN ?\((.+)\)");

            return regEx.IsMatch(rule);
        }
    }
}
