using UnityEngine;

public class ShootBallScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    public Transform arrowPoint;             //this for theplace f spawn.
    private GameObject currentBall;
    private GameObject currentArrow;   // to controll and destroy 

    public float rotationSpeed ;
    public float shootingForce ;
    private bool hasShot = false;  // to prevent multiple shoots.
    public Animator playerAnimator;
    private Vector3 initialPlayerPosition;  //handles player animation 
    private Quaternion initialPlayerRotation;


    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            initialPlayerPosition = player.transform.position;  //to find the game obect using player tag.
            initialPlayerRotation = player.transform.rotation;
        }
        SpawnBallAndArrow();
    }

    void Update()
    {
        if (!hasShot && currentArrow != null)  //if the player doesn't shoot.
        {
            
            float input = Input.GetAxis("Horizontal");
            currentArrow.transform.Rotate(0, input * rotationSpeed * Time.deltaTime, 0);   

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootBall();
            }
        }
    }

    void SpawnBallAndArrow()
    {
       
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);//the rotation may not important for ball but shoulf assign for Intiate fnction

       
        //Vector3 arrowPosition = spawnPoint.position + new Vector3(0, 0.3f, 0.6f);             // here to spawn the pont and teh arrow according to the places that I dtermine. +.3 on Y to be above ground, .6 on fromt of ball

        currentArrow = Instantiate(arrowPrefab, arrowPoint.position, Quaternion.Euler(0, 90, 0));//90 rotate the arrow forward.
    }

    void ShootBall()
    {
        if (currentBall != null && currentArrow != null) //ball and arrrow exist
        {
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Shoot");
            }

            hasShot = true;

            
            Invoke("ApplyBallForce", 0.5f); //to be smooth with animation

          
            Destroy(currentBall, 1.4f);
            Invoke("NextTurn", 1.5f);
        }
    }

    void ApplyBallForce()
    {
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();  // get the ball regidbody.

        Vector3 shootDirection = currentArrow.transform.right.normalized; //uses the arrow to calculate the direction, normalised used for where arrow's right sied is pointing.
        shootDirection.y += 0.1f; //upward for more realistic

        rb.AddForce(shootDirection * shootingForce);
        Destroy(currentArrow);
    }


    void NextTurn()
    {

        hasShot = false;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = initialPlayerPosition;
            player.transform.rotation = initialPlayerRotation;
        }
        SpawnBallAndArrow();
    }
}
