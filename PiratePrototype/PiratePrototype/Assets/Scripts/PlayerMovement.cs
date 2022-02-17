using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script handles the player movement. 
//The movement should handle like a ship without taking the wind into acount.
//It will move forward by itself and turn based on player's input
public class PlayerMovement : MonoBehaviour
{
    [Range(0f,5f)]
    [SerializeField] float m_Speed;
   [SerializeField] float m_Torque;

    [SerializeField] Transform m_Motor;

    [Range(0f, 5f)]
   [SerializeField] float m_SteerPower = 5f;
    
    float m_Power = 5f;
    float m_Drag = 0.1f;

    Rigidbody2D m_Rigidbody;
    Quaternion m_StartRotation;

    float m_Horizontal;
    

    bool m_IsTurningLeft = false;
    bool m_IsTurningRight = false;

    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_StartRotation = m_Motor.localRotation;
    }


    void Update()
    {
        m_Horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        

    }

    private void FixedUpdate()
    {
        SailForward();
        TurnLeft();
    }

    //Move sprite forward
    void SailForward()
    {
        m_Rigidbody.velocity = -transform.up * m_Speed;
    }

    void TurnLeft()
    {
        m_Rigidbody.AddForceAtPosition(m_Horizontal * transform.right * m_SteerPower, m_Motor.position);
    }
        

    

}
