using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationLibrary.Rules
{
    public class RuleAll: Rule
    {
        public string RawRule { get; private set; }
        public string[] Values { get; private set; }
        private string[] possibleValues;
        public RuleAll(string rule, string[] possibilityList)
        {
            this.RawRule = rule;
            Values = new string[] { "*" };
            possibleValues = possibilityList;
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
            var regEx = new Regex(@" ?ALL ?");

            return regEx.IsMatch(rule);
        }
    }
}
