using UnityEngine;
using System.Collections;

public class Bgm : MonoBehaviour {

    public AudioClip[] bgms;
    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgms[Random.Range(0, bgms.Length)];
        audioSource.Play();
	}
	
	void Update () {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = bgms[Random.Range(0, bgms.Length)];
            audioSource.Play();
        }
	}
}
