using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02_Demo
{
    internal class Car
    {
        #region Properties 
        public int Id { get; set; }
        public string Modle { get; set; }
        public double Speed { get; set; }

        public override string ToString()
        {
            return $"Car Id: {Id}\nCar Modle: {Modle}\nCar Speed: {Speed}";
        }
        #endregion

        #region Constructors
        public Car()
        {
                
        }
        public Car(int id, string modle, double speed)
        {
            Id = id;
            Modle = modle;
            Speed = speed;
        }       
        //Constructor Overloading
        public Car(int id, string modle)
        {
            Id = id;
            Modle = modle;
            Speed = 190;
        }        
        public Car(int id)
        {
            Id = id;
            Modle = "Skuda";
            Speed = 190;
        }

        //Constructor Chaining 
        #endregion

    }
}
