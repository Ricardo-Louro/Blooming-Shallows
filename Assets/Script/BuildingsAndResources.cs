using System;
using UnityEngine;

public class BuildingsAndResources : MonoBehaviour
{
    public Building[] validBuildings {private set; get; }

    private int citizens = 0;
    private int wood = 0;
    private int stone = 0;
    private int food = 0;
    private int environment = 100;

    private int currentBuildWoodCost;
    private int currentBuildStoneCost;
    private Building currentBuilding;

    public void Build(string buildingName)
    {
        if (CheckBuildingRequirements(buildingName))
        {
            wood -= currentBuildWoodCost;
            stone -= currentBuildStoneCost;
            currentBuilding.BuildNew(1);
        }
    }

    private bool CheckBuildingRequirements(string buildingName)
    {
        for (int i = 0; i < validBuildings.Length; i++)
        {
            if (validBuildings[i].Name != buildingName) continue;
            
            currentBuildWoodCost = validBuildings[i].WoodCost;
            currentBuilding = validBuildings[i];

            bool canBuild = wood >= currentBuildWoodCost &&
                            stone >= currentBuildStoneCost;
            return canBuild;
        }

        return false;
    }

    public void Start()
    {
        validBuildings = new[]
        {
            new Building("house", 1, 1, 1), 
            new Building("fisherman", 1, 1, 0),
            new Building("lumberjack", 1, 0, 1),
            new Building("caretaker", 1, 1, 1)
        };
    }
}
