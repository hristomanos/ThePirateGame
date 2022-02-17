using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonBall : MonoBehaviour
{

    [SerializeField] int m_Speed;
    [SerializeField] float m_TimeAlive;
    Rigidbody2D m_Rigidbody2D;

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
}
