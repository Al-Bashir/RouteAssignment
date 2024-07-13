using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02_Demo.Encapsulation
{
    internal struct PhoneBook
    {
        #region Attributes 
        private string[] Names;
        private int[] Numbers;
        private int size;
        #endregion
        #region Properties
        public int Size
        { 
            get { return size; }
        }
        
        //Indexer:
        public int this[string name]
        {
            get 
            {
                if (Names is not null && Numbers is not null)
                    for(int i = 0; i < Names.Length; i++)
                        if (Names[i] == name)
                            return Numbers[i];
                return -1;
            }
            set
            {
                if (Names is not null && Numbers is not null)
                    for (int i = 0; i < Names.Length; i++)
                        if (Names[i] == name)
                        {
                            Numbers[i] = value;
                            break;
                        }
            }

        }
        #endregion


        #region Constructor 
        public PhoneBook(int _size)
        {
            size = _size;
            Names = new string[size];
            Numbers = new int[size];
        }
        #endregion

        #region Methods
        public void AddPerson(int Index, string Name, int Number)
        {
            if (Names is not null && Numbers is not null)
            {
                Names[Index] = Name;
                Numbers[Index] = Number;    
            }
        }

        //Getter
        public int GetPersonNumber(string name)
        {
            for (int i = 0; i < Names?.Length; i++)
            {
                if (Names[i] == name)
                    return Numbers[i];
            }
            return -1;
        }

        //Setter
        public void SetPersonName(string name, int NewNumber)
        { 
            if (Names is not null && Numbers is not null) 
            {
                for(int i = 0;i < Names.Length; i++) 
                {
                    if (Names[i] == name)
                    {
                        Numbers[i] = NewNumber;
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
