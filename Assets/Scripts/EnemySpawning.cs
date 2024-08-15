using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class EnemySpawning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject[] enemy;
    float randomNumberX;
    float randomNumberX2;
    int randomEnemies;
    int stagePhase = 1;
     
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(enemySpawning());
    }

    // Update is called once per frame
    void Update()
    {
        randomNumberX = Random.Range(-9, 10);
        randomNumberX2 = Random.Range(-9, 10);
        randomEnemies = Random.Range(0, enemy.Length);

        if(Time.time == 5)
        {
            stagePhase++;
        }

    }
    IEnumerator enemySpawning()
    {
        if(stagePhase == 1)
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.y - 8f), Quaternion.identity);
                Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.x - 14f), Quaternion.identity);
                Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.x + 14f), Quaternion.identity);
                Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.y + 8f), Quaternion.identity);
            }
        }

        if(stagePhase == 2)
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime - 1);
                Instantiate(enemy[1], new Vector2(randomNumberX, player.transform.position.y - 8f), Quaternion.identity);
                Instantiate(enemy[1], new Vector2(randomNumberX2, player.transform.position.y + 8f), Quaternion.identity);
            }
        }
        
    }

    


}
