using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HudMenu : Menu {

    public override bool CanBeClosed()
    {
        return SceneManager.GetActiveScene().name == "Start";
    }
}
