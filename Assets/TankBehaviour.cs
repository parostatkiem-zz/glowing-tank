using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TankBehaviour : MonoBehaviour {

   
    [Header("Difficulty")]
    public bool tankRotatesOnlyWhenMoving;


 
    [Header("Settings")]
    public float tankRotationSpeed = 1;
    public float towerRotationSpeed = 1;
    public float velocity = 1000;


    [Header("Objects")]
    public GameObject enabledWhenDriving;
    public Transform tower;


    private Rigidbody rigid;
    float tankAngle;
    float currentVelocity;

    List<float> tankAngles;

    private ParticleSystem particlesEnabledWhenDriving;


    // Use this for initialization
    void Start () {
        particlesEnabledWhenDriving = enabledWhenDriving.GetComponent<ParticleSystem>();
        particlesEnabledWhenDriving.Stop();
        tankAngles = new List<float>();
        rigid = GetComponent<Rigidbody>();
   
    }
	
	// Update is called once per frame
	void FixedUpdate () {
      
        if (transform.position.y < 0)
        {
            //TODO: śmierć - spadł poza mape
        }

        tankAngles.Clear();
    
        if (Input.GetKey(KeyCode.W))
            {
            tankAngles.Add(-90);
        }
        if (Input.GetKey(KeyCode.S))
        {
            tankAngles.Add(90);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                tankAngles.Add(-180);
            }
            else {
                tankAngles.Add(180);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            tankAngles.Add(0);
        }

        var newRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, tankAngle, 0)), Time.deltaTime * tankRotationSpeed);

        if (tankAngles.Count > 0) {
             tankAngle = tankAngles.Average();
            currentVelocity = velocity;

            particlesEnabledWhenDriving.Play();

            if(tankRotatesOnlyWhenMoving)
             transform.rotation = newRotation;
        }
        else
        {
            currentVelocity = 0;
            particlesEnabledWhenDriving.Stop();
        }

      

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(tower.transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        tower.transform.rotation = Quaternion.Lerp(tower.transform.rotation, Quaternion.Euler(new Vector3(0f, -angle + 180, 0)), Time.deltaTime * towerRotationSpeed);


        if (!tankRotatesOnlyWhenMoving)
            transform.rotation = newRotation;

        rigid.AddForce(transform.right * currentVelocity);

    }
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


}
