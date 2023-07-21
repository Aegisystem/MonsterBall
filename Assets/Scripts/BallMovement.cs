using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private GameObject TPGameObject;
    private GameObject Player;
    private BallMovement ballMovement;
    [SerializeField] private float speed = 2f;

    
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameManager.Instance.time <= 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            playerMovement();
        }
    }

    private void playerMovement()
    {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");
        
        Vector3 moveBall = new Vector3(Hmove, 0.0f, Vmove);
        
        rb.AddForce(moveBall * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            TPGameObject = GameObject.FindWithTag("TP");
            Player = GameObject.FindWithTag("Player");
            Player.transform.position = TPGameObject.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
