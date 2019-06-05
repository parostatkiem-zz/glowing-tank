using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Collider collider;
    private Rigidbody rigid;
    // Start is called before the first frame update
    private int deaths = 0;

    public Transform player;

    public GameObject rotatingLight;

    private Vector3 spawnPoint;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        transform.LookAt(player);
        rigid.AddForce(transform.forward*(0.2f + deaths/200), ForceMode.VelocityChange);

        if (transform.position.y < -10)
        {
            // under the map
            Respawn();
        }
        rotatingLight.transform.RotateAroundLocal(Vector3.up, 0.2f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Respawn();
        }
    }

    void Respawn()
    {
        deaths++;
        rigid.velocity = Vector3.zero;
        gameObject.transform.position = spawnPoint;
        

    }
}
