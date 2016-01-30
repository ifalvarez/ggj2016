using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
    public Text text;
    public float stationaryTime;
    
    private Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
    }

    public FloatingText SetText(string newText)
    {
        text.text = newText;
        return this;
    }

    public FloatingText SetColor(Color newColor)
    {
        text.color = newColor;
        return this;
    }

    public FloatingText Add(float value)
    {
        // Add the value to the old one. If no float value is found, cero is assumed
        float oldValue = 0;
        if (!float.TryParse(text.text, out oldValue))
        {
            oldValue = 0;
        }
        value += oldValue;
        text.text = value.ToString();

        // Reset the fade coroutine
        Fade();
        return this;
    }

    public void Fade() {
        StopAllCoroutines();
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(stationaryTime);
        FloatingTextManager.Instance.Deregister(this);
        animator.SetTrigger("fade");
    }

    public void Dispose() {
        Destroy(this.gameObject);
    }

}
