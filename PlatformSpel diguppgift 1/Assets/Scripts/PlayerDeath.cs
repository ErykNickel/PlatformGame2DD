using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Collider2D body;
    Collider2D feet;

    private void Start()
    {
        body = GetComponent<PolygonCollider2D>();
        feet = GetComponent<BoxCollider2D>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (feet.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(other.gameObject);
        }

        else if (body.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        if (feet.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        if (body.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
