using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    [SerializeField] Canvas goalReachedCanvas;

    private void Start()
    {
        goalReachedCanvas.enabled = false;
    }

    public void HandleGoal()
    {
        goalReachedCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
