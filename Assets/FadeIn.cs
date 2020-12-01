using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image whiteFade;
    // Start is called before the first frame update
    void Start()
    {
        whiteFade = this.gameObject.GetComponent<Image>();
        whiteFade.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    public void fadeIn(float time)
    {
        whiteFade.CrossFadeAlpha(1, time, false);
    }

    public void fadeOut(float time)
    {
        whiteFade.CrossFadeAlpha(0, time, false);
    }
}
