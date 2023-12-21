using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EDriveRent.Core;

public class Controller : IController
{
    //     users – UserRepository
    // vehicles – VehicleRepository
    // routes – RouteRepository
    private IRepository<IUser> users;
    private IRepository<IVehicle> vehicles;
    private IRepository<IRoute> routes;

    public Controller()
    {
        this.users = new UserRepository();
        this.vehicles = new VehicleRepository();
        this.routes = new RouteRepository();
    }

    //    HINT: Route’s constructor will be expecting as the last parameter routeId.So it should be created by taking
    //the count of already added routes in the RouteRepository + 1.
    // If there is already added Route with the given startPoint, endPoint and length, return the following
    //message: "{startPoint}/{endPoint} - {length} km is already added in our platform."
    // If there is already added Route with the given startPoint, endPoint and Route.Length is less than
    //the given length return the following message: "{startPoint}/{endPoint} shorter route is
    //already added in our platform."
    // If the above case is not reached, create a new Route and add it to the RouteRepository
    //o If there is already added Route with the given startPoint, endPoint and greater Length, lock
    //the longer Route.
    //o Return the following message: "{startPoint}/{endPoint} - {length} km is unlocked in
    //our platform."
    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        int routeId = this.routes.GetAll().Count + 1;
        IRoute existingRoute = this.routes
            .GetAll()
            .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

        if (existingRoute != null)
        {
            if (existingRoute.Length == length)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            else if (existingRoute.Length < length)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint, length);
            }
            else if (existingRoute.Length > length)
            {
                existingRoute.LockRoute();
            }
        }
        //Add new route
        IRoute newRoute = new Route(startPoint, endPoint, length, routeId);
        this.routes.AddModel(newRoute);
        return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint,length);
      
    }

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
    {
        IUser user = this.users.FindById(drivingLicenseNumber);
        IVehicle vehicle = this.vehicles.FindById(licensePlateNumber);
        IRoute route = this.routes.FindById(routeId);

        //If the User with the given drivingLicenseNumber is blocked (User.IsBlocked == true) in the
        //application, abort the trip and return the following message: "User {drivingLicenseNumber} is
        //blocked in the platform!Trip is not allowed."
        if (user.IsBlocked)
        {
            return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }
        //        If the Vehicle with the given licensePlateNumber is damaged(Vehicle.IsDamaged == true) in
        //the application, abort the trip and return the following message: "Vehicle {licensePlateNumber} is
        //damaged! Trip is not allowed."
        if (vehicle.IsDamaged)
        {
            return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }
        //        If the Route with the given routeId is locked(Route.IsLocked == true) in the application, abort the
        //trip and return the following message: "Route {routeId} is locked! Trip is not allowed."
        if (route.IsLocked)
        {
            return string.Format(OutputMessages.RouteLocked, routeId);
        }
        //        Drive the specific vehicle on the specific route(Use the Vehicle.Drive(route.Length) method). The
        //trip should take effect to the BatteryLevel of the vehicle
        vehicle.Drive(route.Length);

        if (isAccidentHappened)
        {
            vehicle.ChangeStatus();
            user.DecreaseRating();
        }
        else
        {
            user.IncreaseRating();
        }

        return vehicle.ToString();
    }

    //    The method should create and add a new entity of IUser to the UserRepository.
    // If there is already a user with the same drivingLicenseNumber, return the following message:
    //"{drivingLicenseNumber} is already registered in our platform."
    // If the above case is NOT reached, create a new User and add it to the UserRepository.Return the
    //following message: "{firstName} {lastName} is registered successfully with DLN-
    //{drivingLicenseNumber
    //}"
    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {
        IUser user = this.users.FindById(drivingLicenseNumber);
        if (user != null)
        {
            return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }
        user = new User(firstName, lastName, drivingLicenseNumber);
        this.users.AddModel(user);
        return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
    }


    public string RepairVehicles(int count)
    {
        var damagedVehicles = this.vehicles.GetAll().Where(v => v.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model);
        //Each of the chosen vehicles will be repaired (IsDamaged == false) and recharged (battery level restored to
        //        100 %).
        // Return the following message: "{countOfRepairedVehicles} vehicles are successfully
        //repaired!
        int vehiclesCount = 0;

        if (damagedVehicles.Count() < count)
        {
            vehiclesCount = damagedVehicles.Count();
        }
        else
        {
            vehiclesCount = count;
        }

        var selectedVehicles = damagedVehicles.ToArray().Take(vehiclesCount);

        foreach (var vehicle in selectedVehicles)
        {
            vehicle.ChangeStatus();
            vehicle.Recharge();
        }

        return string.Format(OutputMessages.RepairedVehicles, vehiclesCount);
    }

    //    The method should create and add a new entity of IVehicle to the VehicleRepository.
    // If the given vehicleTypeName is NOT presented as a valid Vehicle’s child class (PassengerCar or
    //CargoVan), return the following message: "{typeName} is not accessible in our platform."
    // If there is already a vehicle with the same licensePlateNumber, return the following message:
    //"{licensePlateNumber} belongs to another vehicle."
    // If none of the above cases is reached, create a correct type of IVehicle and add it to the
    //VehicleRepository.Return the following message: "{brand} {model} is uploaded
    //successfully with LPN-{ licensePlaneNumber}"

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {
        if (vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
        {
            return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);

        }

        IVehicle vehicle = this.vehicles.FindById(licensePlateNumber);
        if (vehicle != null)
        {
            return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }
        else
        {
            if (vehicleType == nameof(PassengerCar))
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            if (vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            this.vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
    }

    public string UsersReport()
    {
        StringBuilder sb = new();
        sb.AppendLine($"*** E-Drive-Rent ***");
        foreach (var user in this.users.GetAll()
            .OrderByDescending(u=>u.Rating)
            .ThenBy(u=>u.LastName)
            .ThenBy(u=>u.FirstName))
        {
            sb.AppendLine(user.ToString());
        }
        return sb.ToString().TrimEnd();
       
    }
}
