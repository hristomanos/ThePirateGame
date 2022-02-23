using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireCannon : MonoBehaviour
{
    [SerializeField] GameObject m_CannonBallPrefab;
    [SerializeField] List<Transform> m_SpawningPoints;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCanShoot())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < m_SpawningPoints.Count; i++)
                {
                    Instantiate(m_CannonBallPrefab, m_SpawningPoints[i].position, m_SpawningPoints[i].rotation);
                }
                GameManager.Instance.SubtractCannonballs(m_SpawningPoints.Count);
            }
        }
    }
}
