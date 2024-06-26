using System;
using UnityEngine;

public class BuildingsAndResources : MonoBehaviour
{
    public Building[]               validBuildings {private set; get; }

    public float                    citizens;
    public float                    wood;
    public float                    food;
    public float                    environment = 100;

    private int                     currentBuildWoodCost;
    private Building                currentBuilding;


    public bool Build(string buildingName)
    {
        if (CheckBuildingRequirements(buildingName))
        {
            wood -= currentBuildWoodCost;
            currentBuilding.BuildNew(1);
            return true;
        }
        return false;
    }

    private bool CheckBuildingRequirements(string buildingName)
    {
        for (int i = 0; i < validBuildings.Length; i++)
        {
            if (validBuildings[i].Name != buildingName) continue;
            
            currentBuildWoodCost = validBuildings[i].WoodCost;
            currentBuilding = validBuildings[i];

            bool canBuild = wood >= currentBuildWoodCost;
                            
            return canBuild;
        }

        return false;
    }

    public void Awake()
    {
        validBuildings = new[]
        {
            new Building("house", 1, 0.5f, 0.5f), 
            new Building("fisherman", 1, 0.5f, 0),
            new Building("lumberjack", 1, 0, 0.5f),
            new Building("caretaker", 1, 0.5f, 0.5f)
        };
    }
}
