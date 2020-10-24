using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int MaxHealth;
    private int CurrentHealth;

    public float InvincibleTime;
    private float CurrentTime;
    // Start is called before the first frame update
    void Start()
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
        CurrentHealth += change;
    }

    public float getTime()
    {
        return CurrentTime;
    }
}
