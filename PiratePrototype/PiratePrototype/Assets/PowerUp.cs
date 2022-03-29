using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   [SerializeField] PowerUpEffect m_PowerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_PowerUpEffect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
