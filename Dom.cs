using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace Lab2
{
    class Dom : IStrategy
    {
        XmlDocument doc = new XmlDocument();
        public Dom(string path)
        {
            doc.Load(path);
        }
        public List<Student> Algorithm(Student student, string path)
        {
            List<List<Student>> info = new List<List<Student>>();
            info.Add(AllStudents(doc));
            try
            {
                if (student.Speciality != null) info.Add(SearchByParam("speciality", "SPECIALITY", student.Speciality, doc, 0));
                if (student.Group != null) info.Add(SearchByParam("group", "GROUP", student.Group, doc, 1));
                if (student.Room != null) info.Add(SearchByParam("room", "ROOM", student.Room, doc, 2));
                if (student.Surname != null) info.Add(SearchByParam("surname", "SURNAME", student.Surname, doc, 2));
                if (student.Name != null) info.Add(SearchByParam("name", "NAME", student.Name, doc, 2));
                if (student.Phonenumber != null) info.Add(SearchByParam("phonenumber", "PHONENUMBER", student.Phonenumber, doc, 2));
            }
            catch { }
            return Cross(info);
        }
        public static Student Info(XmlNode node)
        {
            Student nw = new Student();
            nw.Speciality = node.ParentNode.ParentNode.Attributes.GetNamedItem("SPECIALITY").Value;
            nw.Group = node.ParentNode.Attributes.GetNamedItem("GROUP").Value;
            nw.Room = node.Attributes.GetNamedItem("ROOM").Value;
            nw.Surname = node.Attributes.GetNamedItem("SURNAME").Value;
            nw.Name = node.Attributes.GetNamedItem("NAME").Value;
            nw.Phonenumber = node.Attributes.GetNamedItem("PHONENUMBER").Value;
            return nw;
        }
        public static List<Student> AllStudents(XmlDocument doc)
        {
            List<Student> data2 = new List<Student>();
            XmlNodeList elem = doc.SelectNodes("//student");
            try
            {
                foreach (XmlNode el in elem)
                {
                    data2.Add(Info(el));

                }
            }
            catch { }
            return data2;
        }
        public static List<Student> SearchByParam(string nodename, string val, string param, XmlDocument doc, int n)
        {
            List<Student> students = new List<Student>();

            if (param != String.Empty && param != null)
            {
                switch (n)
                {
                    case 0:
                        {
                            XmlNodeList elem = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in elem)
                                {
                                    XmlNodeList list1 = e.ChildNodes;
                                    foreach (XmlNode el in list1)
                                    {
                                        XmlNodeList list2 = el.ChildNodes;
                                        foreach (XmlNode ell in list2)
                                        {
                                            students.Add(Info(ell));
                                        }
                                    }
                                }
                            }
                            catch { }
                            return students;
                        }
                    case 1:
                        {

                            XmlNodeList elem = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in elem)
                                {
                                    XmlNodeList list1 = e.ChildNodes;
                                    foreach (XmlNode el in list1)
                                    {
                                        students.Add(Info(el));
                                    }
                                }
                            }
                            catch { }
                            return students;
                        }
                    case 2:
                        {

                            XmlNodeList elem = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in elem)
                                {
                                    students.Add(Info(e));

                                }
                            }
                            catch { }
                            return students;
                        }
                    default: break;
                }
            }
            return students;
        }
        private static List<Student> Cross(List<List<Student>> list)
        {
            List<Student> result = new List<Student>();
            try
            {
                if (list != null)
                {
                    Student[] st = list[0].ToArray();
                    if (st != null)
                    {
                        foreach (Student elem in st)
                        {
                            bool IsIn = true;
                            foreach (List<Student> t in list)
                            {
                                if (t.Count <= 0) return new List<Student>();

                                foreach (Student s in t)
                                {
                                    IsIn = false;
                                    if (elem.Comparing(s))
                                    {
                                        IsIn = true;
                                        break;
                                    }
                                }
                                if (!IsIn) break;
                            }
                            if (IsIn)
                            {
                                result.Add(elem);
                            }
                        }
                    }
                }
            }
            catch { }
            return result;
        }
    }
}
