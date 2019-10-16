using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sajt = Student.CreateListofXML("Students.xml");
            CourseModelEntities course = new CourseModelEntities();
            Neptun lefagy = new Neptun(sajt, course);
            LinqResultConsole.DisplayResult(sajt);
            lefagy.OpreHallgatokNeve();
            lefagy.TantargyAtlagokRovidNevekkel();
            lefagy.TantargyAtlagokHosszuNevekkel();
            lefagy.TantargyakEsTanulok();
            Console.ReadLine();
        }
    }
   class ColoredPropertyAttribute : Attribute
    {
        public ConsoleColor Szine { get; set; }

        public ColoredPropertyAttribute(ConsoleColor szine)
        {
            this.Szine = szine;
        }
    }
}
