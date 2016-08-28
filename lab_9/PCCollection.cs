using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace lab_9
{
    class PCCollection
    {
        List<Complectation> PC;
        public PCCollection()
        {
            PC = new List<Complectation>();
        }
        public void Add(string name, int number, string model, string country, double price)
        {
            try
            {
                PC.Add(new Complectation(name, number, model, country, price));
            }
            catch(InvalidCastException e)
            {
                
            }
        }
        public void Add(Complectation ob)
        {
            if(!PC.Contains(ob))
                PC.Add(ob);
        }
        public Complectation Get(int index)
        {
            return PC[index];
        }
        public void Remove(int index)
        {
            PC.RemoveAt(index);
        }
        public void Sort()
        {
            PC.Sort();
        }
        public int Count()
        {
            return PC.Count;
        }
        public void SaveFile(string file)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using(Stream fstream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                binForm.Serialize(fstream, PC);
            }
        }
        public void OpenFile(string file)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using(Stream fstream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                PC = (List<Complectation>)binFormat.Deserialize(fstream);
            }
        }
    }
}
