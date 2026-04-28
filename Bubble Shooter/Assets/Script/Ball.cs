using UnityEngine;

public class Ball : MonoBehaviour
{
    public string colorName;

    public void SetColor(Color color, string name)
    {
        GetComponent<SpriteRenderer>().color = color;
        colorName = name;
    }
}