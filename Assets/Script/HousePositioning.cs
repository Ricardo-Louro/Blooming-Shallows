using UnityEngine;

public class HousePositioning : MonoBehaviour
{
    [SerializeField] private float      yPos;
    private float                       xPos;
    private Vector3                     buildingPos;
    private GameObject                  buildingSprite;
    public bool                         placementMode;

    // Start is called before the first frame update
    private void Start()
    {
        buildingPos = Vector3.zero;
        placementMode = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(placementMode)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GetMousePosition();
                GetBuildingPosition();
                SpawnHouse();
            }    
        }   
    }
    

    private void GetMousePosition()
    {
        xPos = Input.mousePosition.x;
    }

    private void GetBuildingPosition()
    {
        buildingPos.x = xPos;
        buildingPos.y = yPos;
    }

    private void SpawnHouse()
    {
        Instantiate(buildingSprite, buildingPos, Quaternion.identity);
    }
}
