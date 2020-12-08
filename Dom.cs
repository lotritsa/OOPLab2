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
        public List<Paperwork> Algorithm(Paperwork paperwork, string path)
        {
            List<List<Paperwork>> info = new List<List<Paperwork>>();
            info.Add(AllPaperworks(doc));
            try
            {
                if (paperwork.Course != null) info.Add(SearchByParam("course", "COURSE", paperwork.Course, doc, 0));
                if (paperwork.Group != null) info.Add(SearchByParam("group", "TYPE", paperwork.Group, doc, 1));
                if (paperwork.DateOfCreation != null) info.Add(SearchByParam("room", "DATEOFCREATION", paperwork.DateOfCreation, doc, 2));
                if (paperwork.Surname != null) info.Add(SearchByParam("surname", "NAME", paperwork.Surname, doc, 2));
                if (paperwork.Name != null) info.Add(SearchByParam("name", "AUTHOR", paperwork.Name, doc, 2));
                if (paperwork.Amount != null) info.Add(SearchByParam("phonenumber", "AMOUNT", paperwork.Amount, doc, 2));
            }
            catch { }
            return Cross(info);
        }
        public static Paperwork Info(XmlNode node)
        {
            Paperwork nw = new Paperwork();
            nw.Course = node.ParentNode.ParentNode.Attributes.GetNamedItem("COURSE").Value;
            nw.Group = node.ParentNode.Attributes.GetNamedItem("TYPE").Value;
            nw.DateOfCreation = node.Attributes.GetNamedItem("DATEOFCREATION").Value;
            nw.Surname = node.Attributes.GetNamedItem("NAME").Value;
            nw.Name = node.Attributes.GetNamedItem("AUTHOR").Value;
            nw.Amount = node.Attributes.GetNamedItem("AMOUNT").Value;
            return nw;
        }
        public static List<Paperwork> AllPaperworks(XmlDocument doc)
        {
            List<Paperwork> data2 = new List<Paperwork>();
            XmlNodeList elem = doc.SelectNodes("//paperwork");
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
        public static List<Paperwork> SearchByParam(string nodename, string val, string param, XmlDocument doc, int n)
        {
            List<Paperwork> paperworks = new List<Paperwork>();

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
                                            paperworks.Add(Info(ell));
                                        }
                                    }
                                }
                            }
                            catch { }
                            return paperworks;
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
                                        paperworks.Add(Info(el));
                                    }
                                }
                            }
                            catch { }
                            return paperworks;
                        }
                    case 2:
                        {

                            XmlNodeList elem = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in elem)
                                {
                                    paperworks.Add(Info(e));

                                }
                            }
                            catch { }
                            return paperworks;
                        }
                    default: break;
                }
            }
            return paperworks;
        }
        private static List<Paperwork> Cross(List<List<Paperwork>> list)
        {
            List<Paperwork> result = new List<Paperwork>();
            try
            {
                if (list != null)
                {
                    Paperwork[] st = list[0].ToArray();
                    if (st != null)
                    {
                        foreach (Paperwork elem in st)
                        {
                            bool IsIn = true;
                            foreach (List<Paperwork> t in list)
                            {
                                if (t.Count <= 0) return new List<Paperwork>();

                                foreach (Paperwork s in t)
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
