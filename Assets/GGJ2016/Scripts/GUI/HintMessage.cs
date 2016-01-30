using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class HintMessage : MonoBehaviour {

    private Text messageText;
    CanvasGroupVisibility cgv;

    void Start () {
        messageText = transform.Find("Text").GetComponent<Text>();
        cgv = GetComponent<CanvasGroupVisibility>();
    }

    /// <summary>
    /// Shows a hint message on the screen that is jus text without a container just under the center of the screen
    /// </summary>
    /// <param name="message">Message to show</param>
    /// <param name="duration">(optional) If specified, the message will hide automatically after the duration in seconds</param>
    public void ShowMessage(string message, float duration = -1) {
        messageText.text = message;
        if(duration > 0)
        {
            cgv.Show(true, duration);
        }
        else
        {
            cgv.Show(true);
        }
        
    }

    public void Hide() {
        cgv.Show(false);
    }

    #region Singleton
    /* Singleton implementation */

	public static bool HasInstance { get { return _instance != null; } }

    private static HintMessage _instance;
    private HintMessage() { }

    public static HintMessage Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No HintMessage instance is present, but its being accessed");
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}
