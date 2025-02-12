using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 originalPaddleScale;

    public float speed;

    public PaddleManagerScript paddleManager;

    public Material mat;

    public CameraScript cScript;

    public AudioSource hitSound;
    
    public GameObject ballParticle;
    public BackgroundScript bg;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector3(1f, 0f, 0f);
        speed = 10f;
        mat.color = Color.white;
        originalPaddleScale = paddleManager.leftPaddle.transform.localScale;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);
    }

    public void ResetBall(float dir)
    {
        transform.position = new Vector3(0, 1, 0);
        direction = new Vector3(dir, 0, 0);
        speed = 10f;
        mat.color = Color.white;
        hitSound.pitch = 1f;
        paddleManager.leftPaddle.transform.localScale = originalPaddleScale;
        paddleManager.rightPaddle.transform.localScale = originalPaddleScale;
        paddleManager.ResetPaddles();
        transform.localScale = originalScale;
        ballParticle.transform.localScale = originalScale;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name is "LPaddle" or "RPaddle")
        {
            speed *= 1.2f;
            hitSound.pitch += .1f;
            direction *= -1;
            float max = paddleManager.max;
            
            ContactPoint p = other.GetContact(0);
            
            float contactDiff = p.point.z - other.gameObject.transform.position.z;
            float anglePercent = contactDiff / max;
            float bounceAngle = 45 * anglePercent;
            if (direction.x > 0)
                bounceAngle *= -1;
            Quaternion rotation = Quaternion.Euler(0f, bounceAngle, 0f);
            direction = rotation * direction;
            if (mat.color.g == 0)
            {
                mat.color = new Color(mat.color.r + 3, 0, 0, 1);
            }
            else
            {
                mat.color = new Color(1, mat.color.g - .2f, mat.color.b - .2f, 1);
            }
            cScript.Shake(speed);
            hitSound.PlayOneShot(hitSound.clip);
        }
        else if(other.gameObject.name is "Top Wall" or "Bottom Wall")
        {
            float tempPitch = hitSound.pitch;
            hitSound.pitch -= .3f;
            hitSound.PlayOneShot(hitSound.clip);
            hitSound.pitch = tempPitch;
            direction.z *= -1;
            cScript.Shake(speed/3);
        }
        else if(other.gameObject.name is "PowerUp(Clone)")
        {
            if (other.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                speed *= 1.2f;
                hitSound.pitch += .1f;
                if (mat.color.g == 0)
                {
                    mat.color = new Color(mat.color.r + 3, 0, 0, 1);
                }
                else
                {
                    mat.color = new Color(1, mat.color.g - .2f, mat.color.b - .2f, 1);
                }
                bg.FlashColor(Color.red);
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                Vector3 leftScale = paddleManager.leftPaddle.transform.localScale,
                    rightScale = paddleManager.rightPaddle.transform.localScale;
                paddleManager.leftPaddle.transform.localScale = new Vector3(1, 1, leftScale.z + 2);
                paddleManager.rightPaddle.transform.localScale = new Vector3(1, 1, rightScale.z + 2);
                BoxCollider c = paddleManager.leftPaddle.GetComponent<BoxCollider>();
                paddleManager.min -= 1; paddleManager.max += 1;
                bg.FlashColor(Color.green);
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.magenta)
            {
                transform.localScale *= .7f;
                ballParticle.transform.localScale *= .7f;
                bg.FlashColor(Color.magenta);
            }
            Destroy(other.gameObject);
        }
    }
}
