using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossShooting : MonoBehaviour
{
    [SerializeField] GameObject[] shootPoints;
    [SerializeField] GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootFireball());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int randomNumber = Random.Range(0, shootPoints.Length);
            Instantiate(fireBall, shootPoints[randomNumber].transform.position, Quaternion.identity);
            randomNumber = Random.Range(0, shootPoints.Length);
            Instantiate(fireBall, shootPoints[randomNumber].transform.position, Quaternion.identity);
        }
        
    }
}
