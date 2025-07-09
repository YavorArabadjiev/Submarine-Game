using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    Rigidbody2D rb;
   [SerializeField] int fireballSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyFireBall());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fireballSpeed, 0));
        
    }

    IEnumerator DestroyFireBall()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
