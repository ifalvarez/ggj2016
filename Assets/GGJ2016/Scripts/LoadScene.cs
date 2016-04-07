using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string sceneName;
    public float delay;

	void Start () {
        Invoke("Load", delay);
	}
	
	void Load () {
        SceneManager.LoadSceneAsync(sceneName);
	}
}
