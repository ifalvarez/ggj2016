using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public delegate void CollectableEvent(Collectable collectable);
    public static event CollectableEvent OnCollected;
    public float respawnTime;
    public string floatingText;
    public Color floatingTextColor;
    public AudioClip sfx;
    public AudioSource sfxAudioSourcePrefab;

    private Collider trigger;

    void Start()
    {
        trigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (OnCollected != null)
                OnCollected(this);
            FloatingTextManager.Instance
                .Display(floatingText, Camera.main.WorldToScreenPoint(transform.position))
                .SetColor(floatingTextColor);
            AudioSource newSfxAudioSource = Instantiate(sfxAudioSourcePrefab);
            newSfxAudioSource.clip = sfx;
            newSfxAudioSource.Play();
            Destroy(newSfxAudioSource, newSfxAudioSource.clip.length);
            Destroy(gameObject);
        }
    }
}
