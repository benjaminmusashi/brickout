using UnityEngine;

public class BrickSpawnerScript : MonoBehaviour
{
    public GameObject brickPrefab; // Prefab for the brick to spawn
    private GameObject[] bricks; // Array to hold the spawned bricks
    public BallSpawnerScript bSS;
    public int limit = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bSS = GameObject.Find("BallSpawner").GetComponent<BallSpawnerScript>();
        bricks = new GameObject[100];
        SpawnBricks();
    }

    // Replace the Update method with this corrected version
    void Update()
    {
        if (bricks.Length == 0)
        {
            if (limit < 100)
            { 
                limit += 10; 
            }
            bricks = new GameObject[100]; // Reset the array size to 100
            bSS.destruction();
            SpawnBricks();
        }
    }

    // Also, initialize the bricks array in SpawnBricks:
    void SpawnBricks()
    {
        
        bricks[0] = Instantiate(brickPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        float yPos = transform.position.y;
        float xOffset = 0.825f;
        for (int i = 1; i < limit; i++)
        {
            bricks[i] = Instantiate(brickPrefab, new Vector3(transform.position.x + xOffset, yPos, transform.position.z), Quaternion.identity);
            if (bricks[i].transform.position.x >= 3.6f)
            {
                yPos = bricks[i].transform.position.y - 0.4f;
                xOffset = 0;
            }
            else
            {
                xOffset += 0.825f;
            }
        }
    }

    public void removeBrick(GameObject brick)
    {
        int nullCount = 0;
        for (int i = 0; i < limit; i++)
        {
            if (bricks[i] == brick)
            {
                bricks[i] = null;
                nullCount++;
            }
            else if (bricks[i] == null)
            {
                nullCount++;
            }
        }
        if (nullCount == limit)
        {
            bricks = new GameObject[0];
        }
    }
}
