using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script handles the player movement. 
//The movement should handle like a ship without taking the wind into acount.
//It will move forward by itself and turn based on player's input
public class PlayerMovement : MonoBehaviour
{
    [Header("Ship Attributes")]
    [SerializeField] Transform m_Motor;
    [Range(0f, 5f)]
    [SerializeField] private float m_Speed;
    [Range(0f, 5f)]
    [SerializeField] float m_SteerPower = 5f;

    private float m_InitialSpeed;

    Rigidbody2D m_Rigidbody;
    Quaternion m_StartRotation;

    float m_Horizontal;
    float m_Vertical;

    public float Speed
    {
        get => m_Speed;
        set => m_Speed = value;
    }

    float duration = 30;
    float timer;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_StartRotation = m_Motor.localRotation;
        m_InitialSpeed = m_Speed;

        duration = 10;
        timer = duration;
    }


    void Update()
    {
        m_Horizontal = Input.GetAxisRaw("Horizontal");
        m_Vertical = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        Sail();
        Turn();
    }

    //Move sprite forward
    void Sail()
    {
        //if (m_Vertical > 0)
        //{
        //    m_Rigidbody.velocity = -transform.up * m_Speed;
        //}
        //if (m_Vertical < 0)
        //{
        //    m_Rigidbody.velocity = Vector2.zero;
        //    m_Rigidbody.velocity = transform.up * m_Speed;
        //}

        m_Rigidbody.velocity = -transform.up * m_Speed;

        if (m_Speed > m_InitialSpeed)
        {
            SpeedBuff();
        }

    }

    void Turn()
    {
        m_Rigidbody.AddForceAtPosition(m_Horizontal * transform.right * m_SteerPower, m_Motor.position);
    }
    
    private void SpeedBuff()
    {
        timer -= Time.deltaTime;
        //UpdateUI
        GameManager.Instance.UpdateSpeedBuffUI(timer,duration);
        Debug.Log(timer);
        if (timer <= 0)
        {
            m_Speed = m_InitialSpeed;
            timer = duration;
        }
    }

}
