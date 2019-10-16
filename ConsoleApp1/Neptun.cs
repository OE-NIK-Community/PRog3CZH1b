using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Neptun
    {
        List<Student> hallgatok;
        CourseModelEntities course;

        public Neptun(List<Student> hallgatok, CourseModelEntities course)
        {
            this.hallgatok = hallgatok;
            this.course = course;
        }
        public void OpreHallgatokNeve()
        {
           var query= hallgatok.Where(p => p.Course == "opre").Select(p=>p.Name);
            LinqResultConsole.DisplayResult(query);
        }
       public  void TantargyAtlagokRovidNevekkel()
        {
            var query = hallgatok.GroupBy(
                p => p.Course,
                p => p.Mark,
                (key, marks) => new
                {
                    
                    Targy = key,
                    Atlag = marks.Average()
                });
            LinqResultConsole.DisplayResult(query);
        }
        public void TantargyAtlagokHosszuNevekkel()
        {
            var query = hallgatok.GroupBy(
                p => p.Course,
                p => p.Mark,
                (key, marks) => new
                {
                    Targy = course.courses.First(p => p.courseShortName == key).courseLongName,
                    Atlag = marks.Average()
                }) ; ;
            LinqResultConsole.DisplayResult(query);
        }
        public void TantargyakEsTanulok()
        {
            var query = hallgatok.GroupBy(
                p => p.Name,
                p => p.Course,
                (key, targy) => new
                {
                    Nev = key,
                    Targyak = course.courses.Where(p => targy.Contains(p.courseShortName)).Select(p => p.courseLongName).ToArray()
                    .Aggregate("",(current,next)=>current+", "+next)

                }
                ); ; ;
            LinqResultConsole.DisplayResult(query);
        }
    }
}
