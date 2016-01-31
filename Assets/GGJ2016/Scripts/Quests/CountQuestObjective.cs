using UnityEngine;
using System.Collections;

public class CountQuestObjective : QuestObjective{

    [SerializeField]
    private int currentCount;
    public int targetCount;

    public int CurrentCount
    {
        get
        {
            return currentCount;
        }

        set
        {
            currentCount = value;
            
            // Set objective completion state
            if (!IsCompleted && currentCount >= targetCount)
            {
                IsCompleted = true;
            }else if(IsCompleted && currentCount < targetCount)
            {
                IsCompleted = false;
            }
        }
    }

    public override string getDescription()
    {
        return string.Format("{0}: <color=green>{1}/{2}</color>", description, CurrentCount, targetCount);
    }

    public void AddCount(int value)
    {
        CurrentCount += value;
    }
}
