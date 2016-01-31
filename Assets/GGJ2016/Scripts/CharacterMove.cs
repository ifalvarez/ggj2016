using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    public Rigidbody sphereOne;
    public Rigidbody sphereTwo;
    public float speed;
    public float cameraSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward * 20);
        sphereOne.MovePosition(sphereOne.position + Vector3.up * speed * Input.GetAxis("Vertical1"));
        sphereTwo.MovePosition(sphereTwo.position + Vector3.up * speed * Input.GetAxis("Vertical2"));
        //sphereOne.MovePosition(Vector3.right * speed * Input.GetAxis("Horizontal"));
        //sphereTwo.MovePosition(Vector3.right * speed * Input.GetAxis("Horizontal") * -1);

        /*
        float deltaY = Mathf.Abs(sphereOne.transform.position.y - sphereTwo.transform.position.y);
        float meanY = (sphereOne.transform.position.y + sphereTwo.transform.position.y) / 2;

        Camera.main.transform.localPosition = new Vector3(0,
            Mathf.Lerp(Camera.main.transform.localPosition.y, meanY, Time.deltaTime * cameraSpeed), 
            Mathf.Lerp(Camera.main.transform.localPosition.z, Mathf.Min(30, (deltaY - 30) * (-1.5f)), Time.deltaTime * cameraSpeed));
            */
    }
}
