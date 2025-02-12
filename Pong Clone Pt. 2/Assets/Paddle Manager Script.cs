using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PaddleManagerScript : MonoBehaviour
{
    public GameObject leftPaddle, rightPaddle;

    private float lMove, rMove;

    private float speed = 20.0f;

    public float min, max;
    private float originalMin, originalMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider c = leftPaddle.GetComponent<BoxCollider>();
        min = c.bounds.min.z; max = c.bounds.max.z;
        originalMin = min;
        originalMax = max;
        Debug.Log($"Min: {min} Max: {max}");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lPos = leftPaddle.transform.position;
        lPos = new Vector3(lPos.x, lPos.y, lPos.z + Time.deltaTime * lMove * speed);
        lPos.z = Math.Clamp(lPos.z, -11f-min, 11f-max);
        leftPaddle.transform.position = lPos;

        Vector3 rPos = rightPaddle.transform.position;
        rPos = new Vector3(rPos.x, rPos.y, rPos.z + Time.deltaTime * rMove * speed);
        rPos.z = Math.Clamp(rPos.z, -11f-min, 11f-max);
        rightPaddle.transform.position = rPos;
    }

    public void ResetPaddles()
    {
        min = originalMin;
        max = originalMax;
    }
    public void OnMoveLeftPaddle(InputAction.CallbackContext context)
    {
        lMove = context.ReadValue<float>();
    }
    
    public void OnMoveRightPaddle(InputAction.CallbackContext context)
    {
        rMove = context.ReadValue<float>();
    }
}
