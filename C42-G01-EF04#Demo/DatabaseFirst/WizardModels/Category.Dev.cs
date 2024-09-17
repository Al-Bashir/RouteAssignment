using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.WizardModels
{
    public partial class Category
    {
        public override string ToString()
        {
            return $"{CategoryName} ::: {Description}";
        }
    }
}
