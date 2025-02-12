using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private float t;

    private bool colored;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colored = false;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (colored)
        { 
            t += Time.deltaTime;
            if (t >= 0.5)
            {
                GetComponent<Renderer>().material.color = Color.black;
                colored = false;
                t = 0;
            }
        } 
    }

    public void FlashColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        colored = true;
    }
}
