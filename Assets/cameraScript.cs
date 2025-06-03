using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x < -16.6f || player.transform.position.x > 12.8f)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
