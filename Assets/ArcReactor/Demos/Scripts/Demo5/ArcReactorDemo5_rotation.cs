using UnityEngine;
using System.Collections;

public class ArcReactorDemo5_rotation : MonoBehaviour {

	public float rotationSpeed;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        //transform.Rotate ( Vector3.forward * ( rotationSpeed * Time.deltaTime * Input.GetAxis("Vertical")) );
        //GetComponent<Rigidbody>().angularVelocity = new Vector3(0, rotationSpeed, 0); 
        GetComponent<Rigidbody>().velocity = new Vector3(rotationSpeed, 0, 0);
    }
}
