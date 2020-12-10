using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int MaxHealth;
    private int CurrentHealth;
    public bool invincible = false;
    public bool infiniteAmmo = false;
    public int ammo = 0;

    public float InvincibleTime;
    
    private float CurrentTime;

    public GameEvent Death;
    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        invincible = false;
        CurrentHealth = MaxHealth;
        CurrentTime = 0;
        if(infiniteAmmo) {
            ammo = 99999999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        if(ammo < 0) {
            ammo = 0;
        }
    }

    public void ResetTimer()
    {
        CurrentTime = InvincibleTime;
    }

    public int getHealth()
    {
        return CurrentHealth;
    }

    public void changeHealth(int change)
    {
        if(CurrentHealth + change > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if (change > 0)
        {
            CurrentHealth += change;
        }
        else
        {
            if (!invincible) CurrentHealth += change;
        }

        if(CurrentHealth <= 0)
        {
            Death.Raise();
        } else if(CurrentHealth < MaxHealth/4) {
            AudioManager.PlaySound(AudioManager.Sound.LowHealth, transform.position);
        }
    }

    public float getTime()
    {
        return CurrentTime;
    }
}
