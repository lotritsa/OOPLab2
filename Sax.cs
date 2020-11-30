using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace Lab2
{
    class Sax:IStrategy
    {
        List<Student> info = new List<Student>();
        XmlReader BestReader;
        public Sax(string path)
        {
            BestReader = XmlReader.Create(path);
        }

        public  List <Student> Algorithm(Student student, string path)
        {
            info.Clear();

            List<Student> result = new List<Student>();
            Student st = null;
            string _speciality = null;
            string _group = null;
            while (BestReader.Read())
            {
                if (BestReader.Name == "speciality")
                {
                    while (BestReader.MoveToNextAttribute())
                    {
                        if (BestReader.Name == "SPECIALITY")
                        {
                            _speciality = BestReader.Value;
                        }
                    }
                }
                if (BestReader.Name == "group")
                {
                    while (BestReader.MoveToNextAttribute())
                    {
                        if (BestReader.Name == "GROUP")
                        {
                            _group = BestReader.Value;
                        }
                    }
                }
                if (BestReader.Name == "student")
                {
                    if (st == null)
                    {
                        st = new Student();
                        st.Speciality = _speciality;
                        st.Group = _group;
                    }
                    else
                    {
                        st = new Student();
                        st.Speciality = _speciality;
                        st.Group = _group;
                    }
                    if (BestReader.HasAttributes)
                    {
                        while (BestReader.MoveToNextAttribute())
                        {
                            if (BestReader.Name == "ROOM")
                            {
                                st.Room = BestReader.Value;
                            }
                            if (BestReader.Name == "SURNAME")
                            {
                                st.Surname = BestReader.Value;
                            }
                            if (BestReader.Name == "NAME")
                            {
                                st.Name = BestReader.Value;
                            }
                            if (BestReader.Name == "PHONENUMBER")
                            {
                                st.Phonenumber = BestReader.Value;
                            }
                        }
                    }
                    if (st.Surname != null)
                    {
                        result.Add(st);
                    }
                }
            }
            info = Filtr(result, student);
            return info;
        }
        public List <Student> Filtr(List<Student> allStud, Student param)
        {
            List<Student> result = new List<Student>();
            if (allStud != null)
            {
                foreach (Student e in allStud)
                {
                    try
                    {
                        if (
                            (e.Speciality == param.Speciality || param.Speciality == null) &&
                            (e.Group == param.Group || param.Group == null) &&
                            (e.Room == param.Room || param.Room == null) &&
                            (e.Surname == param.Surname || param.Surname == null) &&
                            (e.Name == param.Name || param.Name == null) &&
                            (e.Phonenumber == param.Phonenumber || param.Phonenumber == null)
                            )
                        {
                            result.Add(e);
                        }
                    }
                    catch { }

                }
            }
            return result;
        }
    }
}
