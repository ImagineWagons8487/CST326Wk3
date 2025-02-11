using System;
using UnityEngine;
using Random = System.Random;

public class PowerUpScript : MonoBehaviour
{
    public Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Random rnd = new Random();
        int type = rnd.Next(2);
        if (type == 0)
        {
            mat.color = Color.red;
            float randX = (float)(rnd.Next(-8, 8) + rnd.NextDouble()), 
                randZ = (float)(rnd.Next(-15,15) + rnd.NextDouble());
            Vector3 pos = new Vector3(randX, 1, randZ);
            Instantiate(gameObject, pos, Quaternion.identity);
        }
        else if (type == 1)
        {
            mat.color = Color.green;
            float randX = (float)(rnd.Next(-8, 8) + rnd.NextDouble()), 
                randZ = (float)(rnd.Next(-15,15) + rnd.NextDouble());
            Vector3 pos = new Vector3(randX, 1, randZ);
            Instantiate(gameObject, pos, Quaternion.identity);
        }
    }
}
