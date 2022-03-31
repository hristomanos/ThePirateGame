using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : AI
{
    [Header("Cannon")]
    [SerializeField] float m_ShootSeconds;

    [SerializeField] Transform m_Player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Counter());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 8)
        {
            transform.right = m_Player.position - transform.position;
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (p_HP < 0)
        {
            p_HP = 0;
            GameManager.Instance.InstantiateCannonball(transform.position);
            GameManager.Instance.InstantiateHealthPickUp(transform.position);
            GameManager.Instance.AddScore(p_ScoreValue);
            Destroy(gameObject);
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
