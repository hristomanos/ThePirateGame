using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    [SerializeField] GameObject m_CannonBallPrefab;
    [SerializeField] Transform m_SpawningPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(m_CannonBallPrefab, m_SpawningPoint.position,m_SpawningPoint.rotation);
        }
    }
}
