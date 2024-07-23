using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 5f;
    [SerializeField] int healthPoints = 50;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");            
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthPoints -= 25;
        }

        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
