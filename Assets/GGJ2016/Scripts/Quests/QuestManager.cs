using UnityEngine;
using System.Collections.Generic;

public class QuestManager : Singleton<QuestManager>
{
    public List<Quest> quests = new List<Quest>();

    public Quest StartQuest(Quest questPrefab)
    {
        Quest newQuest = Instantiate(questPrefab);
        newQuest.transform.SetParent(transform);
        return newQuest;
    }

    public void DropQuest(Quest quest) {
        Destroy(quest.gameObject);
    }
}
