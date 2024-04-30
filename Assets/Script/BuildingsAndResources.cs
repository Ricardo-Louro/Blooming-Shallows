using UnityEngine;

public class BuildingsAndResources : MonoBehaviour
{
    private int houses = 0;

    private int citizens = 0;

    public void Build(Buildings building)
    {
        //Add check for requirements

        if(building == Buildings.houses)
        {
            houses += 1;
        }
    }
}
