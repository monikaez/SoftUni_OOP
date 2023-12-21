﻿
using System;
namespace ClassBoxData.Models;


public class Program
{
    static void Main(string[] args)
    {//length, width, and height
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new(length, width, height);

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}
