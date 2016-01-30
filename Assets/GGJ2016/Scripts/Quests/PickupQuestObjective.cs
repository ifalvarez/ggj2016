using UnityEngine;
using System.Collections;

public class PickupQuestObjective : CountQuestObjective
{
    public string targetName;

    void OnEnable()
    {
        Collectable.OnCollected += HandleOnCollected;
    }

    void OnDisable()
    {
        Collectable.OnCollected += HandleOnCollected;
    }

    private void HandleOnCollected(Collectable collectable)
    {
        if (CurrentCount < targetCount && collectable.name.Contains(targetName))
        {
            AddCount(1);
        }
    }
}
