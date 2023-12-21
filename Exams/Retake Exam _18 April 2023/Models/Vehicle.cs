using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public class Vehicle : IVehicle
{
    private string brand;
    private string model;
    private double maxMileage;
    private string licensePlateNumber;
    private int batteryLevel;
    private bool isDamaged;

    //string brand, string model, double maxMileage, string licensePlateNumber
    public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
    {
        this.brand = brand;
        this.model = model;
        this.maxMileage = maxMileage;
        this.licensePlateNumber = licensePlateNumber;
        this.batteryLevel = 100;
        //o Set BatteryLevel’s initial value to 100. This would be 100%. The value of the BatteryLevel will
        //be changed every time a User drives a Vehicle or the Vehicle is being recharged.Remember to
        //keep the setter private.
        this.isDamaged = false;
        //o Set IsDamaged’s initial value to false
    }

    public string Brand 
    {
        get => brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
            }
            brand = value;
        }
    }
    //     Brand – string
    //o If the Brand is null or whitespace, throw an ArgumentException with the message "Brand cannot
    //be null or whitespace!"
    public string Model 
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
            }
            model = value;
        }
    }
    //     Model - string
    //o If the Model is null or whitespace, throw an ArgumentException with the message "Model cannot
    //be null or whitespace!
    public double MaxMileage =>this.maxMileage;
    //MaxMilеage - double

    public string LicensePlateNumber 
    {
        get => licensePlateNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));
            }
            licensePlateNumber = value;
        }
    }
    //LicensePlateNumber – string
    //o If the LicensePlateNumber is null or whitespace, throw an ArgumentException with the
    //message "License plate number is required!"
    public int BatteryLevel => this.batteryLevel;
    // BatteryLevel – int
    public bool IsDamaged => this.isDamaged;
    // IsDamaged – bool
    public void ChangeStatus()
    {
        if (!IsDamaged)
        {
            this.isDamaged = true;
        }
        else
        {
            this.isDamaged = false;
        }
    }
    //    void ChangeStatus()
    //This method sets value of the property IsDamaged.
    // If the value is false, set it to true
    // Else set it to false

    public void Drive(double mileage)
    {
        double percentage = Math.Round((mileage / this.maxMileage) * 100);
        this.batteryLevel -= (int)percentage;

        if (this.GetType().Name == nameof(CargoVan))
        {
            this.batteryLevel -= 5;
        }
    }

    public void Recharge()
    {
        this.batteryLevel = 100;
    }
        //    void Recharge()
        //This method restores the value of the property BatteryLevel to 100%.

    public override string ToString()
    {
        string vehicleCondition;
        if (isDamaged)
        {
            vehicleCondition = "damaged";
        }
        else
        {
            vehicleCondition = "OK";
        }
        return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {vehicleCondition}";

    }




    //    Override ToString() method:
    //Override the existing method ToString() and modify it, so the returned string must be in the following format:
    //"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status:
    //OK/damaged"
}




