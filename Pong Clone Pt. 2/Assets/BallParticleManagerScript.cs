using Unity.VisualScripting;
using UnityEngine;

public class BallParticleManagerScript : MonoBehaviour
{
    private float timePassed;
    public GameObject ballParticle;

    public BallScript ballScript;

    public GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timePassed = 0f;
        ballParticle.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= .1f/ballScript.speed)
        {
            GameObject part = Instantiate(ballParticle, transform);
            part.transform.position = ball.transform.position;
            timePassed = 0;
        }
    }
}
