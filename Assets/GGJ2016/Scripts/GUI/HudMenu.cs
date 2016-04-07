using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HudMenu : Menu {

    new void Start()
    {
        base.Start();
        Open();
    }

    public override bool CanBeClosed()
    {
        return false;
    }
}
