using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories;

public class FishRepository : IRepository<IFish>
{

    private List<IFish> fish;
    public FishRepository()
    {
        fish = new List<IFish>();
    }
    public IReadOnlyCollection<IFish> Models => this.fish;

    public void AddModel(IFish model)
    {
        this.fish.Add(model);
    }

    public IFish GetModel(string name) => this.Models.FirstOrDefault(x => x.Name == name);
}
