using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationLibrary
{
    public class RuleSet
    {
        public List<Rule> Rules { get; private set; }
        public List<Rule> possibleValues { get; private set; }
        public RuleSet(string[] rules, List<string[]> possibleValues)
        {
            Console.Out.WriteLine(possibleValues.Count);
            Rules = new List<Rule>();
            for(int i=0; i<rules.Length; i++)
            {
                Rules.Add(RuleFactory.BuildRule(rules[i], possibleValues[i]));
            }
        }

        public List<List<string[]>> GeneratePermutationsLists()
        {
            var permutationList = new List<string[]>();
            foreach (Rule rule in Rules)
            {
                permutationList.Add(rule.GetPossibleValues());
            }
            return new List<List<string[]>>() {permutationList};
        }
    }
}
