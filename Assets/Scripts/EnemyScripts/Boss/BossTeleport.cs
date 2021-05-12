using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    private Transform player;
    private Transform boss;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GetComponent<Transform>();
    }

    public void Teleport()
    {
        boss.transform.position = player.transform.position;
    }
}
