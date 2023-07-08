using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public int health, attackPower;
    public float movementSpeed;

    public Animator animator;
    public float attackSpeed;
    Coroutine attackOrder;
    EnemyBasic detectedEnemy;


    private void Update()
    {
        if ( !detectedEnemy)
        {
            Move();
        }

    }
            // TODO: Implement Attack Animation
    IEnumerator Attack()
    {
        //play attack animation 
       //animator.Play("Attack");

        //attack in interval equal to attack speed
        yield return new WaitForSeconds(attackSpeed);

        //attack again
        attackOrder = StartCoroutine(Attack());

        
    }
    


    //Method to Advance towards the Castle
    void Move()
    {
        transform.Translate(transform.right * movementSpeed * Time.deltaTime);

    }
    public void InflictDamage()
    {
        bool enemyDied = detectedEnemy.LoseHealth(attackPower);

        if (enemyDied)
        {
            detectedEnemy = null;
            StopCoroutine(attackOrder);
        }
    }

    //Lose Health
    public virtual bool LoseHealth(int amount)
    {
        //health = health - amount
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    //Die
    protected virtual void Die()
    {
        Debug.Log("Minion is dead");
        Destroy(gameObject);
    }

    IEnumerator BlinkRed()
    {
        //Change sprite to flash blue when taking damage
        GetComponent<SpriteRenderer>().color = Color.red;

        //wait for really small amount of time 
        yield return new WaitForSeconds(.2f);

        //revert back to default
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedEnemy)
            return;

        if (collision.tag == "Enemy")
        {

            detectedEnemy = collision.GetComponent<EnemyBasic>();
             attackOrder = StartCoroutine(Attack());
        }
    }

}
