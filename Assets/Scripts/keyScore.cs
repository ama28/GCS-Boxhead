using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyScore : MonoBehaviour
{
    public static int bossKeys = 0;
    public static int stairKeys = 0;
    public bool isBossKey;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossKey)
        {
            score.text = bossKeys + "/4";
        }
        else
        {
            score.text = stairKeys + "/5";
        }
    }
}
