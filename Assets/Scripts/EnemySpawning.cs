using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject[] enemy;
    float randomNumberX;
    float randomNumberY;
    int randomEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawning());
    }

    // Update is called once per frame
    void Update()
    {
        randomNumberX = Random.Range(-9, 10);
        randomNumberY = Random.Range(-8, 9);
        randomEnemies = Random.Range(0, enemy.Length);
    }
    IEnumerator enemySpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy[randomEnemies], new Vector2(randomNumberX, randomNumberY), Quaternion.identity);
        }
    }

    


}
