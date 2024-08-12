using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject[] gem;
    [SerializeField] float speed = 5f;
    [SerializeField] int healthPoints = 50;
    //[SerializeField] int playerHealthPoints = 3;
    //[SerializeField] float playerSaveTimeSeconds = 1.5f;
    [SerializeField] int pointsGained = 5;
    public int enemyLevel;
    
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    //private void Start()
    //{
    //    scoreUI = GameObject.FindGameObjectWithTag("Score");
    //    scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //if(playerHealthPoints <= 0)
        //{
        //    Destroy(player);
        //}

    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthPoints -= 25;
        }

        if(healthPoints <= 0)
        {
           if(enemyLevel == 0)
           {
                Instantiate(gem[0], transform.position, Quaternion.identity);
           }

            if (enemyLevel == 1)
            {
                Instantiate(gem[1], transform.position, Quaternion.identity);
            }

            ScoreScript.instance.GainPoints(pointsGained);   
            Destroy(gameObject);
        }
    }

    
}
