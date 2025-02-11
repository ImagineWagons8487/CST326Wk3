using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraScript : MonoBehaviour
{
    private Vector3 originalPos;
    public float shakeMagnitude = .5f;
    private float originalMagnitude;
    public float shakeFrequency;
    private Vector3 maxShake;
    private Vector3 maxAngularShake = Vector3.one;

    private float recoverySpeed = 3f;

    private int traumaExp = 2;
    private float trauma = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = this.gameObject.transform.position;
        maxShake = Vector3.one * shakeMagnitude;
        originalMagnitude = shakeMagnitude;
    }

    // Update is called once per frame
    void Update()
    {
        float shake = Mathf.Pow(trauma, traumaExp);
        transform.localPosition = new Vector3(
            maxShake.x * Mathf.PerlinNoise(0, Time.time * shakeFrequency) * 2 - 1, 
            maxShake.y * Mathf.PerlinNoise(1, Time.time * shakeFrequency) * 2 - 1, 
            maxShake.z * Mathf.PerlinNoise(2, Time.time * shakeFrequency) * 2 - 1
            ) * shake;
        transform.localRotation = Quaternion.Euler(new Vector3(
            maxAngularShake.x * Mathf.PerlinNoise(3, Time.time * shakeFrequency) * 2 - 1,
            maxAngularShake.y * Mathf.PerlinNoise(4, Time.time * shakeFrequency) * 2 - 1,
            maxAngularShake.z * Mathf.PerlinNoise(5, Time.time * shakeFrequency) * 2 - 1
        ) * shake);
        trauma = Mathf.Clamp01(trauma - recoverySpeed * Time.deltaTime);
    }

    public void Shake(float speed)
    {
        trauma = 1;
        shakeMagnitude += speed / 200;
        maxShake = Vector3.one * shakeMagnitude;
    }

    public void resetShakeMag()
    {
        shakeMagnitude = originalMagnitude;
        maxShake = Vector3.one * shakeMagnitude;
    }
}
