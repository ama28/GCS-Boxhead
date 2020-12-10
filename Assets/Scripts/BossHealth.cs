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
    public Image bossImage;
    public GameObject boss;
    public GameObject whiteFade;
    public GameObject MainCamera;
    public GameObject pistol;
    public GameObject canvas;

    private bool alive = true;

    void Start()
    {
        healthValue.value = maxHealth;
        GameObject whiteFadeParent = whiteFade.transform.parent.gameObject;
        whiteFadeParent.SetActive(true);
        whiteFadeParent.GetComponent<Canvas>().sortingOrder = 2;
        whiteFade.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)healthValue.value / maxHealth;
        if (healthValue.value <= 0 && alive)
        {
            StartCoroutine("BossDie");
            alive = false;
        }
    }

    IEnumerator BossDie()
    {
        GameObject gun = GameObject.Find("Gun");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<BasicMovement>().enabled = false;
        DataManager.Instance.invincible = true;
        gun.GetComponent<FirePistol>().enabled = false;
        boss.GetComponent<Boss>().enabled = false;
        bossImage.enabled = false;
        AudioManager.PlaySound(AudioManager.Sound.DogDeath, transform.position);
        Vector3 cameraOriginalPos = MainCamera.transform.localPosition;
        //1 seconds of shake
        for (int i = 0; i < 100; i++)
        {
            shake(3f, cameraOriginalPos);
            yield return new WaitForSeconds(0.01f);
        }
        whiteFade.GetComponent<FadeIn>().fadeIn(2.1f);
        //3.6 seconds of shake
        for (int i = 0; i < 240; i++)
        {
            shake(4f, cameraOriginalPos);
            yield return new WaitForSeconds(0.01f);
        }
        MainCamera.GetComponent<AudioSource>().Stop();
        boss.SetActive(false);
        whiteFade.GetComponent<FadeIn>().fadeOut(4f);
        yield return new WaitForSeconds(6f);
        whiteFade.GetComponent<FadeIn>().fadeIn(3f);
        yield return new WaitForSeconds(3.1f);

        //SceneManager.LoadScene("floor_1");
        DataManager.Instance.Initialize();
        canvas.GetComponent<EndMenu>().showEnd();
    }

    void shake(float shakeAmount, Vector3 originalPos)
    {
        if (shakeAmount > 0)
        {
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            originalPos.x += offsetX;
            originalPos.y += offsetY;

            MainCamera.transform.localPosition = originalPos;
        }
    }
}
