using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class EnemySpawning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject bossEnemy;
    float randomNumberX;
    float randomNumberX2;
    int randomEnemies;
    [SerializeField] int stagePhase = 1;
    [SerializeField] Vector2[] randomSpawnPos;
    int randomSpawnRange;
    [SerializeField] float timeTillNextPhase = 5f;
    float phaseTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(enemySpawning());
        StartCoroutine(bossSpawning());
        //StartCoroutine(spawnStrongerEnemies());
        phaseTimeCounter = timeTillNextPhase;
    }

    // Update is called once per frame
    void Update()
    {
        randomNumberX = Random.Range(-9, 10);
        randomNumberX2 = Random.Range(-9, 10);
        randomEnemies = Random.Range(0, enemy.Length - 1);
        phaseTimeCounter -= Time.deltaTime;

        if (phaseTimeCounter <= 0)
        {
            stagePhase++;
            phaseTimeCounter = timeTillNextPhase;
        }

    }
    IEnumerator enemySpawning()
    {
        if (stagePhase == 1)
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
                Instantiate(enemy[randomEnemies], randomSpawnPos[randomSpawnRange], Quaternion.identity);
            }
        }
        if (stagePhase >= 2)
        {
            print("wave 2");
        }


    }
    IEnumerator spawnStrongerEnemies()
    {
        while (true)
        {

            yield return new WaitForSeconds(15f);
            randomSpawnPos[0] = new Vector2(randomNumberX, player.transform.position.y - 8f);
            randomSpawnPos[1] = new Vector2(randomNumberX, player.transform.position.x - 14f);
            randomSpawnPos[2] = new Vector2(randomNumberX2, player.transform.position.x + 14f);
            randomSpawnPos[3] = new Vector2(randomNumberX2, player.transform.position.y + 8f);
            randomSpawnRange = Random.Range(0, randomSpawnPos.Length);
            Instantiate(enemy[2], randomSpawnPos[randomSpawnRange], Quaternion.identity);
        }

    }

    IEnumerator bossSpawning()
    {
        if (stagePhase == 1)
        {
            while (true)
            {
                yield return new WaitForSeconds(30f);
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
            }
        }
    }
}
