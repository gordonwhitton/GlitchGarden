using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject gun;

    AttackerSpawner myLaneSpawner;

    Animator animator;

    public void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(IsAttackerInLane())
        {
            Debug.Log("shoot attacker");
            animator.SetBool("isAttacking", true);
        }
        else
        {
            Debug.Log("sit and wait");
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            //is defender on the same y coordinates
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }

}
