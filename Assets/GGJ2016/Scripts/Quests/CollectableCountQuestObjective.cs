using UnityEngine;
using System.Linq;

public class CollectableCountQuestObjective : CountQuestObjective{

    public string targetName;
    [SerializeField]
    private Collectable currentLocation;

    void OnEnable() {
        Collectable.OnCollected += HandleOnCollected;
    }

    void OnDisable() {
        Collectable.OnCollected -= HandleOnCollected;
    }

    private void HandleOnCollected(Collectable collected)
    {
        if (CurrentCount < targetCount && collected.name.Contains(targetName))
        {
            AddCount(1);
        }
    }

    public override Transform getLocation()
    {
        // If the transform marked as currentLocation is not null and is active return it
        if(currentLocation != null && currentLocation.gameObject.activeInHierarchy)
        {
            return currentLocation.transform;
        }
        else
        {
            // Find a new collectable to mark as currentLocation
            Collectable[] collectables = FindObjectsOfType<Collectable>();
            Collectable collectable = collectables.FirstOrDefault(x => x.gameObject.activeInHierarchy && x.name.Contains(targetName));
            if (collectable != null)
            {
                // If a suitable collectable is found, save it and return its transform
                currentLocation = collectable;
                return currentLocation.transform;
            }
            else
            {
                // If no suitable collectable is found just return null
                return null;
            }
        }
    }
}
