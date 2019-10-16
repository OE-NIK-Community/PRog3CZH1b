using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Student
    {
        public Student(string name, string course, int mark, string type)
        {
            Name = name;
            Course = course;
            Mark = mark;
            Type = type;
        }
        [ColoredProperty(System.ConsoleColor.Red)]
        public string Name { get; set; }
        [ColoredProperty(System.ConsoleColor.Green)]

        public string Course { get; set; }
        [ColoredProperty(System.ConsoleColor.Blue)]

        public int Mark { get; set; }
        public string Type { get; set; }
        public static List<Student>CreateListofXML(string path)
        {
            //fuck this
            /* List<student> output=new List<student>();
             var XmlRoot = new XmlRootAttribute();
             XmlRoot.ElementName = "students";
            // XmlRoot.IsNullable = false;
             var de = new XmlSerializer(typeof(List<student>),XmlRoot);
             using (var sr = new StreamReader(path))
             {
                 var kecske  = de.Deserialize(sr) as List<student>;
                 int sajt = kecske.Count();
                 }
             return output;*/
            List<Student> output = new List<Student>();
            var studentxml = XDocument.Load(path);
            var sajt = studentxml.Element("students").Elements();
            foreach (var item in sajt)
            {
                var values = item.Descendants().Select(p => p.Value).ToArray();
                output.Add(new Student(
                     values[0],
                    values[1],
                   int.Parse(values[2]),
                   values[3]
                    ));
            }
            return output;
        }
    }
}
