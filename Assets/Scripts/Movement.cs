using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem vfxMain;
    [SerializeField] private ParticleSystem vfxRight;
    [SerializeField] private ParticleSystem vfxLeft;

    [Header("Movement Properties")]
      private Rigidbody rb;
      private AudioSource audioSource;
    [SerializeField] private AudioClip sfxThrust;

    [Header("Power Values")]
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;

       private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
    }

    private void Update()
    {
         ProcessRotation();

    }

    private void ProcessRotation()
    {
         float rotationvalue = rotation.ReadValue<float>();
         if(rotationvalue != 0)
         {
            rb.freezeRotation = true;
            transform.Rotate(rotationvalue * Vector3.forward * rotationPower * Time.deltaTime);
            rb.freezeRotation = false;
         }
         else
         {
            vfxRight.Stop();
            vfxLeft.Stop();
         }

         if(rotationvalue == 1)
         {
            vfxRight.Play();
         }
         if(rotationvalue == -1)
         {
            vfxLeft.Play();
         }
         
         
    }

    private void ProcessThrust()
    {
        if(thrust.IsPressed())
        {
            //Debug.Log("Space is  Pressed");
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(sfxThrust);
            }
            if(!vfxMain.isPlaying)
            {
                vfxMain.Play();
            }
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
            vfxMain.Stop();
        }
    }

    
}