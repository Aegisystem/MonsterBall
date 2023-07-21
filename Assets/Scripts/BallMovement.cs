using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    
    private Rigidbody rb;
    private GameObject finish;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        finish = GameObject.FindWithTag("Finish");
        finish.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
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
        }
    }
}
