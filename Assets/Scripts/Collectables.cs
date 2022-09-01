using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private Material collectableMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameStateManager.totalScore += 10;
            Debug.Log(GameStateManager.totalScore);
            Destroy(gameObject);
        }
    }
}
