using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlatformBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>()==true)
        {
            GameObject.FindObjectOfType<GoalHandler>().HandleGoal();
        }
    }
}
