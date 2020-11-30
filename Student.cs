using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Student
    {
        public string Speciality = null;
        public string Group = null;
        public string Room = null;
        public string Surname = null;
        public string Name = null;
        public string Phonenumber = null;

        public Student() { }

        public Student(string[] data)
        {
            Speciality = data[0];
            Group = data[1];
            Room = data[2];
            Surname = data[3];
            Name = data[4];
            Phonenumber = data[5];

        }
        public Student(IStrategy algo)
        {
            Speciality = String.Empty;
            Group = String.Empty;
            Room = String.Empty;
            Surname = String.Empty;
            Name = String.Empty;
            Phonenumber = String.Empty;
        }
        public bool Comparing(Student student)
        {
            if ((this.Speciality == student.Speciality) &&
                (this.Group == student.Group) &&
                (this.Room == student.Room) &&
                (this.Surname == student.Surname) &&
                (this.Name == student.Name) &&
                (this.Phonenumber == student.Phonenumber))
                return true;
            else return false;
        }
        public IStrategy Algo {get; set; }
        public List <Student> Algorithm(Student parametrs, string path)
        {
            return Algo.Algorithm(parametrs, path);
        }
    }
}
