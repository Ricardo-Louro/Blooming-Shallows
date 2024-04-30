using UnityEngine;

public class BuildButton : Button
{
    [SerializeField] private Buildings              building;
    private BuildingsAndResources                   buildingsAndResources;
    public override GameObject                      tooltip { get; protected set; }


    private void Start()
    {
        buildingsAndResources = FindObjectOfType<BuildingsAndResources>();
    }

    protected override void OnClick()
    {
        buildingsAndResources.Build(building);
    }
}