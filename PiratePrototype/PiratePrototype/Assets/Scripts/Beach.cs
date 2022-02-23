using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity /= 2;
    }

}
