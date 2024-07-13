using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02.Struct
{
    internal struct Person
    {
        #region Properties
        public string Name { get; set; }
        public int Age { get; set; }
        #endregion

        #region Constructor 
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        #endregion

        #region Methods 
        public override string ToString()
        {
            return $"My Name Is: {Name} And My Age Is {Age}";
        }
        #endregion
    }
}
