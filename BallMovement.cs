using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    bool isGrounded;
   public bool gameOver=false;
    public GameObject gameoverPanel;

    // Reference to the slider for horizontal movement
    [SerializeField] Slider horizontalSlider;

    // Camera reference to calculate screen bounds
    Camera mainCamera;
    float minX, maxX;

    AudioSource audioSource;
    [SerializeField] AudioClip groundCollisionSound;

    void Start()
    {
        Time.timeScale = 1;
        gameoverPanel.SetActive(false);
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();

        // Calculate screen bounds in world coordinates
        Vector3 screenMin = mainCamera.ViewportToWorldPoint(new Vector3(-10, -10, mainCamera.nearClipPlane));
        Vector3 screenMax = mainCamera.ViewportToWorldPoint(new Vector3(10, 10, mainCamera.nearClipPlane));

        minX = screenMin.x;
        maxX = screenMax.x;
    }

    void Update()
    {
        MoveHorizontally();
        CheckJump();
    }

    void MoveHorizontally()
    {
        // Get horizontal input from the slider
        float horizontalInput = horizontalSlider.value;

        // Calculate movement based on input and current velocity
        Vector3 movement = new Vector3(horizontalInput * horizontalSpeed, rb.velocity.y, 0);
        rb.velocity = movement;

        // Clamp position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void CheckJump()
    {
        if (isGrounded)
        {

            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // After jumping, no longer grounded
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set grounded true on collision with ground
                               // Play collision sound
            if (audioSource != null && groundCollisionSound != null)
            {
                audioSource.PlayOneShot(groundCollisionSound);
            }
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
            Debug.Log("groundhit");
            gameOver = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Reset grounded on leaving ground
        }
    }
}
