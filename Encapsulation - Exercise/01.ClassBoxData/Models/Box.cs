using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData.Models;

public class Box
//length, width, and height
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double Width
    {
        get => width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get => height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            height = value;
        }
    }
    public double SurfaceArea()
        => 2 * Length * Width + LateralSurfaceArea();
    public double LateralSurfaceArea()
        => 2 * Length * Height + 2 * Width * Height;
    public double Volume()
        => Length * Width * Height;


}







////Create a class Box, which has the following properties:
// Length - double, should not be zero or negative number
// Width - double, should not be zero or negative number
// Height - double, should not be zero or negative number
////If one of the properties is a zero or negative number throw ArgumentException with the message: 
//"{propertyName} cannot be zero or negative." Use try-catch block to process the error.All properties are set by
//the constructor and when set, they cannot be modified.
