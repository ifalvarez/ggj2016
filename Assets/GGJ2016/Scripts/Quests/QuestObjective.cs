using UnityEngine;

public class QuestObjective : MonoBehaviour
{
    public string description;
    [SerializeField]
    private bool isCompleted;

    public delegate void QuestObjectiveCompletion();
    /// <summary>
    /// Called each time the objective is completed (when IsComplete changes from false to true)
    /// </summary>
    public event QuestObjectiveCompletion OnObjectiveCompletion;

    /// <summary>
    /// Called each time the objective was complete but changes to incomplete (when IsComplete changes from true to false)
    /// </summary>
    public event QuestObjectiveCompletion OnObjectiveIncompletion;

    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }

        set
        {
            bool oldValue = isCompleted;
            isCompleted = value;
            if (!oldValue && value)
            {
                if (OnObjectiveCompletion != null)
                    OnObjectiveCompletion();
            }
            else if(oldValue && !value)
            {
                if (OnObjectiveIncompletion != null)
                    OnObjectiveIncompletion();
            }
        }
    }

    public virtual string getDescription() {
        return description;
    }

    // Get the reference of a transform at the location in the world space where the quest is objective can be completed
    public virtual Transform getLocation() {
        throw new System.NotImplementedException();
    }
}