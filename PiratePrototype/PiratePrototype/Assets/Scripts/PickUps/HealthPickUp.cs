using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] int m_HealAmount;

    public delegate void HealthPackAction(int amount);
    public static event HealthPackAction OnHealing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Add 10-15 cannon balls
            if (OnHealing != null)
            {
                OnHealing(m_HealAmount);
            }
            Destroy(gameObject);
        }
    }
}
