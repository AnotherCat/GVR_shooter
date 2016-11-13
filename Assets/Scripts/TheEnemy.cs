using UnityEngine;
using System.Collections;

public class TheEnemy : MonoBehaviour {

    [SerializeField]
    private NavMeshAgent NMA;

    public int HP = 1;
    
    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (!NMA.pathPending)
        {
            if (NMA.remainingDistance <= NMA.stoppingDistance)
            {
                if (!NMA.hasPath || NMA.velocity.sqrMagnitude == 0f)
                {
                    GameManager.LIFE--;
                    Destroy(gameObject);
                }
            }
        }

        if (GameManager.GameOver)
        {
            Destroy(gameObject);
        }
    }
    
}
