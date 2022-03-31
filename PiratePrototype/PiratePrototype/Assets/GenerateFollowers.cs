using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFollowers : MonoBehaviour
{
    [SerializeField] List<GameObject> m_FollowerPrefabs;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Instantiate follower
            for (int i = 0; i < m_FollowerPrefabs.Count; i++)
            {
                m_FollowerPrefabs[i].SetActive(true);
            }        
        }   
    }
}
