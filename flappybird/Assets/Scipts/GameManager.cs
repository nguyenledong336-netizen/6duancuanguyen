using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private Rigidbody2D birdRb;

    private bool gameStarted;

    private void Start()
    {
        // Dừng game
        Time.timeScale = 0f;

        // Chim đứng yên
        birdRb.simulated = false;

        // Hiện menu START
        startPanel.SetActive(true);

        gameStarted = false;
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        // Nhấn SPACE để bắt đầu
        if (!gameStarted &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;

        // Chạy game
        Time.timeScale = 1f;

        // Chim hoạt động
        birdRb.simulated = true;

        // Ẩn menu
        startPanel.SetActive(false);
    }
}