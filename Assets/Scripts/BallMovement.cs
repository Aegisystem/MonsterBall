using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private GameObject TPGameObject;
    private GameObject Player;
    private BallMovement ballMovement;
    [SerializeField] private float speed = 2f;
    private bool isSlowedDown = false;
    private float originalSpeed;
    private float slowDuration = 4f;
    private float slowTimer = 0f;

    private Rigidbody rb;
    private GameObject finish;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        finish = GameObject.FindWithTag("Finish");
        finish.SetActive(false);
        originalSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.time <= 0 || GameManager.Instance.finish)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            if (isSlowedDown)
            {
                slowTimer -= Time.deltaTime;
                if (slowTimer <= 0f)
                {
                    isSlowedDown = false;
                    speed = originalSpeed;
                }
            }
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
        if (other.CompareTag("Meta"))
        {
            finish.SetActive(true);
            GameManager.Instance.finish = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            TPGameObject = GameObject.FindWithTag("TP");
            Player = GameObject.FindWithTag("Player");
            Player.transform.position = TPGameObject.transform.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Slime"))
        {
            
            if (!isSlowedDown)
            {
                Debug.Log("Slime TOCO");
                isSlowedDown = true;
                slowTimer = slowDuration;
                speed /= 2f; 
                
            }
        }
    }
}
