using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject gem;
    [SerializeField] float speed = 5f;
    [SerializeField] int healthPoints = 50;
    [SerializeField] int playerHealthPoints = 3;
    [SerializeField] float playerSaveTimeSeconds = 1.5f;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(playerHealthPoints <= 0)
        {
            Destroy(player);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthPoints -= 25;
        }

        if(healthPoints <= 0)
        {
            Instantiate(gem);
            Destroy(gameObject);
        }
    }

    
}
