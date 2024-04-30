using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private BuildingsAndResources bR;

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
        lastTimeUpdated = Time.time;
        bR = FindObjectOfType<BuildingsAndResources>();

        house       = bR.validBuildings[0];
        fisherman   = bR.validBuildings[1];
        lumberjack  = bR.validBuildings[2];
        caretaker   = bR.validBuildings[3]
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
        UpdateCitizenCount();
        UpdateWoodCount();
        UpdateFoodCount();
        UpdateEnvironment();
    }

    private void UpdateCitizenCount()
    {
        float citizens = bR.citizens;

        citizens += house.AmountBuilt * citizen_housingMultiplier
                 + bR.food * citizen_foodMultiplier;

        bR.citizens = Mathf.Min((int)citizens, house.AmountBuilt * houseCitizenCap);
    }

    private void UpdateWoodCount()
    {
        float wood = bR.wood;

        wood += lumberjack.AmountBuilt * wood_lumberjackMultiplier
              + bR.citizens * wood_citizenMultiplier;

        bR.wood = (int)wood;
    }

    private void UpdateFoodCount()
    {
        float food = bR.food;

        food += fisherman.AmountBuilt * food_fishermanMultiplier
              + bR.citizens * food_citizenMultiplier;
        
        bR.food = (int)food;
    }

    private void UpdateEnvironment()
    {
        float environment = bR.environment;

        environment += caretaker.AmountBuilt * environment_caretakerMultiplier
                     + fisherman.AmountBuilt * environment_fishermanMultiplier
                     + lumberjack.AmountBuilt * environment_lumberjackMultiplier
                     + bR.citizens * environment_citizenMultiplier;
        
        bR.environment = Mathf.Min((int)environment, 100);    
    }
}