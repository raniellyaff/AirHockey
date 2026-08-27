using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody2D rb2d;
    private Camera cam;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = mousePos - transform.position;

        rb2d.linearVelocity = direction * speed;
    }
}