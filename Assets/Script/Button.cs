using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField] public abstract GameObject tooltip{get; protected set;}

    private void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    private void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    protected abstract void OnClick();
}
