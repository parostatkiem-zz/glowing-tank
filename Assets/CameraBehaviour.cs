using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform objectToFollow;
    private Vector3 desiredPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        desiredPosition = new Vector3(objectToFollow.position.x, transform.position.y, objectToFollow.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition,Time.deltaTime * 10);

    }
}
