using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject enemy;
    float randomNumberX;
    float randomNumberY;
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
    }
    IEnumerator enemySpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, new Vector2(randomNumberX, randomNumberY), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }


}
