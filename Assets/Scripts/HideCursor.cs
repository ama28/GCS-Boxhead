using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }
}