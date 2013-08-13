using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationLibrary;
using PermutationLibrary.Rules;

namespace TestPermutationLibrary
{
    [TestClass]
    public class UnitTestRuleSet
    {
        [TestMethod]
        public void TestRuleSetPermutationValueListSimple()
        {
            var rules = new string[] { "IN('Rule1Val1','Rule1Val2','Rule1Val3')", " ALL" };
            var possibleValues = new List<string[]> { new string[] { "Rule1Val1", "Rule1Val2", "Rule1Val3", "Rule1Val4" }, new string[] { "Rule2Val1", "Rule2Val2" } };
            var ruleSet = new RuleSet(rules, possibleValues);
            var expected = new List<string[]> { new string[] { "Rule1Val1", "Rule1Val2", "Rule1Val3" }, new string[] { "*" } };

            Assert.AreEqual(2, ruleSet.Rules.Count);
            Assert.AreEqual("PermutationLibrary.Rules.RuleIn", ruleSet.Rules[0].GetType().ToString());
            Assert.AreEqual("PermutationLibrary.Rules.RuleAll", ruleSet.Rules[1].GetType().ToString());

            List<string[]> output = ruleSet.GeneratePermutationsLists()[0];

            Assert.AreEqual(expected.Count, output.Count); 
            Assert.IsTrue(output[0].All(x => expected[0].Contains(x)));
            Assert.IsTrue(output[1].All(x => expected[1].Contains(x)));
        }

        [TestMethod]
        public void TestRuleSetPermutationMatrix()
        {
            var rules = new string[] { "IN('Rule1Val1','Rule1Val2','Rule1Val3')", " ALL" };
            var possibleValues = new List<string[]> { new string[] { "Rule1Val1", "Rule1Val2", "Rule1Val3", "Rule1Val4" }, new string[] { "Rule2Val1", "Rule2Val2" } };
            var ruleSet = new RuleSet(rules, possibleValues);
            var expected = new List<string[]> { new string[] { "Rule1Val1", "*" }, new string[] { "Rule1Val2", "*" }, new string[] { "Rule1Val3", "*" } };

            Assert.AreEqual(2, ruleSet.Rules.Count);
            Assert.AreEqual("PermutationLibrary.Rules.RuleIn", ruleSet.Rules[0].GetType().ToString());
            Assert.AreEqual("PermutationLibrary.Rules.RuleAll", ruleSet.Rules[1].GetType().ToString());

            List<string[]> output = PermutationHelper.DoPermutations(ruleSet.GeneratePermutationsLists()[0]);

            Assert.AreEqual(expected.Count, output.Count);
            Assert.IsTrue(output[0].All(x => expected[0].Contains(x)));
            Assert.IsTrue(output[1].All(x => expected[1].Contains(x)));
            Assert.IsTrue(output[2].All(x => expected[2].Contains(x)));
        }
    }
}
