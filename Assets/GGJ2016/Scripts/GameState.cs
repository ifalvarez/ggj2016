using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : Singleton<GameState> {

	void Start()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Quests", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
