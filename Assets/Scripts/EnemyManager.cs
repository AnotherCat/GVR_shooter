using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Transform[] SpawnPos;
    public Transform TheEnemyPrefab;
    public Transform ThePlayer;

    public float timeSpawn = 3f;
    public float timer = 1.5f;

    private int rangeRandom;

    void Start()
    {
        rangeRandom = SpawnPos.Length;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeSpawn)
        {
            timer = 0;
            for(int i = 0;i< 2; i++)
            {
                Transform theEnemy = (Transform)Instantiate(TheEnemyPrefab, SpawnPos[Random.Range(0, rangeRandom)].position, Quaternion.identity);
                theEnemy.GetComponent<NavMeshAgent>().SetDestination(ThePlayer.position);
            }
        }
    }
}
