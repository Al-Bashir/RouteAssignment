using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP04.Interfaces
{
    internal interface IShape
    {
        #region Properties
        public int Area { get; set; }
        #endregion

        #region Methods
        public void DisplayShapeInfo();
        #endregion
    }
}
