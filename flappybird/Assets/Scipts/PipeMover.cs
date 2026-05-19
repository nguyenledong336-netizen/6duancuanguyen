using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private void Update()
    {
        // Chưa start game -> không di chuyển
        if (Time.timeScale == 0f)
            return;

        transform.position +=
            Vector3.left * moveSpeed * Time.deltaTime;
    }
}