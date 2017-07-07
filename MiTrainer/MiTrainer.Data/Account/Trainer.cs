using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTrainer.Data.Account
{
    public class Trainer
    {
        public bool isTrainer = false;

        public Person person { get; set; }

        public Trainer(bool _isTrainer, Person _person)
        {
            isTrainer = _isTrainer;
            person = _person;
        }
    }
}
