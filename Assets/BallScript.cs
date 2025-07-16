using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    private bool clicked = false;
    public Rigidbody2D rb;
    public float speed = 5f;
    Vector3 curPos;
    Vector3 MousePos;
    private GameObject lastHitObject;
    public AudioSource hitSound;

    void Start()
    {
        
    }

    void Update()
    {
        if (!clicked)
        {
            follow();
        }
        else if (speed == 5)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.right * speed;
            }
        }
    }

    void follow()
    {
        curPos = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 10f);
        MousePos = Camera.main.ScreenToWorldPoint(curPos);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(75f, 105f));
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            clicked = true;
        }
        else
        {
            transform.position = new Vector3(MousePos.x, transform.position.y, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.27f, 3.27f), transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject == lastHitObject)
        {
            return;
        }
        lastHitObject = hitObject;
        speed += 0.05f;
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (transform.position.x < collision.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) * 22.5f + 90);
                rb.linearVelocity = transform.right * speed; // Adjust speed if necessary
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) * 22.5f + 67.5f);
                rb.linearVelocity = transform.right * speed; // Adjust speed if necessary
            }
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 newDirection = Vector2.Reflect(rb.linearVelocity.normalized, normal);
            if (Mathf.Abs(newDirection.x) < 0.1f)
            {
                newDirection.x = newDirection.x > 0 ? 0.1f : -0.1f; // Ensure minimum speed in x direction
            }
            if (Mathf.Abs(newDirection.y) < 0.1f)
            {
                newDirection.y = newDirection.y > 0 ? 0.1f : -0.1f; // Ensure minimum speed in y direction
            }
            rb.linearVelocity = newDirection * speed; // Adjust speed if necessary
        }
        hitSound.Play();
    }
}
