using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private Rigidbody2D rb;
    private bool isDead;
    private int score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        HideGameOverUI();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        // Nếu đã thua: bấm R hoặc Space để reset
        if (isDead)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                RestartGame();
            }

            return;
        }

        // Nếu chưa thua: bấm Space để bay
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Fly();
        }
    }

    private void Fly()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
            return;

        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead)
            return;

        if (other.CompareTag("ScoreZone"))
        {
            score++;
            UpdateScoreUI();
            Debug.Log("Score: " + score);
        }
    }

    private void GameOver()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        ShowGameOverUI();
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    private void ShowGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Score: " + score;
        }
    }

    private void HideGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}