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
    public class UnitTestRuleFactory
    {
        [TestMethod]
        public void TestCreateINRule()
        {
            string rule = " IN('234','ARU','FRAdfg','145', 'Bonjour le monde')";
            string[] ruleList =  new string[] {"234","ARU","FRAdfg","145","Bonjour le monde"};
            string[] possibilityList = new string[] { "234", "ARU", "FRAdfg", "145", "Bonjour le monde" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleIn", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleIn)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleIn)output).Values[0]);
            Assert.AreEqual(ruleList[1], ((RuleIn)output).Values[1]);
            Assert.AreEqual(ruleList[2], ((RuleIn)output).Values[2]);
            Assert.AreEqual(ruleList[3], ((RuleIn)output).Values[3]);
            Assert.AreEqual(ruleList[4], ((RuleIn)output).Values[4]);
        }

        [TestMethod]
        public void TestCreateNOTRule()
        {
            string rule = " NOT('145', 'Bonjour le monde')";
            string[] ruleList = new string[] { "234", "ARU", "FRAdfg" };
            string[] possibilityList = new string[] { "234", "ARU", "FRAdfg", "145", "Bonjour le monde" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleNot", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleNot)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleNot)output).Values[0]);
            Assert.AreEqual(ruleList[1], ((RuleNot)output).Values[1]);
            Assert.AreEqual(ruleList[2], ((RuleNot)output).Values[2]);
        }

        [TestMethod]
        public void TestCreateALLRule()
        {
            string rule = " ALL ";
            string[] ruleList = new string[] { "*" };
            string[] possibilityList = new string[] { "234", "ARU", "FRAdfg", "145", "Bonjour le monde" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleAll", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleAll)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleAll)output).Values[0]);
        }

        [TestMethod]
        public void TestCreateBETWEENRule()
        {
            string rule = " BETWEEN ('3.2','4') ";
            string[] ruleList = new string[] { "4", "3.2", "3.3" };
            string[] possibilityList = new string[] { "0", "1", "2", "3", "4","5","6","7","8","3.2","3.3" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleBetween", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleBetween)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleBetween)output).Values[0]);
            Assert.AreEqual(ruleList[1], ((RuleBetween)output).Values[1]);
            Assert.AreEqual(ruleList[2], ((RuleBetween)output).Values[2]);
        }

        [TestMethod]
        public void TestINRuleSymboleMatching()
        {
            string rule = " IN('@','&','FRAdfg', 'Bonjour le monde')";
            string[] ruleList = new string[] { "@", "&", "FRAdfg", "Bonjour le monde" };
            string[] possibilityList = new string[] { "@", "&", "FRAdfg", "145", "Bonjour le monde" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleIn", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleIn)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleIn)output).Values[0]);
            Assert.AreEqual(ruleList[1], ((RuleIn)output).Values[1]);
            Assert.AreEqual(ruleList[2], ((RuleIn)output).Values[2]);
            Assert.AreEqual(ruleList[3], ((RuleIn)output).Values[3]);
        }

        [TestMethod]
        public void TestNOTRuleSymboleMatching()
        {
            string rule = " NOT('@', 'Bonjour le monde')";
            string[] ruleList = new string[] { "ARU", "FRAdfg" };
            string[] possibilityList = new string[] { "@", "ARU", "FRAdfg", "Bonjour le monde" };
            Rule output = RuleFactory.BuildRule(rule, possibilityList);
            Assert.AreEqual("PermutationLibrary.Rules.RuleNot", output.GetType().ToString());
            Assert.AreEqual(rule, ((RuleNot)output).RawRule);
            Assert.AreEqual(ruleList[0], ((RuleNot)output).Values[0]);
            Assert.AreEqual(ruleList[1], ((RuleNot)output).Values[1]);
        }

    }
}
