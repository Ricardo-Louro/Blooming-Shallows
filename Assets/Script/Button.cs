using System.Collections;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField] protected GameObject tooltip;
    [SerializeField] protected float tooltipDelay;
    protected IEnumerator coroutine;

    protected void Start()
    {
        coroutine = ShowTooltip();
        HideTooltip();
    }

    public void QueueShowTooltip()
    {
        //coroutine = ShowTooltip();
        //StartCoroutine(coroutine);
    }

    public void HideTooltip()
    {
        //StopCoroutine(coroutine);
        //tooltip.SetActive(false);
    }

    protected IEnumerator ShowTooltip()
    {
        yield return new WaitForSeconds(tooltipDelay);
        tooltip.SetActive(true);
    }

    protected abstract void OnClick();
}
