using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Transform[] SpawnPos;
    public Transform TheEnemyPrefab;
    public Transform ThePlayer;

    public float timeSpawn = 3f;
    public float timer = 1.5f;

    private int rangeRandom;
    public static int ENEMY_LIMIT = 10;

    void Start()
    {
        rangeRandom = SpawnPos.Length;
    }

    void OnGameOver()
    {
        if (GameManager.GameOver)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (ENEMY_LIMIT <= 0) return;

        timer += Time.deltaTime;
        if(timer >= timeSpawn)
        {
            timer = 0;

            Vector3 previousPos = new Vector3(0,0,0);
            Vector3 pos = previousPos;
            for(int i = 0;i< 3; i++)
            {
                while(previousPos == pos)
                {
                    pos = SpawnPos[Random.Range(0, rangeRandom)].position;
                }
                Transform theEnemy = (Transform)Instantiate(TheEnemyPrefab,pos, Quaternion.identity);
                theEnemy.GetComponent<NavMeshAgent>().SetDestination(ThePlayer.position);
                previousPos = pos;
                ENEMY_LIMIT--;
                if(ENEMY_LIMIT <= 0)
                {
                    break;
                }
            }
        }

        OnGameOver();
    }
}
