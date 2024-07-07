using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        // Move the tile towards the ball
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy the tile when it goes out of bounds
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
