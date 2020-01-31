using System;

namespace lab_9
{
    [Serializable]
    internal class Complectation : IComparable
    {
        #region Constructors

        public Complectation( string name, int number, string model, string country, double price )
        {
            Name = name;
            Number = number;
            Model = model;
            Country = country;
            Price = price;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public int Number { get; set; }

        public string Model { get; set; }

        public string Country { get; set; }

        public double Price { get; set; }

        #endregion

        #region IComparable Members

        public int CompareTo( object ob )
        {
            var c = (Complectation) ob;

            if ( Number > c.Number ) return 1;

            if ( Number < c.Number ) return -1;

            return 0;
        }

        #endregion

        #region Public Methods

        public override bool Equals( object obj )
        {
            if ( obj is Complectation c ) return Equals( c );

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ( ( Name != null ? Name.GetHashCode() : 0 ) * 397 ) ^ Number;
            }
        }

        #endregion

        #region Protected Methods

        protected bool Equals( Complectation other ) => string.Equals( Name, other.Name ) && Number == other.Number;

        #endregion
    }
}