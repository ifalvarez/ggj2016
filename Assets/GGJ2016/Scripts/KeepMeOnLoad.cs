using UnityEngine;
using System.Collections;

public class KeepMeOnLoad : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
	}
}
