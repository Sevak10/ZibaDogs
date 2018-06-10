using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs.Models
{
    public class AddResponse
    {
        private static List<SignIn> responses = new List<SignIn>();

        public static IEnumerable<SignIn> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddGuest(SignIn guest)
        {
            responses.Add(guest);
        }
    }
}
