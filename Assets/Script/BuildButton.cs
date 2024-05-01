using Script;
using UnityEngine;

public class BuildButton : Button
{
    [SerializeField] private BuildingEnum           building;
    private BuildingsAndResources                   buildingsAndResources;


    private new void Start()
    {
        base.Start();
        buildingsAndResources = FindObjectOfType<BuildingsAndResources>();
    }

    protected override void OnClick()
    {
        buildingsAndResources.Build(building.ToString());
    }
}