using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Berührt der Player einen Enemy, wird der Player
        // an den Ursprungsort zurückversetzt
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerMovement.instance.RespawnPlayer();
        }
    }
}
