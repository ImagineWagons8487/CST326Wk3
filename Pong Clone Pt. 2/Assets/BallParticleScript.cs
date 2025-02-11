using UnityEngine;

public class BallParticleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smallerVector = Vector3.one * (4f * Time.deltaTime);
        transform.localScale -= smallerVector;
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
