using UnityEngine;
using System.Collections;

public class GoalCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Bei Kollision mit Goal ist das Spiel fertig und
        // kann neu gestartet werden
        if (collision.gameObject.tag == "Goal")
        {
            GameControl.instance.gameFinished = true;
        }
    }
}
