using UnityEngine;
using System.Collections;

public class CanvasGroupVisibility : MonoBehaviour {
    [HideInInspector]
    public CanvasGroup canvasGroup;
    private Animator animator;
    

    public bool canAlterBlockRaycast = true;

    void Awake () {
        canvasGroup = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
    }

    public void Show(bool visible)
    {
        canvasGroup.alpha = visible ? 1 : 0;
        canvasGroup.interactable = visible;
        if(canAlterBlockRaycast)
            canvasGroup.blocksRaycasts = visible;
        if (animator != null)
        {
            animator.SetBool("show", visible);
        }
    }

    public void Show(bool visible, float timeToToggle) {
        Show(visible);
        StopAllCoroutines();
        StartCoroutine(ShowCoroutine(!visible, timeToToggle));
    }

    IEnumerator ShowCoroutine(bool visible, float delay)
    {
        yield return new WaitForSeconds(delay);
        Show(visible);
    }

    public void PreventAutoToggle() {
        StopAllCoroutines();
    }
}
