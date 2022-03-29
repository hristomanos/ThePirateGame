using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : AI
{
    [Header("Flag")]
    [SerializeField] SpriteRenderer m_Renderer;
    [SerializeField] Sprite m_PirateFlag;

    [Header("Cannon")]
    [SerializeField] float m_ShootSeconds;



    void Start()
    {
        StartCoroutine(Counter());
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if(p_HP <= 0)
        {
            p_HP = 0;
            m_Renderer.sprite = m_PirateFlag;
            GameManager.Instance.AddScore(p_ScoreValue);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void FireCannon()
    {
        for (int i = 0; i < p_SpawningPoints.Count; i++)
        {
            Instantiate(p_CannonBallPrefab, p_SpawningPoints[i].position, p_SpawningPoints[i].rotation);
        }    
    }

    IEnumerator Counter()
    {
        while (p_HP > 0)
        {
            yield return new WaitForSeconds(m_ShootSeconds);
            FireCannon();
        }
    }

}
