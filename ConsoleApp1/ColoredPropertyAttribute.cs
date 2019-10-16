using System;

namespace ConsoleApp1
{
    class ColoredPropertyAttribute : Attribute
    {
        public ConsoleColor Szine { get; set; }

        public ColoredPropertyAttribute(ConsoleColor szine)
        {
            this.Szine = szine;
        }
    }
}
