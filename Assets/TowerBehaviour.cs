using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletShootPlace;
    public Rigidbody tankRigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletShootPlace.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * 400);
            tankRigidbody.AddForceAtPosition(transform.right * -1000, bulletShootPlace.position);
        }
    }
}
