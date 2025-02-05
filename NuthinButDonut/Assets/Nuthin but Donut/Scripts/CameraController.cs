using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;

    public Transform ballTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.LookAt(ballTransform.position);
    }
}
