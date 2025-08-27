using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour
{
    private GManagerScript gameManager; // is a refrence  for gmanager
    private ObstacleSpawner obstacleSpawner;
    private bool alreadyHit = false; //ensure if the ball touches to obstacle.

    void Start()
    {
        gameManager = FindFirstObjectByType<GManagerScript>();   //at first to find the gmager and obstacle spawner
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (alreadyHit) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            alreadyHit = true;

            if (gameManager != null)
                gameManager.HandleGoalHit(null); // lose heart

            if (obstacleSpawner != null)
                StartCoroutine(DestroyAndRespawn(collision.gameObject));

            Destroy(gameObject); // to destroy ball.
        }
    }

    IEnumerator DestroyAndRespawn(GameObject obstacle)  // wait for seconds before removing the obstacle.
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(obstacle);
        obstacleSpawner.SpawnRandomObstacle();
    }
}
