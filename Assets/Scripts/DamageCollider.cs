using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(enemy.gameObject); //note, that you need to get the game object in order to have something to destroy
    }
}
