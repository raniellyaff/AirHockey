using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        GoBall();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Se bater no Player, calcula a física da rebatida
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1f);
    }

    void GoBall()
    {
        float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        rb2d.linearVelocity = new Vector2(0f, randomDirection * 10f);
    }
}