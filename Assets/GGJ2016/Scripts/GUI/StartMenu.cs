using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : Menu {

    new void Start()
    {
        base.Start();
        Open();
        Invoke("OpenHud", 1f);
    }

    public void Exit() {
        GameState.Instance.ExitGame();
    }

    public override bool CanBeClosed()
    {
        return false;
    }

    void OpenHud()
    {
        MenuManager.Instance.OpenMenu("HudMenu");
    }

}
