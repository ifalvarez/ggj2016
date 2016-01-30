using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class QuestTrackerManager : MonoBehaviour {
    /// <summary>
    /// Quest to be displayed in the HUD
    /// </summary>
    public QuestTracker currentTrackedQuest;
    public QuestTracker questTrackerPrefab;

    public delegate void TrackQuestEvent(Quest quest);
    public event TrackQuestEvent OnStartTracking;
    public event TrackQuestEvent OnStopTracking;

    void Update()
    {
        // If the current quest is completed, dont track it anymore
        if (currentTrackedQuest != null && currentTrackedQuest.quest.isComplete)
        {
            Untrack();
        }
        // If there are quests available and no quest is being tracked, track one
        if (currentTrackedQuest == null) {
            Quest toTrack = QuestManager.Instance.quests.FirstOrDefault(x => !x.isComplete);
            if(toTrack != null)
                Track(toTrack);
        }
    }

    public void Track(Quest quest)
    {
        currentTrackedQuest = Instantiate(questTrackerPrefab);
        currentTrackedQuest.quest = quest;
        currentTrackedQuest.transform.SetParent(transform);
        if (OnStartTracking != null)
            OnStartTracking(quest);
    }

    public void Untrack()
    {
        if (OnStopTracking != null)
            OnStopTracking(currentTrackedQuest.quest);
        Destroy(currentTrackedQuest.gameObject);
        currentTrackedQuest = null;
    }
}
