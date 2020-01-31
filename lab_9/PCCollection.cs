using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// ReSharper disable InconsistentNaming

namespace lab_9
{
    internal class PCCollection
    {
        #region Fields

        private List<Complectation> _pcList;

        #endregion

        #region Constructors

        public PCCollection() => _pcList = new List<Complectation>();

        #endregion

        #region Public Methods

        public void Add( string name, int number, string model, string country, double price )
        {
            try
            {
                _pcList.Add( new Complectation( name, number, model, country, price ) );
            }
            catch
            {
                //
            }
        }

        public void Add( Complectation ob )
        {
            if ( !_pcList.Contains( ob ) ) _pcList.Add( ob );
        }

        public Complectation Get( int index ) => _pcList[index];

        public void Remove( int index )
        {
            _pcList.RemoveAt( index );
        }

        public void Sort()
        {
            _pcList.Sort();
        }

        public int Count() => _pcList.Count;

        public void SaveFile( string file )
        {
            var binForm = new BinaryFormatter();
            using ( var fileStream = new FileStream( file, FileMode.Create, FileAccess.Write, FileShare.Write ) )
            {
                binForm.Serialize( fileStream, _pcList );
            }
        }

        public void OpenFile( string file )
        {
            var binFormat = new BinaryFormatter();
            using ( var stream = new FileStream( file, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                _pcList = (List<Complectation>) binFormat.Deserialize( stream );
            }
        }

        #endregion
    }
}