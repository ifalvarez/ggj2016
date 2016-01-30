using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestObjectiveTracker : MonoBehaviour {

    public QuestObjective questObjective;
    public Text description;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        questObjective.OnObjectiveCompletion += HandleOnObjectiveCompletion;
        questObjective.OnObjectiveIncompletion += HandleOnObjectiveIncompletion;
    }

    void Update()
    {
        description.text = questObjective.getDescription();
    }

    private void HandleOnObjectiveCompletion()
    {
        canvasGroup.alpha = 0.3f;
    }

    private void HandleOnObjectiveIncompletion()
    {
        canvasGroup.alpha = 1;
    }

    void OnDestroy()
    {
        questObjective.OnObjectiveCompletion -= HandleOnObjectiveCompletion;
    }
}
