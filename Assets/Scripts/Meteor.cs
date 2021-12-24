using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D body;
    private int world_size = 50;
    public float speed;
    private Vector2 direction;
    private float line;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        this.GetTarget();
    }
    void GetTarget()
    {
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        direction.Normalize();
        line = Random.Range(40.0f, 120.0f);
    }
    void Update()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
        line -= speed;
        if (line <= 0)
        {
            this.GetTarget();
        }
        body.MoveRotation(body.rotation + Random.Range(0, 0.2f));
        if ((body.position.x < -world_size) | (body.position.x > world_size) | (body.position.y < -world_size) | (body.position.y > world_size))
        {
            body.MovePosition(new Vector2(Random.Range(-world_size, world_size), Random.Range(-world_size, world_size)));
        }
    }
}
