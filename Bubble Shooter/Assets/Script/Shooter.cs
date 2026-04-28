using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePoint;
    public float speed = 10f;

    Color[] colors = { Color.red, Color.green, Color.blue };
    string[] names = { "red", "green", "blue" };

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 🔴 CHECK NULL TRƯỚC
        if (ballPrefab == null)
        {
            Debug.LogError("❌ ballPrefab chưa gán!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("❌ firePoint chưa gán!");
            return;
        }

        // 🟢 TẠO BÓNG
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);

        // 🟡 RANDOM MÀU
        int i = Random.Range(0, colors.Length);

        // 🔴 CHECK BALL SCRIPT
        Ball ballScript = ball.GetComponent<Ball>();
        if (ballScript == null)
        {
            Debug.LogError("❌ Prefab Ball chưa gắn script Ball!");
            return;
        }

        ballScript.SetColor(colors[i], names[i]);

        // 🔴 CHECK RIGIDBODY
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("❌ Prefab Ball chưa có Rigidbody2D!");
            return;
        }

        // 🟢 BẮN
        rb.linearVelocity = firePoint.right * speed;
    }
}