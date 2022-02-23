using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    int m_NumberOfCannonBalls;

    [SerializeField] GameObject m_CannonBallPrefab;
    [SerializeField] GameObject m_HealthPickUpPrefab;

    [SerializeField] TextMeshProUGUI m_HealthText;
    [SerializeField] TextMeshProUGUI m_CannonballText;

    [SerializeField] 
    bool g_CanShoot = true;

    public bool GetCanShoot() { return g_CanShoot; }

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
        m_NumberOfCannonBalls = 60;
    }

    public void AddCannonballs(int numberToAdd)
    {
        m_NumberOfCannonBalls += numberToAdd;

        if (g_CanShoot == false)
        {
            g_CanShoot = true;
        }

        m_CannonballText.text = "Cannonballs: " + m_NumberOfCannonBalls.ToString();
    }

   public void InstantiateCannonball(Vector2 position)
    {
        Instantiate(m_CannonBallPrefab, position, Quaternion.identity);
    }
    public void InstantiateHealthPickUp(Vector2 position)
    {
        //int randomNum = Random.Range(0, 1);
        //if (randomNum > 0)
        //{
        //    Vector2 offset = position + new Vector2(position.x, 0.5f);
        //    Instantiate(m_HealthPickUpPrefab, position, Quaternion.identity);
        //}
        //else
        //{
        //    Debug.Log(randomNum);
        //}

        float offsetY = 0.4f;
        Vector2 offset = position + new Vector2(position.x, offsetY);
        Instantiate(m_HealthPickUpPrefab, offset, Quaternion.identity);

    }


    public void SubtractCannonballs(int numberToSubtract)
    {
        m_NumberOfCannonBalls -= numberToSubtract;

        if (m_NumberOfCannonBalls <= 0)
        {
            m_NumberOfCannonBalls = 0;
            g_CanShoot = false;
        }

        m_CannonballText.text = "Cannonballs: " + m_NumberOfCannonBalls.ToString();
    }

    public void UpdateHealthText(string text)
    {
        m_HealthText.text = "Health: " + text;
    }

}
