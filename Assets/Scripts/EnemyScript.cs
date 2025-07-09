using System.Collections;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject[] gem;
    [SerializeField] float speed = 5f;
    public int healthPoints = 50;
    int randomNumber;
    [SerializeField] int pointsGained = 5;
    public int enemyLevel;
    [SerializeField] float knockbackPower = 50f;
    Rigidbody2D rb;
    Vector3 respawnEnemyPos;
    bool respawnEnemyDied = false;
    //[SerializeField] GameObject respawningEnemy;
    [HideInInspector] public static EnemyScript instance;
    [SerializeField] GameObject shieldPickUp;
    [SerializeField] GameObject flamePickup;
    
    
    AudioSource hitSound;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if(player != null)
        hitSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        //scoreUI = GameObject.FindGameObjectWithTag("Score");
        //scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
        instance = this;

        
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Side")
        {
            
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0, gameObject.transform.rotation.z);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null)
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        

        if (healthPoints <= 0)
        {
            if (enemyLevel == 0)
            {
                randomNumber = Random.Range(0, 6);
                if (randomNumber == 1)
                {
                    Instantiate(shieldPickUp, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(gem[0], transform.position, Quaternion.identity);
                }
               
                Destroy(gameObject);

            }

            if (enemyLevel == 1)
            {
                randomNumber = Random.Range(0, 6);
                if (randomNumber == 1)
                {
                    Instantiate(shieldPickUp, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(gem[1], transform.position, Quaternion.identity);
                }
               
                Destroy(gameObject);
            }

            if (enemyLevel == 3)
            {
                randomNumber = Random.Range(0, 6);
                if (randomNumber == 1)
                {
                    Instantiate(shieldPickUp, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(gem[2], transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }

            if (enemyLevel == 2)
            {
                if (!respawnEnemyDied)
                {
                    respawnEnemyPos = transform.position;
                    StartCoroutine(respawnEnemy());
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }

                if (respawnEnemyDied)
                {
                    int randomNumber = Random.Range(0, 3);
                    if (randomNumber == 1)
                    {
                        
                        Instantiate(flamePickup, gameObject.transform.position, Quaternion.identity);
                    }
                    Instantiate(gem[1], transform.position, Quaternion.identity);
                    //ObjectPooleManager.instance.ReturnToPool(gameObject);
                    Destroy(gameObject);
                }
            }

            EnemySpawning.instance.enemySpawnCount--;
            ScoreScript.instance.GainPoints(pointsGained);
        }

           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Side")
        {
          
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
            
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (ShootingScript.instance.level == 2)
                healthPoints -= 25;
            if (ShootingScript.instance.level == 3)
                healthPoints -= 50;

            if (!hitSound.isPlaying)
            {
                hitSound.Play();
            }
            healthPoints -= 25;

            Destroy(collision.gameObject);

            StartCoroutine(knockbackCoroutine(1f));

            IEnumerator knockbackCoroutine(float duration)
            {
                float timer = 0f;

                while (duration > timer)
                {
                    timer += Time.deltaTime;
                    Vector2 dir = (collision.transform.position - gameObject.transform.position).normalized;
                    
                    rb.AddForce(-dir * knockbackPower);
                }

                yield return new WaitForSeconds(0.3f);
                rb.velocity = Vector2.zero;
            }
        }

        if (collision.gameObject.tag == "Creature")
        {
            healthPoints -= 500;
        }

            if (collision.gameObject.tag == "AutoBullet")
        {
            healthPoints -= AutomaticFireWeapon.instance.autoWeaponShootPower;

            Destroy(collision.gameObject);

            StartCoroutine(knockbackCoroutine(1f));

            IEnumerator knockbackCoroutine(float duration)
            {
                float timer = 0f;

                while (duration > timer)
                {
                    timer += Time.deltaTime;
                    Vector2 dir = (collision.transform.position - gameObject.transform.position).normalized;

                    rb.AddForce(-dir * knockbackPower);
                }

                yield return new WaitForSeconds(0.3f);
                rb.velocity = Vector2.zero;
            }
        }

        

       
      
    }

    IEnumerator respawnEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        healthPoints = 80;
        respawnEnemyDied = true;
        StopCoroutine(respawnEnemy());
    }

}
