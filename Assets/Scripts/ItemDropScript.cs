using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{
    int health = 3;
 
    [SerializeField] GameObject heartPickUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //random = Random.Range(0, 3);
            //if (random == 0)
            //{
                Instantiate(heartPickUp, gameObject.transform.position, Quaternion.identity);
            //}
            Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            print(health);
        }
    }
}
