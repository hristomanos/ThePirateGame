using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Add 10-15 cannon balls
            GameManager.Instance.AddCannonballs(Random.Range(50, 100));
            Destroy(gameObject);
        }
    }


}
