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
        woodCountText.text = $"{br.wood}";
        foodCountText.text = $"{br.food}";
        citizenCountText.text = $"{br.citizens}";
        environmentSlider.value = br.environment;
    }
}
