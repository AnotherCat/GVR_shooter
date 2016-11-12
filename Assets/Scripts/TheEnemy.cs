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
}
