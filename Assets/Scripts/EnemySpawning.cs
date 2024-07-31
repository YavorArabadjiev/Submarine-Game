using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject[] enemy;
    float randomNumberX;
    float randomNumberX2;
    float EnemySpawnY;
    int randomEnemies;
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
        //randomNumberY = Random.Range(-8, 9);

        randomEnemies = Random.Range(0, enemy.Length);
    }
    IEnumerator enemySpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, player.transform.position.y - 8f), Quaternion.identity);
            Instantiate(enemy[randomEnemies], new Vector2(randomNumberX2, player.transform.position.y + 8f), Quaternion.identity);
        }
    }

    


}
