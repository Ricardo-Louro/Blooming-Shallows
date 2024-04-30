using UnityEngine;

public class BuildingsAndResources : MonoBehaviour
{
    public int houses = 0;

    public int citizens = 0;

    public void Build(Buildings building)
    {
        //Add check for requirements

        if(building == Buildings.houses)
        {
            houses += 1;
        }
    }
}
