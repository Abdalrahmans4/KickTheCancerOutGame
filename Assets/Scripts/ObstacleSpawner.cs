using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public Transform spawnPoint;         
    public float moveDistance ;
    public float moveSpeed ;

    private GameObject currentObstacle;
    private Vector3 startPos;

    void Start()
    {
        SpawnRandomObstacle();    //when level 2 start spawn the new obstacle
    }

    void Update()
    {
        if (currentObstacle != null)   //if the obstacle exist. that checked each frame, the move obstacle caled
        {
            MoveObstacle();
        }
    }

    public void SpawnRandomObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length); // to store the lengh for array pobstaclprefabs, er have two.
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 90f); //to set rotation for obstacle(cigarete, pepsi) to make faced visual.
        currentObstacle = Instantiate(obstaclePrefabs[index], spawnPoint.position, rotation);
        startPos = currentObstacle.transform.position; //save the start pos to move on these oordinations
    }

    void MoveObstacle()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance; //use ping pong to move smoothly
        currentObstacle.transform.position = startPos + new Vector3(offset, 0, 0); 
    }
    //public void ClearObstacle()
    //{
    //    currentObstacle = null;
    //}

}
