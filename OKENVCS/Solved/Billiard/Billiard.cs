using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner(false);
    const double RADII_TO_DEGRESS = 57.2957795;
    public static void Main(string[] args)
    {
        while (true)
        {
            
            int A = io.NextInt(); //horizontal
            int B = io.NextInt(); //vertical
            int S = io.NextInt(); //seconds
            int M = io.NextInt(); //vertical bounces
            int N = io.NextInt(); //horizontal bounces

            if((A + B) == 0)
            {
                return;
            }
            else {
                double distH = A * M;
                double distV = B * N;
                double velocityX = distH / S; // in inches per second
                double velocityY = distV / S; // in inches per second

                double slopeAngle = velocityX == 0 ? 90 : Math.Round((RADII_TO_DEGRESS * Math.Atan2(velocityY, velocityX)), 2);
                double inchesPerSecond = Math.Round(Math.Sqrt(Math.Pow(distH, 2) + Math.Pow(distV, 2)) / S, 2);
                Console.WriteLine("{0:0.00} {1:0.00}", slopeAngle, inchesPerSecond);
            }

        }
        io.wait();
    }
}

