using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Int healthValue;
    public int maxHealth; 
    public Image healthBar;

    void Start()
    {
        healthValue.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float) healthValue.value / maxHealth;
    }
}
