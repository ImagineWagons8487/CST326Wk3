using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
public class PowerUpManagerScript : MonoBehaviour
{
    public GameObject powerUp;
    public Material mat;
    private Random rnd = new Random();
    private float interval;
    private float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = 0;
        interval = rnd.Next(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        t += Time.deltaTime;
        if (t >= interval)
        {
            Spawn();
            interval = rnd.Next(4, 10);
            t = 0;
        }
    }

    public void Spawn()
    {
        int type = rnd.Next(6);
        float randX = (float)(rnd.Next(-8, 8) + rnd.NextDouble()), 
            randZ = (float)(rnd.Next(-10, 10) + rnd.NextDouble());
        Vector3 pos = new Vector3(randX, 1, randZ);
        GameObject block = Instantiate(powerUp, transform);
        block.transform.position = pos;
        if (type <= 1)
        {
            block.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (type <= 4)
        {
            block.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (type == 5)
        {
            block.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
