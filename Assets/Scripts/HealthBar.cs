using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 v;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        v = transform.localScale;
        width = v.x;
    }

    // Update is called once per frame
    void Update()
    {
        v.x = (float) DataManager.Instance.getHealth() / DataManager.Instance.MaxHealth * width;
        transform.localScale = v;
    }
}
