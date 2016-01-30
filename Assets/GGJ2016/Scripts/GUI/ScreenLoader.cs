using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScreenLoader : MonoBehaviour {
    public Sprite loading;

    public Text LoadingTextBox;
	public string[] LoadingTexts;
	public float loadingTextsTime;

    private CanvasGroupVisibility cgv;
    
    // List of objects that want to prevent the loading screen from hiding
    // The loading screen will not dissapear until this list is empty
    public HashSet<object> loadingScreenLocks; 

	void Start () {
        cgv = GetComponent<CanvasGroupVisibility>();
        loadingScreenLocks = new HashSet<object>();
    }
	
	void Update () {
        // If there are no objects wanting to show the loading screen, hide it. Otherwise show it
        if (cgv.canvasGroup.alpha == 1 && loadingScreenLocks.Count == 0) {
            cgv.Show(false);
            CancelInvoke("ChangeLoadText");
        }
        else if(loadingScreenLocks.Count != 0)
        {
            cgv.Show(true);
        }
    }

	public void ShowLoadingScreen(object locker)
	{
        // Make sure to show the screen the same frame this method is called
        cgv.Show(true);
        InvokeRepeating("ChangeLoadText", 0f, loadingTextsTime);
        loadingScreenLocks.Add(locker);	
	}

    public void HideLoadingScreen(object locker)
    {
        loadingScreenLocks.Remove(locker);
    }

    public void HideLoadingScreen(object locker, float delay)
    {
        StartCoroutine(HideLoadingScreenCoroutine(locker, delay));
    }

    private IEnumerator HideLoadingScreenCoroutine(object locker, float delay) {
        yield return new WaitForSeconds(delay);
        loadingScreenLocks.Remove(locker);
    }

    public void ChangeLoadText()
	{
        LoadingTextBox.text = LoadingTexts [Random.Range (0, LoadingTexts.Length)];
	}

    #region Singleton
    /* Singleton implementation */
    private static ScreenLoader _instance;
    private ScreenLoader() { }

    public static ScreenLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No ScreenLoader instance is present, but its being accessed");
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
