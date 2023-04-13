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
            choseop();
            Console.ReadKey();
            
        }
        static void choseop()
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
            }
        }
        static int enterVlas() {
            int x, y;
            Console.WriteLine("Enter X value:  ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Y value:  ");
            y = Convert.ToInt32(Console.ReadLine());
            return x;
        }
        public int translate(int x, int y)
        {
            int tx, ty;
            Console.WriteLine("Enter Tx value:  ");
            tx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ty value:  ");
            ty = Convert.ToInt32(Console.ReadLine());

            int[][] matrix = { };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0 && j == 2 || i == 1 && j == 2)
                    {
                        matrix[0][2] = tx;
                        matrix[1][2] = ty;
                    }
                    matrix[i][j] = Convert.ToInt32(Console.ReadLine());

                }

            }
            return 0;
        }
    }
}
