using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Healthbar : MonoBehaviour {

    public Health healthScript;

    [HideInInspector]
    public GameObject cameraToLookAt;

    public Image foreGround;



    void Update()
    {
        foreGround.fillAmount = healthScript.currentHealth / healthScript.maxHealth;
        if (!cameraToLookAt)
        {
            cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera");
            return;
        }
        transform.LookAt(transform.position + cameraToLookAt.transform.rotation * Vector3.back, cameraToLookAt.transform.rotation * Vector3.up);
    }
}
