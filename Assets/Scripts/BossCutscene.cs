using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCutscene : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject player;
    public GameObject boss;
    public GameObject bossUI;
    private float cameraOffset = 16f;
    private int cameraZoomOut = 7;
    private bool triggered = false;
    private FirePistol[] pistols;
    public GameObject canvas;

    public GameObject whiteFade;

    public Image bossImage;
    private bool done = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggered && collision.gameObject.tag == "Player") {
            pistols = player.GetComponentsInChildren<FirePistol>(true);
            StartCoroutine("Cutscene");
            triggered = true;
        }
    }

    private void Start() {
        GameObject whiteFadeParent = whiteFade.transform.parent.gameObject;
        whiteFadeParent.SetActive(true);
        whiteFadeParent.GetComponent<Canvas>().sortingOrder = 2;
        whiteFade.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
    }

    private void Update() {
        if(triggered && !done) {
            for(int i = 0; i < pistols.Length; i++) {
                pistols[i].setCameraPos(new Vector3(0, 17, -10));
            }
        }
    }

    private IEnumerator Cutscene() {

        Destroy(GetComponent<BoxCollider2D>());
        player.GetComponent<BasicMovement>().enabled = false;
        for(int i = 0; i < pistols.Length; i++) {
            pistols[i].enabled = false;
        }
        Camera cam = MainCamera.GetComponent<Camera>();
        //Zoom out
        Vector3 EndPosition = new Vector3(MainCamera.transform.localPosition.x, cameraOffset, MainCamera.transform.localPosition.z);
        StartCoroutine("ZoomOut");
        yield return new WaitForSeconds(1f);
        //Play Roar
        AudioManager.PlaySound(AudioManager.Sound.DogRoar, transform.position);
        yield return new WaitForSeconds(1.3f);
        //Start music on big roar
        MainCamera.GetComponent<AudioSource>().Play();
        //Screen shake during roar
        Vector3 cameraOriginalPos = MainCamera.transform.localPosition;
        for(int i = 0; i < 100; i ++) {
            shake(3f, cameraOriginalPos);
            yield return new WaitForSeconds(0.01f);
        }
        MainCamera.transform.localPosition = cameraOriginalPos;
        player.GetComponent<BasicMovement>().enabled = true;
        for(int i = 0; i < pistols.Length; i++) {
            pistols[i].enabled = true;
        }
        boss.GetComponent<Boss>().enabled = true;
        bossUI.SetActive(true);
        //return to original with lifted camera
        while(cam.orthographicSize > 5 + 0.1 || MainCamera.transform.localPosition.y > cameraOffset + 0.1f) {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, Time.deltaTime * 2);
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, EndPosition, Time.deltaTime * 3);
            for(int i = 0; i < pistols.Length; i++) {
                pistols[i].setCameraPos(MainCamera.transform.localPosition);
            }
            yield return null;
        }
        cam.orthographicSize = 5;
        MainCamera.transform.localPosition = new Vector3(0, 18, -10);
        for(int i = 0; i < pistols.Length; i++) {
            pistols[i].setCameraPos(new Vector3(0, 18, -10));
        }
        done = true;
    }

    private IEnumerator ZoomOut() {
        Vector3 EndPosition = new Vector3(MainCamera.transform.localPosition.x, cameraOffset, MainCamera.transform.localPosition.z);
        Camera cam = MainCamera.GetComponent<Camera>();
        while(cam.orthographicSize < cameraZoomOut - 1 || MainCamera.transform.localPosition.y < cameraOffset - 1f) {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cameraZoomOut, Time.deltaTime);
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, EndPosition, Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator BossDie()
    {
        boss.GetComponent<Boss>().Die();
        for(int i = 0; i < pistols.Length; i++) {
            pistols[i].enabled = false;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<BasicMovement>().enabled = false;
        DataManager.Instance.invincible = true;
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
            if(i == 180) {
                MainCamera.GetComponent<AudioSource>().Stop();
            }
            yield return new WaitForSeconds(0.01f);
        }
        boss.GetComponent<Boss>().Disappear();
        boss.GetComponent<Boss>().enabled = false;
        boss.SetActive(false);
        player.GetComponent<BasicMovement>().enabled = true;
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
        if(shakeAmount > 0)
        {
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            originalPos.x += offsetX;
            originalPos.y += offsetY;

            MainCamera.transform.localPosition = originalPos;
        }
    }
}
