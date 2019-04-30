using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    public int health;

    public GameObject deathEffect;

    Animator enemyAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //enemyAnim.Play("Slime_Death");
            Destroy(gameObject);
        }

        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-2, 2);
        }

    }

    public void TakeDamage(int damage)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurningPoint"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }

}
