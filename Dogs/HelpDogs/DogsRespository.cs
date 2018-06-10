using Dogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs.HelpDogs
{
    public class DogsRespository
    {
        private static List<SignIn> Sign = new List<SignIn>();

        public static IEnumerable<SignIn> Signin
        {
            get { return Sign; }
        }
        
    }
}
