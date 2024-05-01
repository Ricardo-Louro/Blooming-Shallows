using Script;
using TMPro;
using UnityEngine;

public class BuildButton : Button
{
    [SerializeField] private BuildingEnum           building;
    private BuildingsAndResources                   buildingsAndResources;
    [SerializeField] private TextMeshProUGUI        counterText;
    private int                                     numberOfBuildings;


    private new void Start()
    {
        base.Start();
        numberOfBuildings = 0;

        buildingsAndResources = FindObjectOfType<BuildingsAndResources>();
    }

    protected override void OnClick()
    {
        if(buildingsAndResources.Build(building.ToString()))
        {
            numberOfBuildings++;
            counterText.text = numberOfBuildings.ToString();
        }
        else
        {
            Debug.Log("Not enough resources :(");
        }
    }
}