using UnityEngine;

public class GoalTrig : MonoBehaviour
{
    public GManagerScript gameManager; // to use th handle hit goal function on GManager Script
    public bool isRightSide;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // here I tagged the soccer Ball to Ball to handle it in code.
        {
            gameManager.HandleGoalHit(isRightSide);
        }
    }
}
