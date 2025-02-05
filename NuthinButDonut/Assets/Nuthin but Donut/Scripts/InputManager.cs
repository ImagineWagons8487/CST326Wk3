using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Hand hand;
    public Trampoline trampoline;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hand.Release();

        if (Input.GetKeyDown(KeyCode.R))
            hand.Reset();

        if (Input.GetAxis("Trampoline") > 0)
            trampoline.transform.Translate(Vector3.forward * (Time.deltaTime * 15.0f), Space.World);
        else if(Input.GetAxis("Trampoline") < 0)
            trampoline.transform.Translate(Vector3.back * (Time.deltaTime * 15.0f), Space.World);
    }
}
