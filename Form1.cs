using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string path = "ElectronicArchive.xml";
        List<Paperwork> final = new List<Paperwork>();
        public Form1()
        {
            
            InitializeComponent();
            GetAllPaperworks();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Paperwork _paperwork = OurPaperwork();
            if (LINQ.Checked)
            {
                IStrategy CurrentStrategy = new Linq(path);
                final = CurrentStrategy.Algorithm(_paperwork, path);
                Output(final);
            }
            if (DOM.Checked)
            {
                IStrategy CurrentStrategy = new Dom(path);
                final = CurrentStrategy.Algorithm(_paperwork, path);
                Output(final);
            }
            if (SAX.Checked)
            {
                IStrategy CurrentStrategy = new Sax(path);
                final = CurrentStrategy.Algorithm(_paperwork, path);
                Output(final);
            }
        }
        private Paperwork OurPaperwork()
        {
            string[] info = new string[6];
            if (CourseCheckBox.Checked) info[0] = Convert.ToString(CourseBox.Text);
            if (TypeCheckBox.Checked) info[1] = Convert.ToString(TypeBox.Text);
            if (DateCheckBox.Checked) info[2] = Convert.ToString(DateBox.Text);
            if (NameCheckBox.Checked) info[3] = Convert.ToString(NameBox.Text);
            if (AuthorCheckBox.Checked) info[4] = Convert.ToString(AuthorBox.Text);
            if (AmountCheckBox.Checked) info[5] = Convert.ToString(AmountBox.Text);
            Paperwork IdealPaperwork = new Paperwork(info);
            return IdealPaperwork;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            CourseCheckBox.Checked = false;
            TypeCheckBox.Checked = false;
            NameCheckBox.Checked = false;
            AuthorCheckBox.Checked = false;
            DateCheckBox.Checked = false;
            AmountCheckBox.Checked = false;
            CourseBox.Text = null;
            TypeBox.Text = null;
            NameBox.Text = null;
            DateBox.Text = null;
            AuthorBox.Text = null;
            AmountBox.Text = null;
        }

        void Output(List <Paperwork> final)
        {
            int i = 1;
            Console.WriteLine("Alg+");
            foreach (Paperwork n  in final)
            {
                richTextBox1.AppendText("~~~~~~~~~~~~( " + i++ + " )~~~~~~~~~~~~" + "\n");
                richTextBox1.AppendText("Course: " + n.Course + "\n");
                richTextBox1.AppendText("Type: " + n.Group + "\n");
                richTextBox1.AppendText("Date of creation: " + n.DateOfCreation + "\n");
                richTextBox1.AppendText("Name: " + n.Surname + "\n");
                richTextBox1.AppendText("Author: " + n.Name + "\n");
                richTextBox1.AppendText("Amount: " + n.Amount + "\n");
               // richTextBox1.AppendText("---------------------------\n");


            }
        }
        public void GetAllPaperworks()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ElectronicArchive.xml");
            XmlNodeList elem = doc.SelectNodes("//course");
            foreach(XmlNode e in elem)
            {
                XmlNodeList list1 = e.ChildNodes;
                foreach (XmlNode el in list1)
                {
                    XmlNodeList list2 = el.ChildNodes;
                    foreach (XmlNode ell in list2)
                    {
                        string course = ell.ParentNode.ParentNode.Attributes.GetNamedItem("COURSE").Value;
                        if (!CourseBox.Items.Contains(course))
                            CourseBox.Items.Add(course);
                        string group = ell.ParentNode.Attributes.GetNamedItem("TYPE").Value;
                        if (!TypeBox.Items.Contains(group))
                            TypeBox.Items.Add(group);
                        string room = ell.Attributes.GetNamedItem("DATEOFCREATION").Value;
                        if (!DateBox.Items.Contains(room))
                            DateBox.Items.Add(room);
                        string surname = ell.Attributes.GetNamedItem("NAME").Value;
                        if (!NameBox.Items.Contains(surname))
                            NameBox.Items.Add(surname);
                        string name = ell.Attributes.GetNamedItem("AUTHOR").Value;
                        if (!AuthorBox.Items.Contains(name))
                            AuthorBox.Items.Add(name);
                        string phonenumber = ell.Attributes.GetNamedItem("AMOUNT").Value;
                        if (!AmountBox.Items.Contains(phonenumber))
                            AmountBox.Items.Add(phonenumber);
                        /*
                        GroupBox1.Items.Add(ell.ParentNode.Attributes.GetNamedItem("TYPE").Value);
                        DateOfCreationBox.Items.Add(ell.Attributes.GetNamedItem("DATEOFCREATION").Value);
                        SurnameBox.Items.Add(ell.Attributes.GetNamedItem("NAME").Value);
                        NameBox.Items.Add(ell.Attributes.GetNamedItem("AUTHOR").Value);
                        PhoneBox.Items.Add(ell.Attributes.GetNamedItem("AMOUNT").Value);
                        */

                    }
                }
            }
        }

        private void TransformToHTML_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("kek.xsl");
            string input = @"ElectronicArchive.xml";
            string output = @"information.html";
            xslt.Transform(input, output);
        }
    }
}
