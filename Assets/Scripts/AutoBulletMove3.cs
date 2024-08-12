using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletMove3 : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyObject());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);

    }

    IEnumerator destroyObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
        
    }
}
