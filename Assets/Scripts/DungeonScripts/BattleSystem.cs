using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle, 
        Active,
        BattleOver,
    }

    [SerializeField] private Wave[] waveArray;
    [SerializeField] private ColliderTrigger colliderTrigger;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if(state == State.Idle)
        StartBattle();
        colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void StartBattle()
    {
        Debug.Log("Start Battle");
        state = State.Active;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                TestBattleOver();   
                break;
        }
    }

    private void TestBattleOver()
    {
        if(state == State.Active)
        {
            if (areWavesOver())
            {
                state = State.BattleOver;
                Debug.Log("Battle is over");
            }
        }
    }

    private bool areWavesOver()
    {
        foreach (Wave wave in waveArray)
        {
            if (wave.isWaveOver())
            {

            }
            else
            {
                return false;
            }
        }
        return true;
    }


    [System.Serializable]
    private class Wave
    {
        [SerializeField] private EnemySpawn[] enemySpawnArray;
        [SerializeField] private float timer;

        public void Update()
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }

        private void SpawnEnemies()
        {
            foreach (EnemySpawn enemySpawn in enemySpawnArray)
            {
                enemySpawn.Spawn();
            }
        }

        public bool isWaveOver()
        {
            if(timer < 0)
            {
                foreach(EnemySpawn enemySpawn in enemySpawnArray)
                {
                    if(enemySpawn.isAlive())
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
