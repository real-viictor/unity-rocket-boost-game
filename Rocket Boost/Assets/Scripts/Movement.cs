using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;

    private Rigidbody rb;

    private void OnEnable()
    {
        thrust.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
    }

    void Thrust()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Tested");
        }
    }
}
