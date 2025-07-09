using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossScript : MonoBehaviour
{
    AudioSource hitSound;
    [SerializeField] int healthPoints, maxHealth;
    [SerializeField] HealthBarUI healthBar;
    [SerializeField] GameObject winMenu;
    [SerializeField] AudioSource music;
    AudioSource bossMusic;
    // Start is called before the first frame update
    void Start()
    {
        bossMusic = GetComponent<AudioSource>();
        music.Stop();
        bossMusic.Play();
        hitSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            winMenu.SetActive(true);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        if (ShootingScript.instance.level == 2)
    //            SetHealth(-25);
    //        if (ShootingScript.instance.level == 3)
    //            SetHealth(-50);

    //        if (!hitSound.isPlaying)
    //        {
    //            hitSound.Play();
    //        }
    //        healthPoints -= 25;

    //        Destroy(collision.gameObject);
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            SetHealth(-50);
            if (ShootingScript.instance.level == 2)
                SetHealth(-25);
            if (ShootingScript.instance.level == 3)
                SetHealth(-50);

            if (!hitSound.isPlaying)
            {
                hitSound.Play();
            }
            healthPoints -= 25;

            Destroy(collision.gameObject);
        }
    }

    public void SetHealth(int healthChange)
    {
        healthPoints += healthChange;
        healthPoints = Mathf.Clamp(healthPoints, 0, maxHealth);

        healthBar.SetHealth(healthPoints);
    }
}
