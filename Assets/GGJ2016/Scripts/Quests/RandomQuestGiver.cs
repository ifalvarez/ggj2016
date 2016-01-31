using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Assigns random quests from a collection. Each time a quest is finished, asigns a new one. When all the quests are finished, its starts over.
/// This is being used to give quests to the player while other quest givers are implemented
/// </summary>
public class RandomQuestGiver : MonoBehaviour {

    public Quest[] availableQuests;
    private List<Quest> availableQuestsNotGiven;

    void Start()
    {
        availableQuestsNotGiven = new List<Quest>();
        GiveRandomQuest();
    }

    private void GiveRandomQuest()
    {
        // Fill the availableQuestsNotGiven array if empty
        if (availableQuestsNotGiven.Count == 0)
        {
            availableQuestsNotGiven.AddRange(availableQuests);
        }

        // Pick and start a random quest
        if(availableQuestsNotGiven.Count > 0)
        {
            int index = Random.Range(0, availableQuestsNotGiven.Count);
            Quest questPrefab = availableQuestsNotGiven[index];
            availableQuestsNotGiven.RemoveAt(index);

            Quest newQuest = QuestManager.Instance.StartQuest(questPrefab);

            // When the quest is complete, give the player a new one
            newQuest.OnQuestCompletion += HandleOnQuestCompletion;
        }
        else
        {
            Debug.LogWarning("A random quest giver is set up but no quests are assigned to it");
        }
    }

    private void HandleOnQuestCompletion()
    {
        GiveRandomQuest();
    }
}
