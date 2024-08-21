using System.Collections;
using UnityEngine;

public class AutomaticFireWeapon : MonoBehaviour
{
    [SerializeField] float shootTime = 2.5f;
    [SerializeField] GameObject[] autoPellets;
    GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(autoShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator autoShoot() 
    { 
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            
                Instantiate(autoPellets[0], new Vector2(player.transform.position.x, player.transform.position.y + 1), Quaternion.identity);
                Instantiate(autoPellets[1], new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity);
                Instantiate(autoPellets[2], new Vector2(player.transform.position.x + 1, player.transform.position.y), Quaternion.identity);
                Instantiate(autoPellets[3], new Vector2(player.transform.position.x - 1, player.transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(1f);

            
        }
    }

    public void AutoBulletsButton()
    {
        StartCoroutine(autoShoot());
        ExperienceBar.instance.upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    

    
}
