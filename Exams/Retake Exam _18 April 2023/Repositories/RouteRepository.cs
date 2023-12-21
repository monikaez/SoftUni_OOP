using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories;

public class RouteRepository : IRepository<IRoute>
{
    private List<IRoute> models;
    public RouteRepository()
    {
        this.models = new List<IRoute>();
    }

    public void AddModel(IRoute route)
    {
        this.models.Add(route);
    }

    public IRoute FindById(string identifier) => this.models.FirstOrDefault(p => p.RouteId == int.Parse(identifier));


    public IReadOnlyCollection<IRoute> GetAll() => this.models;


    public bool RemoveById(string identifier) => this.models.Remove(this.FindById(identifier));
    
}
