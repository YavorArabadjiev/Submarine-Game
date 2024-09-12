using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawningEnemyScript : MonoBehaviour
{

    [SerializeField] GameObject respawningEnemy;
    bool diedOnce = false;
    Transform deathPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnEnemy());
        
    }

    // Update is called once per frame
    void Update()
    {
        deathPos = respawningEnemy.transform;
        if (respawningEnemy.IsDestroyed())
        {
            diedOnce = true;
        }
    }

    IEnumerator RespawnEnemy()
    {
        while (true)
        {
            if (diedOnce)
            {
                yield return new WaitForSeconds(0.4f);
                Instantiate(respawningEnemy, deathPos);
            }
        }
    }
}
