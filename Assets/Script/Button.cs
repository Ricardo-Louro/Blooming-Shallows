using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField] protected GameObject tooltip;

    protected void Start()
    {
        HideTooltip();
    }

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    protected abstract void OnClick();
}
