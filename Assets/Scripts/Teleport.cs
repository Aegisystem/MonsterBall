using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject PortalFin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(
            PortalFin.transform.position.x,
            PortalFin.transform.position.y+1.5f,
            PortalFin.transform.position.z
            );
        other.gameObject.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
