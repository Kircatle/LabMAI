using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figure = new Figure[4];
            figure[0] = new Circle(10, "Круг");
            figure[1] = new Triangle(2, 3, 4, "Треугольник");
            figure[2] = new RightTriangle(3, 4, 5, "Прямоугольный треугольник");
            figure[3] = new Rectangle(2, 3, "Прямоугольник");

            foreach (var f in figure)
            {
                if (f is Circle)
                {
                    ((Circle)f).standartCharacteristic();
                    Console.WriteLine("P = {0}\ndiametr = {1}\n", ((Circle)f).P(), ((Circle)f).diametr());
                }
                else if (f is RightTriangle)
                {
                    ((RightTriangle)f).standartCharacteristic();
                    Console.WriteLine("S = {0}\nH = {1}\nbiss = {2}\n", ((RightTriangle)f).S(), ((RightTriangle)f).Ha(), ((RightTriangle)f).Biss90());
                }
                else if (f is Triangle)
                {
                    ((Triangle)f).standartCharacteristic();
    
                    Console.WriteLine("S = {0}\nH = {1}\n", ((Triangle)f).S(), ((Triangle)f).Ha());
                }
                else if (f is Rectangle)
                {
                    ((Rectangle)f).standartCharacteristic();
                    Console.WriteLine("S = {0}\nP = {1}\ndiagonal = {2}\n", ((Rectangle)f).S(), ((Rectangle)f).P(), ((Rectangle)f).diagonal());
                }
            }
            Console.Read();
        
        }

    }
}
