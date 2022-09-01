using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameStateManager.totalScore -= 10;
        Debug.Log(GameStateManager.totalScore);
        Destroy(gameObject);
    }
}
