using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private BuildingsAndResources bR;

    [Header("Simulation Timer")]
    [SerializeField] private float updateCooldown;
    private float lastTimeUpdated;

    [Header("Value Multipliers")]
    [SerializeField] private float housingMultiplier;

    // Start is called before the first frame update
    private void Start()
    {
        lastTimeUpdated = Time.time;
        bR = FindObjectOfType<BuildingsAndResources>();
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
    }

    private void UpdateCitizenCount()
    {
        float citizens = bR.citizens;
        citizens += bR.houses * housingMultiplier;
        bR.citizens = (int)citizens;
    }
}