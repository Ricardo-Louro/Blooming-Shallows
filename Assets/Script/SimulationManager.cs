using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationManager : MonoBehaviour
{
    public bool canLose;

    [SerializeField] private BuildingsAndResources bR;
    [SerializeField] private Ui uI;

    [Header("Simulation Timer")]
    [SerializeField] private float updateCooldown;
    private float lastTimeUpdated;

    [Header("Citizen Multipliers")]
    [SerializeField] private float citizen_foodMultiplier;
    [SerializeField] private float citizen_housingMultiplier;
    [SerializeField] private int houseCitizenCap;

    [Header("Environment Multipliers")]
    [SerializeField] private float environment_caretakerMultiplier;
    [SerializeField] private float environment_fishermanMultiplier;
    [SerializeField] private float environment_lumberjackMultiplier;
    [SerializeField] private float environment_citizenMultiplier;
    
    [Header("Wood Multipliers")]
    [SerializeField] private float wood_lumberjackMultiplier;
    [SerializeField] private float wood_citizenMultiplier;

    [Header("Food Multipliers")]
    [SerializeField] private float food_citizenMultiplier;
    [SerializeField] private float food_fishermanMultiplier;
    


    private Building house;
    private Building fisherman;
    private Building lumberjack;
    private Building caretaker;

    // Start is called before the first frame update
    private void Start()
    {
        canLose = false;
        lastTimeUpdated = Time.time;
        bR = FindObjectOfType<BuildingsAndResources>();

        house       = bR.validBuildings[0];
        fisherman   = bR.validBuildings[1];
        lumberjack  = bR.validBuildings[2];
        caretaker   = bR.validBuildings[3];
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time - lastTimeUpdated > updateCooldown)
        {
            SimulationUpdate();
            lastTimeUpdated = Time.time;
        }
    }

    private void SimulationUpdate()
    {
        if(bR.citizens > 0 && !canLose)
        {
            canLose = true;
        }

        UpdateCitizenCount();
        UpdateWoodCount();
        UpdateFoodCount();
        UpdateEnvironment();
        PayUpkeeps();
        uI.Update();

        ConsolePrint();
    }

    private void UpdateCitizenCount()
    {
        bR.citizens += house.AmountBuilt * citizen_housingMultiplier
                    + bR.food * citizen_foodMultiplier;

        bR.citizens = Mathf.Min(bR.citizens, house.AmountBuilt * houseCitizenCap);
        if(bR.citizens < 1) GameOver();
    }

    private void UpdateWoodCount()
    {
        bR.wood += lumberjack.AmountBuilt * wood_lumberjackMultiplier
              + bR.citizens * wood_citizenMultiplier;

    }

    private void UpdateFoodCount()
    {
        bR.food += fisherman.AmountBuilt * food_fishermanMultiplier
              + bR.citizens * food_citizenMultiplier;
    }

    private void UpdateEnvironment()
    {
        bR.environment += caretaker.AmountBuilt * environment_caretakerMultiplier
                     + fisherman.AmountBuilt * environment_fishermanMultiplier
                     + lumberjack.AmountBuilt * environment_lumberjackMultiplier
                     + bR.citizens * environment_citizenMultiplier;
        
        bR.environment = Mathf.Min(bR.environment, 100);    
        if(bR.environment < 1) GameOver();
    }

    private void PayUpkeeps()
    {
        foreach(Building building in bR.validBuildings)
        {
            bR.wood -= building.AmountBuilt * building.WoodUpkeep;
            bR.food -= building.AmountBuilt * building.FoodUpkeep;
        }
    }

    private void ConsolePrint()
    {
        print("/-----------/ Update /-----------/");
        print($"food: {bR.food}");
        print($"wood: {bR.wood}");
        print($"citizens: {bR.citizens}");
        print($"environment: {bR.environment}");
    }

    private void GameOver()
    {
        if(canLose)
        {
            SceneManager.LoadScene("GameOver"); 
        }
    }
}