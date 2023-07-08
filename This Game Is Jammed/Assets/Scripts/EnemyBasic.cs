using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    // Health 
    // Attack
    //Movement Speed
    public int health, attackPower;
    public float movementSpeed;

    public GameObject[] itemDrops;
    public Animator animator;
    public float attackSpeed;
    Coroutine attackOrder;
    Minion_Script detectedMinion;
    public Transform ItemSpawn;

    private void Update()
    {
        if(!detectedMinion)
        {
                Move();
        }
        
    }
             //TODO: Implement Attack Animation
    IEnumerator Attack()
    {
        //play attack animation 
        animator.Play("Attack");

        //attack in interval equal to attack speed
        yield return new WaitForSeconds(attackSpeed);

        //attack again
       attackOrder = StartCoroutine(Attack());

        
    }
    

    //Method to Advance towards the Castle
    void Move()
    {
       transform.Translate(-transform.right* movementSpeed* Time.deltaTime);

    }

    public void InflictDamage()
    {
        bool minionDied = detectedMinion.LoseHealth(attackPower);

        if (minionDied)
        {
            detectedMinion = null;
            StopCoroutine(attackOrder);
        }
    }

    //lose health
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
    protected virtual void Die()
    {
        Debug.Log("Enemy is dead");
        ItemDrop();
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
        if (detectedMinion)
            return;
        
        if(collision.tag == "Minion")
        {

            detectedMinion = collision.GetComponent<Minion_Script>();
            attackOrder = StartCoroutine(Attack());
        }
    }

    private void ItemDrop()
    {
        Instantiate(itemDrops[Random.Range(0, itemDrops.Length)],ItemSpawn.position, Quaternion.identity);
    }

}
