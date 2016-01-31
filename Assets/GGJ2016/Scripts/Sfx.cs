using UnityEngine;
using System.Collections;

public class Sfx : MonoBehaviour {

    public AudioClip questCompleted;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        Quest.OnStaticQuestCompletion += HandleOnStaticQuestCompletion;
    }

    public void HandleOnStaticQuestCompletion(Quest quest)
    {
        audioSource.clip = questCompleted;
        audioSource.Play();
    }
}
