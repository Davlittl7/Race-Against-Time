using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamSwitch : MonoBehaviour
{
    public GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UpTrigger")
        {
            //DynamicCam.camSwitch = 2;
        }
    }
}
