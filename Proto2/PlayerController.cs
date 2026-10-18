using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private float xRange = 15.0f;
    
    public InputAction moveAction;
    public Vector2 moveInput;

    public GameObject projectilePrefab;

    public InputAction fireAction;

    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void Update()
    {
        // Bound player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Read input system
        moveInput = moveAction.ReadValue<Vector2>();

        // Move player
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);

        // Check fireAction
        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
