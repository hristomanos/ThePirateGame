using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int m_NumberOfCannonBalls;

    [SerializeField] GameObject m_CannonBallPrefab;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        m_NumberOfCannonBalls = 15;
    }

   public void AddCannonballs(int numberToAdd)
    {
        Debug.Log(numberToAdd + " number of balls added");
        m_NumberOfCannonBalls += numberToAdd;
    }

   public void InstantiateCannonball(Vector2 position)
    {
        Instantiate(m_CannonBallPrefab, position, Quaternion.identity);
    }

    void SubtractCannonballs(int numberToSubtract)
    {
        m_NumberOfCannonBalls -= numberToSubtract;

        if (m_NumberOfCannonBalls <= 0)
        {
            m_NumberOfCannonBalls = 0;
        }
    }

}
