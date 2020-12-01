using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutscene : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject player;

    private float cameraOffset = 16f;
    private int cameraZoomOut = 7;
    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggered && collision.gameObject.tag == "Player") {
            StartCoroutine("Cutscene");
            triggered = true;
        }
    }

    private IEnumerator Cutscene() {
        player.GetComponent<BasicMovement>().enabled = false;
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
        //return to original with lifted camera
        while(cam.orthographicSize > 5 + 0.1 || MainCamera.transform.localPosition.y > cameraOffset + 0.1f) {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, Time.deltaTime * 2);
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, EndPosition, Time.deltaTime * 3);
            yield return null;
        }
        cam.orthographicSize = 5;
        MainCamera.transform.localPosition = new Vector3(0, 17, -10);
        Destroy(gameObject);
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
