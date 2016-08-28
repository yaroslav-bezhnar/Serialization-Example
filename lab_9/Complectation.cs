using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab_9
{
    [Serializable]
    class Complectation: IComparable
    {
        string name;
        int number;
        string model;
        string country;
        double price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Complectation() { }
        public Complectation(string name, int number, string model, string country, double price)
        {
            try
            {
                Name = name;
                Number = number;
                Model = model;
                Country = country;
                Price = price;
            }
            catch (InvalidCastException e)
            {
               
            }
        }
        public override bool Equals(object obj)
        {
                Complectation cob = (Complectation)obj;
                return this.Number == cob.Number;
        }
        public int CompareTo(object ob)
        {
            Complectation cob = (Complectation)ob;
            if (this.Number > cob.Number)
                return 1;
            else if (this.Number < cob.Number)
                return -1;
            else return 0;
        }
    }
}
