using UnityEngine;

public class Dropper : MonoBehaviour
{
    public int timer = 3;
    private  Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        // define a variable that --> time value
        // if(Time.time > time.value) --> enable garvity        
        if(Time.time > timer)
        {
            rb.useGravity = true;
        }
    }
}
