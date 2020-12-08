using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Paperwork
    {
        public string Course = null;
        public string Group = null;
        public string DateOfCreation = null;
        public string Surname = null;
        public string Name = null;
        public string Amount = null;

        public Paperwork() { }

        public Paperwork(string[] data)
        {
            Course = data[0];
            Group = data[1];
            DateOfCreation = data[2];
            Surname = data[3];
            Name = data[4];
            Amount = data[5];

        }
        public Paperwork(IStrategy algo)
        {
            Course = String.Empty;
            Group = String.Empty;
            DateOfCreation = String.Empty;
            Surname = String.Empty;
            Name = String.Empty;
            Amount = String.Empty;
        }
        public bool Comparing(Paperwork paperwork)
        {
            if ((this.Course == paperwork.Course) &&
                (this.Group == paperwork.Group) &&
                (this.DateOfCreation == paperwork.DateOfCreation) &&
                (this.Surname == paperwork.Surname) &&
                (this.Name == paperwork.Name) &&
                (this.Amount == paperwork.Amount))
                return true;
            else return false;
        }
        public IStrategy Algo {get; set; }
        public List <Paperwork> Algorithm(Paperwork parametrs, string path)
        {
            return Algo.Algorithm(parametrs, path);
        }
    }
}
