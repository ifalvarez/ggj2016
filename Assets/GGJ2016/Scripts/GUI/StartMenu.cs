using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : Menu {

    new void Start()
    {
        base.Start();
        Open();
    }

    public void Exit() {
        GameState.Instance.ExitGame();
    }

    public override bool CanBeClosed()
    {
        return SceneManager.GetActiveScene().name != "Start";
    }
}
