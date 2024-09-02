using System.Collections;
using UnityEngine;

public class AutomaticFireWeapon : MonoBehaviour
{
    [SerializeField] float shootTime = 2.5f;
    [SerializeField] GameObject[] autoPellets;
    GameObject player;
    float level = 0;
    [HideInInspector] public static AutomaticFireWeapon instance;
    public int autoWeaponShootPower = 25;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
        level++;
        if(level == 1)
        {
            StartCoroutine(autoShoot());
        }
        ExperienceBar.instance.upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        if(level == 2)
        {
            shootTime = 0.02f;
        }
        if(level == 3)
        {
            autoWeaponShootPower = 50;
        }
    }

    

    
}
