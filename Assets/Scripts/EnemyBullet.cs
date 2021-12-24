using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (obj.name == "Player")
        {
            obj.GetComponent<Player>().Damage(1);
        }
        Destroy(gameObject);
    }
}
