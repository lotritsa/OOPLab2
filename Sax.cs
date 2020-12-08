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
        List<Paperwork> info = new List<Paperwork>();
        XmlReader BestReader;
        public Sax(string path)
        {
            BestReader = XmlReader.Create(path);
        }

        public  List <Paperwork> Algorithm(Paperwork paperwork, string path)
        {
            info.Clear();

            List<Paperwork> result = new List<Paperwork>();
            Paperwork st = null;
            string _course = null;
            string _group = null;
            while (BestReader.Read())
            {
                if (BestReader.Name == "course")
                {
                    while (BestReader.MoveToNextAttribute())
                    {
                        if (BestReader.Name == "COURSE")
                        {
                            _course = BestReader.Value;
                        }
                    }
                }
                if (BestReader.Name == "group")
                {
                    while (BestReader.MoveToNextAttribute())
                    {
                        if (BestReader.Name == "TYPE")
                        {
                            _group = BestReader.Value;
                        }
                    }
                }
                if (BestReader.Name == "paperwork")
                {
                    if (st == null)
                    {
                        st = new Paperwork();
                        st.Course = _course;
                        st.Group = _group;
                    }
                    else
                    {
                        st = new Paperwork();
                        st.Course = _course;
                        st.Group = _group;
                    }
                    if (BestReader.HasAttributes)
                    {
                        while (BestReader.MoveToNextAttribute())
                        {
                            if (BestReader.Name == "DATEOFCREATION")
                            {
                                st.DateOfCreation = BestReader.Value;
                            }
                            if (BestReader.Name == "NAME")
                            {
                                st.Surname = BestReader.Value;
                            }
                            if (BestReader.Name == "AUTHOR")
                            {
                                st.Name = BestReader.Value;
                            }
                            if (BestReader.Name == "AMOUNT")
                            {
                                st.Amount = BestReader.Value;
                            }
                        }
                    }
                    if (st.Surname != null)
                    {
                        result.Add(st);
                    }
                }
            }
            info = Filtr(result, paperwork);
            return info;
        }
        public List <Paperwork> Filtr(List<Paperwork> allStud, Paperwork param)
        {
            List<Paperwork> result = new List<Paperwork>();
            if (allStud != null)
            {
                foreach (Paperwork e in allStud)
                {
                    try
                    {
                        if (
                            (e.Course == param.Course || param.Course == null) &&
                            (e.Group == param.Group || param.Group == null) &&
                            (e.DateOfCreation == param.DateOfCreation || param.DateOfCreation == null) &&
                            (e.Surname == param.Surname || param.Surname == null) &&
                            (e.Name == param.Name || param.Name == null) &&
                            (e.Amount == param.Amount || param.Amount == null)
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
