using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScrollerCam : MonoBehaviour
{
    public GameObject player, grayScreen;
    private const double V = 0.05;
    public float step = (float)V;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovement>().isTimeStopped == false)
        {
            var camPosition = Camera.main.gameObject.transform.position;
            camPosition.x += step;
            Camera.main.gameObject.transform.position = camPosition;
        }
        else
        {
            StartCoroutine(Stop());
        }
    }

    private IEnumerator Stop()
    {
        grayScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        player.GetComponent<PlayerMovement>().isTimeStopped = false;
        grayScreen.SetActive(false);
    }
}
