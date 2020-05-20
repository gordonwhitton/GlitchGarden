using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake() //very first thing that happens in Unity execution order
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() //last thing that happens in Unity execution order
    {
        var levelController = FindObjectOfType<LevelController>();

        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(! currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(! currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();

        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
