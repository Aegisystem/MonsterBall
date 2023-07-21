using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float speed = 2f;
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float distanceToPlayer;

    // La fuerza de empuje que aplicaremos cuando el enemigo y el jugador colisionen.
    [SerializeField]
    private float pushForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        direction = Vector3.zero;
        distance = 0f;
        distanceToPlayer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.time <= 0 || GameManager.Instance.finish)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 10f)
            {
                direction = player.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    // Método para manejar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el objeto con el que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculamos la dirección entre el enemigo y el jugador
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.Normalize();

            // Aplicamos una fuerza en dirección contraria a ambos objetos para que se empujen
            rb.AddForce(-pushDirection * pushForce, ForceMode.Impulse);
            collision.rigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
