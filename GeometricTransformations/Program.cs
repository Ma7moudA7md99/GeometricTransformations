using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
            Console.WriteLine("Do another operation ?\n" +
                "1- Yes\n" +
                "2- No");
            int decide = Convert.ToInt32(Console.ReadLine());
            if (decide == 1)
            {
                Console.Clear();
                point = enterVlas();
                choseop(point);

            };
            if (decide == 2) Environment.Exit(0);
            
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
            } else if (num == 2)
            {
                scalling(point);
            } else if (num == 3)
            {
                rotation(point);
            } else if(num == 4)
            {
                reflection(point);
            } else if(num == 5)
            {
                shearing(point);
            } else
            {
                Console.WriteLine("Wrong Choice");
                Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
                choseop(point);

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
        static void displayResult(double[,] point)
        {
            Console.WriteLine();
            Console.WriteLine("The new Point is : " + "( " + Math.Round(point[0, 0], 2) + " , " + Math.Round(point[1, 0], 2) + " )");
        }
        static double[,] translate(int[] point)
        {
            double tx, ty;
            Console.WriteLine("Enter Tx value:  ");
            tx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Ty value:  ");
            ty = Convert.ToDouble(Console.ReadLine());

            double[,] matrix = { 
                { 1, 0, tx },
                { 0, 1, ty },
                { 0, 0, 1 } 
            };
            double[,] pointMatrix = { 
                { point[0] },
                { point[1] },
                { 1 }
            };
            double[,] newPoint = new double[3, 1];

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
        static double[,] scalling(int[] point)
        {
            double sx, sy;
            Console.WriteLine("Enter Sx value:  ");
            sx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Sy value:  ");
            sy = Convert.ToDouble(Console.ReadLine());
            double[,] matrix = {
                { sx, 0, 0 },
                { 0, sy, 0 },
                { 0, 0, 1 }
            };
            double[,] pointMatrix = {
                { point[0] },
                { point[1] },
                { 1 }
            };

            double[,] newPoint = new double[3, 1];

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
        static double[,] rotation(int[] point)
        {
            double angle, degrees, sinAngle, cosAngle;
            Console.WriteLine("Enter Angel value in degrees:  ");
            angle = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The Rotation in ...\n" +
                "1- Counter Clockwise\n" +
                "2- Clockwise");
            int direction = Convert.ToInt32(Console.ReadLine());
            degrees = (double)(Math.PI * angle / 180.0);
            sinAngle = Math.Sin(degrees);
            cosAngle = Math.Cos(degrees);
            //Console.WriteLine("Enter Sy value:  ");
            //sy = Convert.ToInt32(Console.ReadLine());
            double[,] matrixCounter = {
                { cosAngle, (-sinAngle), 0 },
                { sinAngle, cosAngle, 0 },
                { 0, 0, 1 }
            };
            double[,] matrixClock = {
                { cosAngle, sinAngle, 0 },
                { (-sinAngle), cosAngle, 0 },
                { 0, 0, 1 }
            };
            double[,] pointMatrix = {
                { point[0] },
                { point[1] },
                { 1 }
            };

            double[,] newPoint = new double[3, 1];

            if(direction == 1) {
                newPoint[0, 0] =
                    (matrixCounter[0, 0] * pointMatrix[0, 0]) +
                    (matrixCounter[0, 1] * pointMatrix[1, 0]) +
                    (matrixCounter[0, 2] * pointMatrix[2, 0]);
                newPoint[1, 0] =
                    (matrixCounter[1, 0] * pointMatrix[0, 0]) +
                    (matrixCounter[1, 1] * pointMatrix[1, 0]) +
                    (matrixCounter[1, 2] * pointMatrix[2, 0]);
                newPoint[2, 0] = 1;
            }

            displayResult(newPoint);
            return newPoint;
        }
        static double[,] reflection(int[] point)
        {
            Console.WriteLine("The Reflection will be around\n" +
                "1- X-axis\n" +
                "2- Y-axis\n" +
                "3- Origin point");

            int decide = Convert.ToInt32(Console.ReadLine());

            
            double[,] xMatrix = {
                { 1, 0, 0 },
                { 0, -1, 0 },
                { 0, 0, 1 }
            };
            double[,] yMatrix = {
                { -1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            double[,] originMatrix = {
                { -1, 0, 0 },
                { 0, -1, 0 },
                { 0, 0, 1 }
            };
            double[,] pointMatrix = {
                { point[0] },
                { point[1] },
                { 1 }
            };

            double[,] newPoint = new double[3, 1];

            if (decide == 1)
            {
                newPoint[0, 0] =
                (xMatrix[0, 0] * pointMatrix[0, 0]) +
                (xMatrix[0, 1] * pointMatrix[1, 0]) +
                (xMatrix[0, 2] * pointMatrix[2, 0]);
                newPoint[1, 0] =
                    (xMatrix[1, 0] * pointMatrix[0, 0]) +
                    (xMatrix[1, 1] * pointMatrix[1, 0]) +
                    (xMatrix[1, 2] * pointMatrix[2, 0]);
                newPoint[2, 0] = 1;
            }
            if(decide == 2)
            {
                newPoint[0, 0] =
                    (yMatrix[0, 0] * pointMatrix[0, 0]) +
                    (yMatrix[0, 1] * pointMatrix[1, 0]) +
                    (yMatrix[0, 2] * pointMatrix[2, 0]);
                newPoint[1, 0] =
                    (yMatrix[1, 0] * pointMatrix[0, 0]) +
                    (yMatrix[1, 1] * pointMatrix[1, 0]) +
                    (yMatrix[1, 2] * pointMatrix[2, 0]);
                newPoint[2, 0] = 1;
            }
            if(decide == 3)
            {
                newPoint[0, 0] =
                    (originMatrix[0, 0] * pointMatrix[0, 0]) +
                    (originMatrix[0, 1] * pointMatrix[1, 0]) +
                    (originMatrix[0, 2] * pointMatrix[2, 0]);
                newPoint[1, 0] =
                    (originMatrix[1, 0] * pointMatrix[0, 0]) +
                    (originMatrix[1, 1] * pointMatrix[1, 0]) +
                    (originMatrix[1, 2] * pointMatrix[2, 0]);
                newPoint[2, 0] = 1;
            }
            displayResult(newPoint);
            return newPoint;
        }
        static double[,] shearing(int[] point)
        {
            double shx, shy;
            Console.WriteLine("Enter Shx value:  ");
            shx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Shy value:  ");
            shy = Convert.ToDouble(Console.ReadLine());
            double[,] matrix = {
                { 1, shy, 0 },
                { shx, 1, 0 },
                { 0, 0, 1 }
            };
            double[,] pointMatrix = {
                { point[0] },
                { point[1] },
                { 1 }
            };

            double[,] newPoint = new double[3, 1];

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
