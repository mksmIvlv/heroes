using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPassed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            var canvasLevelPassed = GameObject.Find("CanvasLevelPassed").GetComponent<CanvasLevelPassed>();

            canvasLevelPassed.Active();
        }
    }
}
