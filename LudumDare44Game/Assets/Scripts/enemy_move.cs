using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed;
    public float distance;

    public int health;

    public GameObject deathEffect;

    private bool movingRight = true;

    Animator enemyAnim;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -150, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (health <= 0)
        {
            //enemyAnim.Play("Slime_Death");
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN!");
    }
}
