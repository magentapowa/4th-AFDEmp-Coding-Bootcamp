using System;
using System.Collections.Generic;

namespace CB4_CS_WEx02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Shape s1 = new Shape();
            s1.SetColor(Color.White);
            Console.WriteLine(s1.GetInfo());


            Rectangle r1 = new Rectangle(20, 5);
            Rectangle r2 = new Rectangle(2, 8);
            Rectangle r3 = new Rectangle(1, 1);
            Rectangle r4 = new Rectangle(5, 9);
            r1.SetColor(Color.Orange);
            r2.SetColor(Color.Magenta);
            r3.SetColor(Color.Blue);
            r4.SetColor(Color.White);

            Square sq1 = new Square(10);
            Square sq2 = new Square(20);
            Square sq3 = new Square(7);
            sq1.SetColor(Color.Black);
            sq2.SetColor(Color.Orange);
            sq3.SetColor(Color.Red);


            List<Rectangle> myShapeList = new List<Rectangle>();
            myShapeList.Add(r1);
            myShapeList.Add(r2);
            myShapeList.Add(sq1);
            myShapeList.Add(sq2);
            myShapeList.Add(r3);
            myShapeList.Add(sq3);
            myShapeList.Add(r4);

            Console.WriteLine("\nMy list:");
            for (int i = 0; i < myShapeList.Count; i++)
            {
                Console.WriteLine(myShapeList[i] + $"   Area= {myShapeList[i].GetArea()}");
            }

            myShapeList.Sort();

            Console.WriteLine("\nMy list after sorting:");
            for (int i = 0; i < myShapeList.Count; i++)
            {
                Console.WriteLine(myShapeList[i] + $"   Area= {myShapeList[i].GetArea()}");
            }
        }
    }
}
