using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;

    private Rigidbody rb;
    private Vector2 inputDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerControls.Enable();
    }
    
    void Update()
    {
        inputDir = playerControls.ReadValue<Vector2>();
        Debug.Log(inputDir.x);
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(inputDir.x * 1f * Time.deltaTime, 0f, inputDir.y * 1f * Time.deltaTime);
        transform.Translate(moveDir);
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
