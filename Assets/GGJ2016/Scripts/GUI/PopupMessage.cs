using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : Menu {

    private Text messageText;

    new void Start () {
        base.Start();
        messageText = transform.Find("Text").GetComponent<Text>();
    }

    public void ShowMessage(string message) {
        messageText.text = message;
        cgv.Show(true);
    }

    #region Singleton
    /* Singleton implementation */
    private static PopupMessage _instance;
    private PopupMessage() { }

    public static PopupMessage Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No PopupMessage instance is present, but its being accessed");
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
