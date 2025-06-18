using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject bossEnemy;
    float randomNumberX;
    float randomNumberX2;
    int randomEnemies1;
    int randomEnemies2;
    [SerializeField] Vector2[] randomSpawnPos;
    int randomSpawnRange;
    bool reduceBossSpawn;
    float bossSpawnTime = 30f;
   [HideInInspector] public int enemySpawnCount = 0;
    public static EnemySpawning instance;
    //[SerializeField] float timeTillNextPhase = 5f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(enemySpawning1());
        //StartCoroutine(spawnStrongerEnemies());
        StartCoroutine(bossSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        randomNumberX = Random.Range(-9, 10);
        randomNumberX2 = Random.Range(-9, 10);
        randomEnemies1 = Random.Range(0, 2);
        randomEnemies2 = Random.Range(0, enemy.Length + 1);
        

        //print(enemySpawnCount);

    }
    IEnumerator enemySpawning1()
    {
        
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.y - 8f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.x - 14f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.x + 14f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.y + 8f), Quaternion.identity);
                if(player != null)
                {
                    randomSpawnPos[0] = new Vector2(randomNumberX, player.transform.position.y - 8f);
                    randomSpawnPos[1] = new Vector2(randomNumberX, player.transform.position.x - 14f);
                    randomSpawnPos[2] = new Vector2(randomNumberX2, player.transform.position.x + 14f);
                    randomSpawnPos[3] = new Vector2(randomNumberX2, player.transform.position.y + 8f);
                }
                
                randomSpawnRange = Random.Range(0, randomSpawnPos.Length);
                Instantiate(enemy[0], randomSpawnPos[randomSpawnRange], Quaternion.identity);


            //if (enemySpawnCount != 50)
            //{
            //    Instantiate(enemy[0], randomSpawnPos[randomSpawnRange], Quaternion.identity);
            //    enemySpawnCount++;
            //}


            if (ExperienceBar.instance.level == 3)
                {
                    StartCoroutine(enemySpawning2());
                    StopCoroutine(enemySpawning1());
                }
               
            }
        
       


    }
    IEnumerator enemySpawning2()
    {

           
            while (true)
            {

                yield return new WaitForSeconds(3f);
                if(player != null)
                {
                    randomSpawnPos[0] = new Vector2(randomNumberX, player.transform.position.y - 8f);
                    randomSpawnPos[1] = new Vector2(randomNumberX, player.transform.position.x - 14f);
                    randomSpawnPos[2] = new Vector2(randomNumberX2, player.transform.position.x + 14f);
                    randomSpawnPos[3] = new Vector2(randomNumberX2, player.transform.position.y + 8f);
                }
                
                randomSpawnRange = Random.Range(0, randomSpawnPos.Length);
                Instantiate(enemy[randomEnemies1], randomSpawnPos[randomSpawnRange], Quaternion.identity);

            //if (enemySpawnCount != 50)
            //{
            //    Instantiate(enemy[randomEnemies1], randomSpawnPos[randomSpawnRange], Quaternion.identity);
            //    enemySpawnCount++;
            //}

            if (ExperienceBar.instance.level == 5)
            {
                StartCoroutine(enemySpawning3());
                StopCoroutine(enemySpawning2());
            }
        }
    }

    IEnumerator enemySpawning3()
    {
        reduceBossSpawn = true;
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (player != null)
            {
                randomSpawnPos[0] = new Vector2(randomNumberX, player.transform.position.y - 8f);
                randomSpawnPos[1] = new Vector2(randomNumberX, player.transform.position.x - 14f);
                randomSpawnPos[2] = new Vector2(randomNumberX2, player.transform.position.x + 14f);
                randomSpawnPos[3] = new Vector2(randomNumberX2, player.transform.position.y + 8f);
            }

            randomSpawnRange = Random.Range(0, randomSpawnPos.Length);
            Instantiate(enemy[randomEnemies2], randomSpawnPos[randomSpawnRange], Quaternion.identity);

            //if (enemySpawnCount != 50)
            //{
            //    Instantiate(enemy[randomEnemies2], randomSpawnPos[randomSpawnRange], Quaternion.identity);
            //    enemySpawnCount++;
            //}

        }
    }
       

    IEnumerator bossSpawning()
    {
            
            while (true)
            {
                yield return new WaitForSeconds(bossSpawnTime);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.y - 8f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.x - 14f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.x + 14f), Quaternion.identity);
                //Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.y + 8f), Quaternion.identity);
                randomSpawnPos[0] = new Vector2(randomNumberX, player.transform.position.y - 8f);
                randomSpawnPos[1] = new Vector2(randomNumberX, player.transform.position.x - 14f);
                randomSpawnPos[2] = new Vector2(randomNumberX2, player.transform.position.x + 14f);
                randomSpawnPos[3] = new Vector2(randomNumberX2, player.transform.position.y + 8f);
                randomSpawnRange = Random.Range(0, randomSpawnPos.Length);
                Instantiate(bossEnemy, randomSpawnPos[randomSpawnRange], Quaternion.identity);

                if (reduceBossSpawn)
                {
                    bossSpawnTime = bossSpawnTime - 10f;
                }
            }
    }
    
}


