using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction playerControls;
    [SerializeField] private InputAction rotationControls;
    [SerializeField] GameObject playerCamera;
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody rb;

    private Vector2 inputDir;
    private float jumpInput;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerControls.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        inputDir = playerControls.ReadValue<Vector2>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(inputDir.x * moveSpeed * Time.deltaTime, 0f, inputDir.y * moveSpeed * Time.deltaTime);
        transform.Translate(moveDir);
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerCamera.transform.eulerAngles.y, transform.rotation.z);
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
