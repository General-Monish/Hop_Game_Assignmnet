using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] BallMovement ballMovement; // Reference to the BallMovement script
    [SerializeField] Slider slider; // Reference to the UI Slider for horizontal movement

    void Update()
    {
        MoveHorizontally();
    }

    void MoveHorizontally()
    {
        float horizontalMove = slider.value; // Get horizontal input from the UI Slider

        // Apply horizontal movement to the ball
        Vector3 movement = new Vector3(horizontalMove, 0, 0);
        ballMovement.transform.Translate(movement * Time.deltaTime);
    }
}
