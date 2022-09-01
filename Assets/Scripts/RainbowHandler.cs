using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowHandler : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            meshRenderer.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<MeshRenderer>().enabled = true;
    }
}
