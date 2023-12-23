using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    //  •	divers - DiverRepository
    //•	fish - FishRepository
    private IRepository<IDiver> divers;
    private IRepository<IFish> fish;

    public Controller()
    {
        divers = new DiverRepository();
        fish = new FishRepository();
    }
    //ChaseFish Command
    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {
        //•	Validates if a diver with the given diverName exists in the DiverRepository. If no diver with the provided name is found, return the following message: "{correctRepositoryTypeName} has no {diverName} registered for the competition."
        if (divers.GetModel(diverName) == null)
        {
            return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
        }
        //•	Validates if a fish with the given fishName exists in the FishRepository. If no fish with the provided name is found, return the following message: "{fishName} is not allowed to be caught in this competition."
        if (fish.GetModel(fishName) == null)
        {
            return string.Format(OutputMessages.FishNotAllowed, fishName);
        }
        //create Diver
        IDiver diver = divers.GetModel(diverName);
        //•	HealthCheck - If the diver's HasHealthIssues property is True, the diver is not allowed to dive. Return the following message: "{diverName} will not be allowed to dive, due to health issues."
        if (diver.HasHealthIssues)
        {
            return string.Format(OutputMessages.DiverHealthCheck, diverName);
        }
        //create Fish

        IFish currFish = fish.GetModel(fishName);
        //•	If the diver’s OxygenLevel is less than the fish's TimeToCatch value, the fish will escape, the diver will Miss with the harpoon (method Miss(int timeToCatch) should be used), and the following message should be returned: "{diverName} missed a good {fishName}."
        if (diver.OxygenLevel < currFish.TimeToCatch)
        {
            diver.Miss(currFish.TimeToCatch);

            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }
        //•	If the diver's OxygenLevel is equal to the fish's TimeToCatch value then:o	If isLucky is True, the diver successfully catches the fish by invoking the Hit method with the targeted fish. The following message is returned: "{diverName} hits a {fishPoints}pt. {fishName}."
        else if (diver.OxygenLevel == currFish.TimeToCatch && !isLucky)
        {
            diver.Miss(currFish.TimeToCatch);

            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }        
        else
        {
            diver.Hit(currFish);

            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }
            return string.Format(OutputMessages.DiverHitsFish, diverName, currFish.Points, fishName);
        }
    }

    //CompetitionStatistics Command
    public string CompetitionStatistics()
    {
        //Returns information about each diver from the DiverRepository. Arrange the divers by CompetitionPoints - descending, then by Catch.Count – descending, then by Name - alphabetically. Return only divers that are in good health condition. To receive the correct output, use the ToString() method of each diver:
        //"**Nautical-Catch-Challenge**
        //{ diver1}
        //{ diver2}

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("**Nautical-Catch-Challenge**");

        foreach (var d in divers.Models.Where(x => x.HasHealthIssues == false).OrderByDescending(x => x.CompetitionPoints).ThenByDescending(x => x.Catch.Count).ThenBy(x => x.Name))
        {
            sb.AppendLine(d.ToString());
        }

        return sb.ToString().TrimEnd();
    }
    //DiveIntoCompetition Command
    public string DiveIntoCompetition(string diverType, string diverName)
    {
        string result = string.Empty;
        //•	If the given diverType  is NOT presented as a valid Diver’s child class (FreeDiver, ScubaDiver), return the following message: "{diverType} is not allowed in our competition."
        if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
        {
            result = string.Format(OutputMessages.DiverTypeNotPresented, diverType);
        }
        //•	If a diver with the same Name is already added to the repository, do not duplicate records, return the following message: "{diverName} is already a participant -> {correctRepositoryTypeName}."
        else if (divers.GetModel(diverName) != null)
        {
            result = string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
        }
        //•	If none of the above cases is reached, the IDiver is successfully created. Store the diver to the appropriate collection and return: "{diverName} is successfully registered for the competition -> {correctRepositoryTypeName}."
        else
        {
            IDiver diver;

            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);
            result = string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }
        return result.Trim();
    }

    //DiverCatchReport Command
    public string DiverCatchReport(string diverName)
    {
        //Returns detailed information about a specific diver and his catch so far. To receive the correct output, use the ToString() method of each fish:
        //"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {count}, Points earned: {CompetitionPoints} ]
        //Catch Report:
        //{ fish1} //{typeName}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]
        //{ fish2}
        IDiver diver = divers.GetModel(diverName);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(diver.ToString());
        sb.AppendLine("Catch Report:");

        foreach (var fishName in diver.Catch)
        {
            IFish currFish = fish.GetModel(fishName);
            sb.AppendLine(currFish.ToString());
        }

        return sb.ToString().Trim();
    }

    //HealthRecovery Command
    public string HealthRecovery()
    {
        //•	First, it sets the HasHealthIssues property of the diver to False, indicating that the diver is now in a stable condition.
          int counter = 0;
        //•	Secondly, it replenishes the diver's OxygenLevel back to its maximum, ensuring the divers are ready for the next dive when they feel comfortable.
        //•	Returns the following message: "Divers recovered: {count}"

        foreach (var d in divers.Models.Where(x => x.HasHealthIssues == true))
        {
            counter++;
            d.UpdateHealthStatus();
            d.RenewOxy();
        }

        return string.Format(OutputMessages.DiversRecovered, counter);
    }

    //SwimIntoCompetition Command
    public string SwimIntoCompetition(string fishType, string fishName, double points)
    {
        string result = string.Empty;
        //•	If the given typeName  is NOT presented as a valid Fish's child class (ReefFish, DeepSeaFish, or PredatoryFish), return the following message: "{fishType} is forbidden for chasing in our competition."
        if (fishType != nameof(ReefFish) &&
                fishType != nameof(PredatoryFish) &&
                fishType != nameof(DeepSeaFish))
        {
            result = string.Format(OutputMessages.FishTypeNotPresented, fishType);
        }
        //•	If a fish with the same Name is already added to the repository, do not duplicate records, return the following message: "{fishName} is already allowed -> {correctRepositoryTypeName}."
        else if (fish.GetModel(fishName) != null)
        {
            result = string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
        }
        //•	If the above case is not reached, create the correct type of IFish and add it to the appropriate collection. Return the following message: "{fishName} is allowed for chasing."
        else
        {
            IFish newFish;

            if (fishType == nameof(ReefFish))
            {
                newFish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                newFish = new PredatoryFish(fishName, points);
            }
            else
            {
                newFish = new DeepSeaFish(fishName, points);
            }

            fish.AddModel(newFish);
            result = string.Format(OutputMessages.FishCreated, fishName);
        }

        return result.Trim();
    }
}
