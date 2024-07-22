using C42_G01_OOP05.Duration;
using C42_G01_OOP05.Point;

namespace C42_G01_OOP05
{
    internal class Program
    {
        static void Main()
        {
            
            #region First Project 
            //2.
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            //3.
            Point3D P1;
            Point3D P2;

            int[] P1Points = new int[3];
            int[] P2Points = new int[3];

            bool flag = true;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    do
                    {
                        string message;
                        message = flag ? $"Please enter the P{j + 1} point({i + 1})" : "Please enter valid point number";
                        Console.WriteLine(message);
                        flag = int.TryParse(Console.ReadLine(), out P1Points[i]);
                    } while (!flag);
                }
            }
            P1 = new Point3D(P1Points[0], P1Points[1], P1Points[2]);
            P2 = new Point3D(P2Points[0], P2Points[1], P2Points[2]);

            //4.Does it work properly? 
            //No, it doesn't, because it requires casting operator overloading 
            if (P1 == P2) 
            {
                Console.WriteLine("It works!!"); //will never called
            }

            //5. 
            Point3D[] point3Ds =  { new Point3D( 5, 5, 6 ), new Point3D(4, 9, 7), new Point3D(5, 3, 6), new Point3D(9, 9, 9) };
            Array.Sort(point3Ds);
            for (int i = 0;i < point3Ds.Length;i++)
            {
                Console.WriteLine(point3Ds[i]);
            }

            Point3D P4 = (Point3D)point3Ds[1].Clone();
            Console.WriteLine(P4);

            #endregion

            #region Second Project
            Console.WriteLine(Maths.Maths.Add(10, 20));
            Console.WriteLine(Maths.Maths.Subtract(10, 20));
            Console.WriteLine(Maths.Maths.Multiply(10, 20));
            Console.WriteLine(Maths.Maths.Divide(10, 20));
            #endregion
            
            #region Third Project
            Duration.Duration D1 = new Duration.Duration(1, 10, 15);
            Console.WriteLine(D1.ToString());

            Duration.Duration D2 = new Duration.Duration(3600);
            Console.WriteLine(D2.ToString());
            
            Duration.Duration D3 = new Duration.Duration(7800);
            Console.WriteLine(D3.ToString());            
            
            Duration.Duration D4 = new Duration.Duration(666);
            Console.WriteLine(D4.ToString());

            D3 = D1 + D2;
            Console.WriteLine(D3.ToString());

            D3 = D1 + 7800;
            Console.WriteLine(D3.ToString());

            D3 = 666 + D3;
            Console.WriteLine(D3.ToString());

            ++D3;
            Console.WriteLine(D3.ToString());
            
            --D3;
            Console.WriteLine(D3.ToString());

            Console.WriteLine(D1 > D2);

            Console.WriteLine(D1 <= D2);

            if (D1)
            {
                Console.WriteLine($"D1: {D1}");
            }

            Duration.Duration D5 = null;
            if (D5)
            {
                Console.WriteLine($"D3: {D3}"); //will never called
            }

            DateTime Obj = (DateTime)D1;
            Console.WriteLine(Obj);

            
            #endregion
        }
    }
}
