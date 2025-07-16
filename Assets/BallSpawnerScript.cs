using UnityEditor;
using UnityEngine;

public class BallSpawnerScript : MonoBehaviour
{
    public GameObject ballPrefab; // Reference to the ball prefab
    public GameObject curBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (curBall.transform.position.y < -6)
        {
            destruction();
        }
    }

    void Spawn()
    {
        curBall = Instantiate(ballPrefab, transform.position, transform.rotation);
    }

    public void destruction()
    {
        Destroy(curBall);
        Spawn();
    }
}
