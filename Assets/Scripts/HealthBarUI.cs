using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
   public float healthPoints, maxHealth, width, height;
   [SerializeField] RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetHealth(float healthPoints)
    {
        this.healthPoints = healthPoints;
        float newWidth = (healthPoints / maxHealth) * width;
        healthBar.sizeDelta = new Vector2 (newWidth, height);
    }
}
