using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates; 
using System.Text;
using System.Threading.Tasks;


namespace GeometricTransformations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] point = enterVlas();
            choseop(point);
            Console.ReadKey();
            
        }
        static void choseop(int[] point)
        {
            Console.WriteLine("1- Translation \n" +
                "2- Scalling \n" +
                "3- Rotation \n" +
                "4- Reflection \n" +
                "5- Shearing \n"
                );
            Console.WriteLine("Choose the numbr of the operation you want :");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                translate(point);
            }
        }
        static int[] enterVlas() {
            int x, y;
            Console.WriteLine("Enter X value:  ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Y value:  ");
            y = Convert.ToInt32(Console.ReadLine());
            return new int[] { x, y };
        }
        static void displayResult(int[,] point)
        {
            Console.WriteLine();
            Console.WriteLine("The new Point is : " + "( " + point[0, 0] + " , " + point[1, 0] + " )");
        }
        static int[,] translate(int[] point)
        {
            int tx, ty;
            Console.WriteLine("Enter Tx value:  ");
            tx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ty value:  ");
            ty = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = { 
                { 1, 0, tx },
                { 0, 1, ty },
                { 0, 0, 1 } 
            };
            int[,] pointMatrix = { 
                { point[0] },
                { point[1] },
                { 1 }
            };
            int[,] newPoint = new int[3, 1];

            newPoint[0, 0] = 
                (matrix[0, 0] * pointMatrix[0, 0]) + 
                (matrix[0, 1] * pointMatrix[1, 0]) + 
                (matrix[0, 2] * pointMatrix[2, 0]);
            newPoint[1, 0] =
                (matrix[1, 0] * pointMatrix[0, 0]) +
                (matrix[1, 1] * pointMatrix[1, 0]) +
                (matrix[1, 2] * pointMatrix[2, 0]);
            newPoint[2, 0] = 1;
            
            displayResult(newPoint);
            return newPoint;
        }
    }
}
