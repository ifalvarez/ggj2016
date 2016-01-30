using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	public Transform parentObject;

	// Use this for initialization
	void Start () {
		Invoke ("Spawn", Random.Range(spawnMin, spawnMax));
    }
	
	void Spawn(){
		GameObject newObject = Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity) as GameObject;
		newObject.transform.SetParent(parentObject);
		Invoke ("Spawn", Random.Range(spawnMin, spawnMax));
	}
}
