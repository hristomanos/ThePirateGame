using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;
    [SerializeField] List<Sprite> m_DamagedSprites;

    [SerializeField] int m_Health;

    // Start is called before the first frame update
    void Start()
    {
        CannonBall.OnTakingDamage += TakenDamage;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpriteBasedOnHealth();

    }

    void TakenDamage(int damage)
    {   
        m_Health -= damage;
        if (m_Health <= 0)
        {
            m_Health = 0;
            CannonBall.OnTakingDamage -= TakenDamage;
            Destroy(gameObject);
        }
    }


    void ChangeSpriteBasedOnHealth()
    {
        if (m_Health <= 100 && m_Health >= 60)
        {
            m_SpriteRenderer.sprite = m_DamagedSprites[0];
        }

        if (m_Health <= 59 && m_Health >= 30)
        {
            m_SpriteRenderer.sprite = m_DamagedSprites[1];
        }

        if (m_Health <= 29 && m_Health >= 0)
        {
            m_SpriteRenderer.sprite = m_DamagedSprites[2];
        }

        if (m_Health <= 0)
        {
            m_SpriteRenderer.sprite = m_DamagedSprites[3];
        }
    }

}
