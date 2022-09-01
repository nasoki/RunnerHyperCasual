using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMove : MonoBehaviour
{
    public bool levelEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        levelEnd = true;
        
        other.gameObject.transform.position = new Vector3 (0, 0, GetComponent<Transform>().position.z);

        //decide how long player will walk associated to their score
        GameObject.FindGameObjectWithTag("EndPoint").transform.position = new(0f, 0f, transform.position.z + GameStateManager.totalScore * 0.2f);
    }

    private void Update()
    {
        if(levelEnd)
        {
            
        }
        Debug.Log(GameStateManager.totalScore * 0.1f);
    }
}
