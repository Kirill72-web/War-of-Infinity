using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStation : MonoBehaviour
{
    public float health = 5;
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("Manager").GetComponent<Manager>().score += 500;
            Destroy(gameObject);
        }
    }
}
