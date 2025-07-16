using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PaddleScript : MonoBehaviour
{
    Vector3 curPos;
    Vector3 MousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curPos = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 10f);
        MousePos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = new Vector3(MousePos.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.27f, 3.27f), transform.position.y, transform.position.z);
    }
}
