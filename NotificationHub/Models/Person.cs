using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Type tip { get; set; }

        public Person()
        {

        }

        public Person(int id, string name, Type tip)
        {
            Id = id;
            Name = name;
            this.tip = tip;
        }
    }
}
