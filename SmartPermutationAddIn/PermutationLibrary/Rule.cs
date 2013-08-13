using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PermutationLibrary
{
    public abstract class Rule
    {
        //public abstract PossibilityList Evaluate();
        public abstract bool IsFinal();
        //public abstract List<RuleSet> Evaluate(RuleSet);
        public abstract string[] GetPossibleValues();
        //public abstract bool IsMatch(string rule);
        //public abstract Condition GetCondition();
        //public abstract List<Rule> ApplyCondition(Rule condition);
    }
}
