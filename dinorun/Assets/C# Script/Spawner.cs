using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 2f);
    }

    void Spawn()
    {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}