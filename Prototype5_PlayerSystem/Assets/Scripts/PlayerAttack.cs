using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Rock")
        {
            collision.collider.gameObject.SetActive(false);
        }

        if (collision.collider.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<EnemyManager>();
            Debug.Log(collision.collider.tag);
            enemy.es.maxHealth -= 20;
        }
    }
}
