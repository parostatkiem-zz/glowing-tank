using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemy_prefab;
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //var enemy_instance = Instantiate(enemy_prefab, new Vector3(10f, 0f, 10f),new Quaternion(0,0,0,0));
    }
}
