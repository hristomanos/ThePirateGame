using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonBall : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2D;

    [SerializeField] int   m_Speed;
    [SerializeField] float m_TimeAlive;

    [SerializeField] int    m_Damage;
    [SerializeField] string m_Shooter;
    [SerializeField] string m_Receiver;


    public delegate void HealthAction (int damage);
    public static event HealthAction OnDealingDamage;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, m_TimeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody2D.velocity = -transform.up * m_Speed;
    }


    bool collided = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "CannonBall" && collision.gameObject.tag != m_Shooter && !collided)
        {
            collided = true;

            //Check the tag against the receiver and depending on the name, call the associated script
            if (collision.gameObject.CompareTag(m_Receiver))
            {
                switch (m_Receiver)
                {
                    case "Enemy":
                        collision.GetComponent<AI>().TakeDamage(m_Damage);
                        break;
                    case "Player":
                        if (OnDealingDamage != null)
                        {
                            OnDealingDamage(m_Damage);
                        }
                        break;
                }

            }

            Destroy(gameObject);
        }
    }

}
