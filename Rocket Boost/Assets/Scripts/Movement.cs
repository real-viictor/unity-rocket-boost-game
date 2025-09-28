using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;

    private Rigidbody rb;

    [SerializeField] float thrustStrength = 800f;
    [SerializeField] float rotationStrength = 50f;

    private void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Thrust();
        Rotate();
    }

    void Thrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    void Rotate()
    {
        if (rotate.IsPressed())
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, rotate.ReadValue<float>() * rotationStrength * Time.fixedDeltaTime);
            rb.freezeRotation = false;
        }
        
    }
}
