using UnityEngine;
using System.Collections;
using System;

public class Quest : MonoBehaviour{
    public string title;
    public QuestObjective[] objectives;
    public bool isComplete;
    public delegate void QuestCompletion();
    public event QuestCompletion OnQuestCompletion;
    public delegate void StaticQuestCompletion(Quest quest);
    public static event StaticQuestCompletion OnStaticQuestCompletion;



    void Start() {
        QuestManager.Instance.quests.Add(this);
    }

    void OnDestroy() {
        QuestManager.Instance.quests.Remove(this);
    }

    void Update() {
        if (!isComplete)
        {
            bool objectivesComplete = true;
            foreach(QuestObjective q in objectives)
            {
                objectivesComplete &= q.IsCompleted;
            }
            if (objectivesComplete)
            {
                isComplete = true;
                if (OnQuestCompletion != null)
                    OnQuestCompletion();
                if (OnStaticQuestCompletion != null)
                    OnStaticQuestCompletion(this);
            }
        }
    }
}

