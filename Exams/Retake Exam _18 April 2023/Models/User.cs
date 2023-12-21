using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public class User : IUser
{
    private string  firstName;
    private string  lastName;
    public string drivingLicenseNumber;
    private bool isBlocked;
    private double rating;

    public User(string firstName, string lastName, string drivingLicenseNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.drivingLicenseNumber = drivingLicenseNumber;
        this.isBlocked = false;
        //o Set Rating’s initial value to zero.
        this.rating = 0;
        //o Set IsBloked’s initial value to false
    }

    public string FirstName
    {
        get => firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));
            }
            firstName = value;

        }
    }
    // FirstName – string
    //o If the FirstName is null or whitespace, throw an ArgumentException with the message
    //"FirstName cannot be null or whitespace!"
    public string LastName 
    { 
        get=>lastName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
            }
            lastName = value;
        }
    }
    // LastName - string
    //o If the LastName is null or whitespace, throw an ArgumentException with the message
    //"LastName cannot be null or whitespace!"
    public double Rating => this.rating;
    // Rating – double
    public string DrivingLicenseNumber 
    {
        get => drivingLicenseNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));
            }
            drivingLicenseNumber = value;
        }
    }
    // DrivingLicenseNumber – string
    //o If the DrivingLicenseNumber is null or whitespace, throw an ArgumentException with the
    //message "Driving license number is required!"
    public bool IsBlocked => this.isBlocked;
    // IsBlocked – bool

   
    public void DecreaseRating()
    {
        if (this.rating < 2)
        {
            this.rating = 0;
            this.isBlocked = true;
        }
        else
        {
            this.rating -= 2;
        }
    }
//    void DecreaseRating()
//Еvery time a User rents a Vehicle and completes the trip with an accident, his Rating will decrease by 2.0:
//If the Rating’s value drops below 0.0, set the Rating’s value to 0.0 and IsBlocked’s value to true.

    public void IncreaseRating()
    {
        if (this.rating < 10)
        {
            this.rating += 0.5;
        }
    }
//    void IncreaseRating()
//Еvery time a User rents a Vehicle and completes the trip without any accidents, his Rating will increase by 0.5:
// If the Rating’s value exeeds 10.0, set the value to 10.0.

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} Driving license: {this.drivingLicenseNumber} Rating: {this.rating}";
    }

//    Override ToString() method:
//Override the existing method ToString() and modify it, so the returned string must be in the following format:
//"{FirstName} {LastName} Driving license: {drivingLicenseNumber} Rating: {rating}"
}




