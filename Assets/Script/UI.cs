using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField] private BuildingsAndResources br;
    
    [SerializeField] private TMP_Text houseCostText;
    [SerializeField] private TMP_Text lumberjackCostText;
    [SerializeField] private TMP_Text fishermanCostText;
    [SerializeField] private TMP_Text caretakerCostText;

    [SerializeField] private TMP_Text woodCountText;
    [SerializeField] private TMP_Text foodCountText;
    [SerializeField] private TMP_Text citizenCountText;
    [SerializeField] private Slider environmentSlider;

    public void Update()
    {
        woodCountText.text = $"{Mathf.Max(0, (int)br.wood)}";
        foodCountText.text = $"{Mathf.Max(0, (int)br.food)}";
        citizenCountText.text = $"{Mathf.Max(0, (int)br.citizens)}";
        environmentSlider.value = br.environment;

        houseCostText.text = $"{br.validBuildings[0].WoodCost} wood";
        fishermanCostText.text = $"{br.validBuildings[1].WoodCost} wood";
        lumberjackCostText.text = $"{br.validBuildings[2].WoodCost} wood";
        caretakerCostText.text = $"{br.validBuildings[3].WoodCost} wood";
    }
}
