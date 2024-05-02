using UnityEngine;
using Random = System.Random;

public class HousePositioning : MonoBehaviour
{
    [SerializeField] private float      yPos;
    [SerializeField] private int maxXValue;
    [SerializeField] private int minXValue;
    [SerializeField] private BuildingsAndResources br;
    [SerializeField] private GameObject UISpriteParent;
    
    private float                       xPos;
    private GameObject                  buildingSprite;
    private Random rnd;

    [SerializeField] private Sprite[] HouseSpritePrefabs;
    [SerializeField] private Sprite[] LumberjackSpritePrefabs;
    [SerializeField] private Sprite[] FishermanSpritePrefabs;
    [SerializeField] private Sprite[] CaretakerPrefabs;

    // Start is called before the first frame update
    private void Start()
    {
        rnd = new Random();
    }

    // Update is called once per frame
    public void BuildNew(string buildingName)
    {
        for (int i = 0; i < br.validBuildings.Length; i++)
        {
            if (br.validBuildings[i].Name != buildingName) continue;
            switch (buildingName)
            {
                case "house":
                    SpawnHouse(GetRandomSprite(HouseSpritePrefabs), new Vector3(GetRandomBuildingPosition(), yPos));
                    break;
                case "fisherman":
                    SpawnHouse(GetRandomSprite(FishermanSpritePrefabs), new Vector3(GetRandomBuildingPosition(), yPos));
                    break;
                case "lumberjack":
                    SpawnHouse(GetRandomSprite(LumberjackSpritePrefabs), new Vector3(GetRandomBuildingPosition(), yPos));
                    break;
                case "caretaker":
                    SpawnHouse(GetRandomSprite(CaretakerPrefabs), new Vector3(GetRandomBuildingPosition(), yPos));
                    break;
            }
        }   
    }

    private int GetRandomBuildingPosition()
    {
        return rnd.Next(minXValue, maxXValue);
    }

    private Sprite GetRandomSprite(Sprite[] possibleSprites)
    {
        return possibleSprites[rnd.Next(0, possibleSprites.Length)];   
    }
    
    private void SpawnHouse(Sprite buildingSprite, Vector3 buildingPos)
    {
        GameObject newBuilding = new GameObject();
        newBuilding.transform.parent = UISpriteParent.transform;
        newBuilding.AddComponent<SpriteRenderer>();
        newBuilding.GetComponent<SpriteRenderer>().sprite = buildingSprite;
        newBuilding.transform.position = buildingPos;
        newBuilding.transform.localScale = new Vector3(0.3f, 0.3f, 1);
    }
}
