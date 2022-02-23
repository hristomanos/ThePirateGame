using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] protected int p_HP;
    [SerializeField] protected GameObject p_CannonBallPrefab;
    [SerializeField] protected List<Transform> p_SpawningPoints;


    // Update is called once per frame
    void Update()
    {
       
    }


     public virtual void TakeDamage(int damage)
     {
        p_HP -= damage;
     }

    

}
