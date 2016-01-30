using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public Sprite logo;
    public Sprite title;

    public float LogoScreenTime;
    
    public Image currentImage;
    bool logoScreenUp = false;
    bool titleScreenUp = false;

    void Start()
    {
        StartCoroutine("ShowLogoScreen"); //Only methods started as a string can be stopped as a string.
    }


    void Update()
    {
        if (logoScreenUp)
        {
            if (Input.anyKeyDown)
            {
                StopCoroutine("ShowLogoScreen");
                HideLogoScreen();
            }
        }
    }

    public IEnumerator ShowLogoScreen()
    {
        logoScreenUp = true;
        currentImage.sprite = logo;
        yield return new WaitForSeconds(LogoScreenTime);
        HideLogoScreen();
    }

    public void HideLogoScreen()
    {
        logoScreenUp = false;
        titleScreenUp = true;
        currentImage.sprite = title;
        SceneManager.LoadScene("Start");
    }
}
