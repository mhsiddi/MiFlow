using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTrainer.Data.Account
{
    public class User
    {
        public bool isUser = false;

        public Person person { get; set; }

        public User(bool _isUser, Person _person)
        {
            isUser = _isUser;
            person = _person;
        }
        
    
    }
}
