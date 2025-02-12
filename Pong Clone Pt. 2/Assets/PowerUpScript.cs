using System;
using System.Timers;
using UnityEngine;
using Random = System.Random;

public class PowerUpScript : MonoBehaviour
{
    public PowerUpManagerScript manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0f, 60f * Time.deltaTime, 0f);
        Vector3 currentRotate = transform.rotation.eulerAngles;
        currentRotate.y += 60f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(currentRotate);
    }
}
