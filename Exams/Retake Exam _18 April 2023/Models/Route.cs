using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public class Route : IRoute
{
    private string startPoint;
    private string endPoint;
    private double length;
    private int routeId;
    private bool isLocked;

                //string startPoint, string endPoint, double length, int routeId
    public Route(string startPoint, string endPoint, double length, int routeId)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.length = length;
        this.routeId = routeId;
        this.isLocked = false;
    }

    public string StartPoint 
    {
        get => startPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StartPointNull));
            }
            startPoint = value;
        }
    }
    //     StartPoint – string
    //o If the StartPoint is null or whitespace, throw an ArgumentException with the message
    //"StartPoint cannot be null or whitespace!"
    public string EndPoint 
    {
        get => endPoint;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EndPointNull));
            }
            endPoint = value;
        }
    }
    //    EndPoint - string
    //o If the EndPoint is null or whitespace, throw an ArgumentException with the message "Endpoint
    //cannot be null or whitespace!"

    public double Length 
    { get => length;
        private set
        {
            if (value<1)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RouteLengthLessThanOne));
            }
            length = value;
        }
    }
    //    Lenght – double
    //o If the value is less than 1, throw an ArgumentException with the message "Length cannot be
    //less than 1 kilometer.".

    public int RouteId => this.routeId;
    //RouteId – int

    public bool IsLocked => this.isLocked;
    //    IsLocked – bool
    //o Set IsLocked’s initial value to false
    public void LockRoute()
    {
        this.isLocked = true;
    }
    //void LockRoute()
    //This method sets the value of the property IsLocked to true.
}
