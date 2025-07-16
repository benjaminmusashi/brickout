using UnityEngine;

public class BrickSkript : MonoBehaviour
{
    public BrickSpawnerScript bSS;
    public LogicScript lS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lS = GameObject.Find("LogicManager").GetComponent<LogicScript>();
        bSS = GameObject.Find("BrickSpawner").GetComponent<BrickSpawnerScript>();
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            lS.addScore(); // Increment the score when a brick is hit
            bSS.removeBrick(gameObject);
            Invoke(nameof(DestroyBrick), 0.05f); // Delay the destruction to allow for collision effects
        }
    }

    private void DestroyBrick()
    {
        Destroy(gameObject);
    }
    
    
}
