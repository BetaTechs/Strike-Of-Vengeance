using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void takeDamage(float damage)
    {
        if (damage<=0)
        {
            throw new UnityException("Damage Cannot be 0 Or Negative");
        }

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(this.transform.name + " Is Dying");
        StartCoroutine("pleaseDie");
        
    }

    IEnumerator pleaseDie()
    {
        Debug.Log("Inside IEnumerator");
        animator.SetTrigger("Died");

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
