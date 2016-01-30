using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour {

    public Quest quest;
    public Text questTitle;
    public Transform questObjectives;
    public QuestObjectiveTracker questObjectiveTrackerPrefab;
    
    void Start () {
        questTitle.text = quest.title;
        foreach(QuestObjective o in quest.objectives)
        {
            QuestObjectiveTracker newObjectiveTracker = Instantiate(questObjectiveTrackerPrefab);
            newObjectiveTracker.questObjective = o;
            newObjectiveTracker.transform.SetParent(questObjectives);
        }
	}
}
