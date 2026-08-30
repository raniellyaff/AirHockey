using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 20f;

    [Header("Limites do Campo")]
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = -3.8f; // Fundo da mesa (ou 0.1f se for o player 2)
    [SerializeField] private float maxY = 0f;    // Linha do meio (ou 3.8f se for o player 2)

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

        // Limita a posição para que o jogador não ultrapasse a área permitida
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        Vector2 direction = mousePos - transform.position;

        rb2d.linearVelocity = direction * speed;
    }
}