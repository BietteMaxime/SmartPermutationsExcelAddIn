using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PermutationLibrary
{
    public class RuleFactory
    {
        public static Rule BuildRule(string rule, string[] possibleValues)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(Rule)))
                {
                    bool isMatching = (bool)type.GetMethod("IsMatch", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] { rule });
                    if (isMatching)
                    {
                        try
                        {
                            return (Rule)Activator.CreateInstance(type, rule, possibleValues);
                        }
                        catch (TargetInvocationException ex)
                        {
                            throw ex.InnerException;
                        }
                    }
                }
            }

            throw new ExceptionInvalidData(string.Format("Error in creating Rule '{0}'. No matching rule found.", rule));
        }
    }
}
