using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;
    public int speed;
    public GameObject bullet;
    public bool battle_mod = false;
    private int world_size = 50;
    private Vector2 direction;
    private float line;
    private GameObject player;
    private int health = 3;
    private float time = 0;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        this.GetTarget();
    }
    void GetTarget()
    {
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        direction.Normalize();
        line = Random.Range(40.0f, 120.0f);
    }
    void FixedUpdate()
    {
        if (!battle_mod)
        {
            body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
            line -= speed;
            if (line <= 0)
            {
                this.GetTarget();
            }
            if ((body.position.x < -world_size) | (body.position.x > world_size) | (body.position.y < -world_size) | (body.position.y > world_size))
            {
                body.MovePosition(new Vector2(Random.Range(-world_size, world_size), Random.Range(-world_size, world_size)));
                this.GetTarget();
            }
        }
        else
        {
            direction = new Vector2();
            direction = player.transform.position - transform.position;
            direction.Normalize();
            body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                this.Fire();
                time = 2.0f;
            }
        }
        body.MoveRotation(0);
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("Manager").GetComponent<Manager>().score += 100;
            Destroy(transform.parent.gameObject);
        }
    }
    private void Fire()
    {
        var obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(-1 , 0);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(90);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(1, 0);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(-90);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(0, -1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(180);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(0, 1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(0);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(1, 1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(-45);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(-1, 1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(45);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(1, -1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(-135);
        Destroy(obj, 5);

        obj = Instantiate(bullet, body.position, Quaternion.identity);
        obj.GetComponent<EnemyBullet>().direction = new Vector2(-1, -1);
        obj.GetComponent<EnemyBullet>().speed = 10;
        obj.GetComponent<Rigidbody2D>().MoveRotation(135);
        Destroy(obj, 5);
    }
}
