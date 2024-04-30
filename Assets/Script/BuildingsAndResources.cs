using System;
using UnityEngine;

public class BuildingsAndResources : MonoBehaviour
{
    public Building[] validBuildings {private set; get; }

    public int citizens = 0;
    public int wood = 0;
    public int stone = 0;
    public int food = 0;

    public int houses = 0;

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
            currentBuildStoneCost = validBuildings[i].StoneCost;
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
            new Building("mine", 1, 1),
            new Building("house", 1, 1), 
            new Building("huntsman", 1, 1),
            new Building("fisherman", 1, 1),
            new Building("lumberjack", 1, 1), 
        };
    }
}
