﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.dev
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Core.IsDebug = true;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Bitmap maplab = new Bitmap(Properties.Resources.Capture, new Size(237, 30));
            DrawPic(maplab, true);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Bitmap mapli = new Bitmap(Properties.Resources._4, new Size(237, 100));
            DrawPic(mapli);
            Console.ForegroundColor = ConsoleColor.White;
            Bitmap mapd = new Bitmap(Properties.Resources._5, new Size(237, 100));
            DrawPic(mapd);
            Console.ForegroundColor = ConsoleColor.Red;
            Bitmap mapq = new Bitmap(Properties.Resources._9, new Size(237, 100));
            DrawPic(mapq);
            Console.ForegroundColor = ConsoleColor.Green;
            Bitmap map = new Bitmap(Properties.Resources.Capture2, new Size(237, 20));
            DrawPic(map);
            Console.ForegroundColor = ConsoleColor.Red;
            Bitmap map2 = new Bitmap(Properties.Resources._8, new Size(237, 100));
            DrawPic(map2);
            Console.ForegroundColor = ConsoleColor.Green;
            Bitmap map1 = new Bitmap(Properties.Resources.Capture1, new Size(237, 20));
            DrawPic(map1);

            Console.WriteLine("\n\n\nPress Enter To Continue : Hasi");
            Console.ReadLine();
            LankaStocks.Program.Main();
        }

        static void DrawPic(Bitmap myBitmap, bool Invert = false)
        {
            bool black = false;
            string s = "";
            for (int y = 0; y < myBitmap.Height; y++)
            {
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    Color pixelColor = myBitmap.GetPixel(x, y);
                    if (pixelColor.R < 100 && pixelColor.G < 100 && pixelColor.B < 100) black = true;
                    else black = false;
                    if (black)
                    {
                        if (!Invert)
                            s += "@";
                        else s += " ";
                    }
                    else
                    {
                        if (!Invert)
                            s += " ";
                        else s += "@";
                    }
                }
                s += "\n";
            }
            myBitmap.Dispose();
            Console.WriteLine(s);
        }
    }
}