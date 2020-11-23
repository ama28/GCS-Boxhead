using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if(healthValue.value == 0)
        {
            SceneManager.LoadScene("floor_1");
            DataManager.Instance.Initialize();
        }
    }
}
