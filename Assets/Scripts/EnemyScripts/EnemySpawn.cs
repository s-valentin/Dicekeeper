using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private EnemyHealth enemy;

    void Awake()
    {
        gameObject.SetActive(false);
        enemy = GetComponent<EnemyHealth>();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        //transform.SetParent(null);
    }

    public bool isAlive()
    {
        return !enemy.isDead();
    }
}
