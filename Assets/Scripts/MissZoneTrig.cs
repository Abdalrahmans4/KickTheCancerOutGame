using UnityEngine;

public class MissZoneTrig : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GManagerScript gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.HandleGoalHit(null); // here forthe colider behind the oal to treat the chance as miss oppurtinities.
        }
    }
}
