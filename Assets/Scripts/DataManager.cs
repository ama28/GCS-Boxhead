﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int MaxHealth;
    private int CurrentHealth;

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
        CurrentHealth = MaxHealth;
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
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

        CurrentHealth += change;
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
