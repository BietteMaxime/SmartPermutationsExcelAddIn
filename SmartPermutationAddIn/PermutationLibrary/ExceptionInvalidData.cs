using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationLibrary
{
    public class ExceptionInvalidData: Exception
    {
        public ExceptionInvalidData(string message)
            : base(message)
        {
        
        }
    }
}
