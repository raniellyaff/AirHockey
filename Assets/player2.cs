using UnityEngine;

public class player2 : MonoBehaviour
{
    public float speed = 15f;

    [Header("Configurações da IA")]
    [SerializeField] private Transform puck;            // Arraste o puck_0 aqui
    [SerializeField] private float detectionRadius = 4f; // Raio em que a IA começa a perseguir a bola
    [SerializeField] private Vector2 defenseHomePos = new Vector2(0f, 2f); // Posição onde ela fica guardando

    [Header("Limites do Campo")]
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = 0.1f;       // Linha do meio
    [SerializeField] private float maxY = 3.8f;       // Fundo da mesa (topo)

    private Rigidbody2D rb2d;
    private Vector2 targetPos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        if (puck == null)
        {
            GameObject foundPuck = GameObject.FindWithTag("Puck");
            if (foundPuck != null) puck = foundPuck.transform;
            else if (GameObject.Find("puck_0") != null) puck = GameObject.Find("puck_0").transform;
        }
    }

    void FixedUpdate()
    {
        if (puck != null)
        {
            float targetX;
            float targetY;

            // Calcula a distância entre a IA e o disco
            float distanceToPuck = Vector2.Distance(transform.position, puck.position);

            // Se o disco estiver dentro do raio de detecção E na metade de cima da mesa
            if (distanceToPuck <= detectionRadius && puck.position.y > 0f)
            {
                // Persegue o disco, posicionando-se levemente atrás dele para atacar
                targetX = puck.position.x;
                targetY = puck.position.y + 0.4f;
            }
            else
            {
                // Se estiver fora do raio ou a bola for para o campo rival, volta para a defesa
                targetX = defenseHomePos.x;
                targetY = defenseHomePos.y;
            }

            // Aplica os limites estritos da metade do campo da IA
            targetX = Mathf.Clamp(targetX, minX, maxX);
            targetY = Mathf.Clamp(targetY, minY, maxY);

            targetPos = new Vector2(targetX, targetY);

            // Move o batedor em direção ao alvo calculado
            Vector2 direction = targetPos - (Vector2)transform.position;
            rb2d.linearVelocity = direction * speed;
        }
    }
}