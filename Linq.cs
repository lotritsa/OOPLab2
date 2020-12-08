using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    class Linq : IStrategy
    {
        List<Paperwork> info = new List<Paperwork>();
        XDocument doc = new XDocument();
        public Linq (string path)
        {
            doc = XDocument.Load(path);
        }
        public List<Paperwork> Algorithm (Paperwork paperwork, string path)
        {
            List<XElement> match = (from val in doc.Descendants("paperwork")
                                   where
                                   ((paperwork.Course == null || paperwork.Course == val.Parent.Parent.Attribute("COURSE").Value) &&
                                    (paperwork.Group == null || paperwork.Group == val.Parent.Attribute("TYPE").Value) &&
                                    (paperwork.DateOfCreation == null || paperwork.DateOfCreation == val.Attribute("DATEOFCREATION").Value) &&
                                    (paperwork.Surname == null || paperwork.Surname == val.Attribute("NAME").Value) &&
                                    (paperwork.Name == null || paperwork.Name == val.Attribute("AUTHOR").Value) &&
                                    (paperwork.Amount == null || paperwork.Amount == val.Attribute("AMOUNT").Value))
                                   select val).ToList();
            foreach (XElement obj in match)
            {
                Paperwork paperwork1 = new Paperwork();
                paperwork1.Course = obj.Parent.Parent.Attribute("COURSE").Value;
                paperwork1.Group = obj.Parent.Attribute("TYPE").Value;
                paperwork1.DateOfCreation = obj.Attribute("DATEOFCREATION").Value;
                paperwork1.Surname = obj.Attribute("NAME").Value;
                paperwork1.Name = obj.Attribute("AUTHOR").Value;
                paperwork1.Amount = obj.Attribute("AMOUNT").Value;
                info.Add(paperwork1);

            }
            return info;
        }
    }
}
