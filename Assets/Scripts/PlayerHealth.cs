using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = (float) DataManager.Instance.getHealth() / DataManager.Instance.MaxHealth;
    }
}
