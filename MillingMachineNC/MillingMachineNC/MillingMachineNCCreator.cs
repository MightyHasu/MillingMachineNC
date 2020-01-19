using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillingMachineNC
{
    class MillingMachineNCCreator
    {
        static void Main(string[] args)
        {
            string head = "G90 G70 \r\nG54\r\nG0 X0 Y0\r\nG0 Z0\r\n";
            int dwellTime = new int();
            int x = new int();
            int xCount = new int();
            int y;
            int yCount = new int();
            int z = new int();
            int zCount = new int();
            int angle = new int();
            int exposureTime = new int();
            System.Text.StringBuilder ncFile = new System.Text.StringBuilder();

            Console.WriteLine("\a Enter horizontal step in mm:");
            x = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter number horizontal steps");
            xCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter vertical step in mm");
            y = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter number of vertical steps");
            yCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter dept step in mm");
            z = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter number of depth steps");
            zCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter angle:");
            angle = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter dwell before shoot:");
            dwellTime = int.Parse(Console.ReadLine());

            Console.WriteLine("\a Enter exposure time:");
            exposureTime = int.Parse(Console.ReadLine());

            System.Text.StringBuilder path = new System.Text.StringBuilder();
            path.Append(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("MillingMachineNC.exe",""));             
            
            ncFile.Append(head);

            int zTemp = 0;
            for (int i = 0; i < zCount; i++)
            {
                int yTemp = 0;
                for (int j = 0; j < yCount; j++)
                {
                    int xTemp = 0;
                    for (int k = 0; k < xCount; k++)
                    {
                        double yMove = (yTemp * Math.Cos(angle)) + (zTemp * Math.Sin(angle));
                        double zMove = (yTemp * Math.Sin(angle)) - (zTemp * Math.Cos(angle));
                        ncFile.Append("G0 X" + xTemp + " Y" + yMove + " Z" + zMove + "\r\n");
                        ncFile.Append("G04 X" + dwellTime + "\r\n");
                        ncFile.Append("M8\r\n");
                        ncFile.Append("G04 X1\r\n");
                        ncFile.Append("M9\r\n");
                        ncFile.Append("G04 X" + exposureTime + "\r\n");
                        xTemp += x;
                    }

                    yTemp += y;
                }
                zTemp += z;
            }

            ncFile.Append("M30\r\n");
            
            FileWriterMighty.WriteFile(ncFile.ToString());

            string test = Form1.ActiveForm.Controls.
        }
    }
    
    class FileWriterMighty
    {
        public static void WriteFile(string lines)
        {
            System.IO.File.WriteAllText(@"C:\Users\PC2\Desktop\WriteLines.NC", lines);            
        }
    }
}
