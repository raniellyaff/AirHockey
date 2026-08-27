using UnityEngine;

public class audio : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            source.Play();
        }
    }
}