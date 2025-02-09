using UnityEngine;

public class DivingController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameOver) return; // Add this line

        ScoreManager.score++;
        Debug.Log("Score: " + ScoreManager.score);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            // Game over
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true; // Add this line

        // Freeze the bird's motion
        rb.linearVelocity = Vector2.zero;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}