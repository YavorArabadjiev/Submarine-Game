using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePowerUp : MonoBehaviour
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject creatureButton;
    private GameObject creature;
    private float level = 1;
    [SerializeField] float speed;
    public void CreaturePowerUpButton()
    {
        if(level == 1)
        {
            Instantiate(creaturePrefab, new Vector3(player.transform.position.x, player.transform.position.y - 2, player.transform.position.z), Quaternion.identity);
            creature = GameObject.FindGameObjectWithTag("Creature");
        }

        if(level == 2)
        {
            creature.GetComponent<Renderer>().material.color = Color.red;
            CreatureScript.instance.StopCoroutine(CreatureScript.instance.MoveAround());
        }

        if (level == 3) 
        { 
            creatureButton.SetActive(false);
        }
        ShootingScript.instance.upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
        level++;

    }

    void FixedUpdate()
    {
        if (player != null && level == 2)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

       
    }
}
