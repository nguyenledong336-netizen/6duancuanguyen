using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Ball other = col.gameObject.GetComponent<Ball>();

        if (other != null)
        {
            Ball me = GetComponent<Ball>();

            if (me.colorName == other.colorName)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);

                ScoreManager.instance.AddScore(10);
            }
        }
    }
}