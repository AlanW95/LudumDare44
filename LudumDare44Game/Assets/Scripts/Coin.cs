using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 0;

    public GameObject pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(pickupSound, transform.position, Quaternion.identity);
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
