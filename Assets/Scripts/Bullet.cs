using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D body; 
    public int speed;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
    }
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "Enemy")
        {
            Transform[] children = obj.GetComponentsInChildren<Transform>();
            foreach (Transform t in children)
            {
                t.GetComponent<Enemy>().Damage(1); ;
            }
        }
        if (obj.tag == "Station")
        {
            obj.GetComponent<EnemyStation>().Damage(1);
        }
        Destroy(gameObject);
    }
}
