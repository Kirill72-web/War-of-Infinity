using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D body;
    private Vector2 direction;
    private int world_size = 50;
    public float health = 10.0f;
    public GameObject health_bar;
    public GameObject messenge;
    public GameObject bullet;
    private Vector2 view;
    void Start()
    {
        view = new Vector2(0, 1);
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = new Vector2();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();
        if (direction.x > 0)
        {
            direction.x = 1;
        }
        else if (direction.x < 0)
        {
            direction.x = -1;
        }
        if (direction.y > 0)
        {
            direction.y = 1;
        }
        else if (direction.y < 0)
        {
            direction.y = -1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            var obj = Instantiate(bullet, body.position, Quaternion.identity);
            obj.GetComponent<Bullet>().direction = view;
            obj.GetComponent<Bullet>().speed = 10;
            obj.transform.rotation = transform.rotation;
            Destroy(obj, 5);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
        if ((body.position.x < -world_size) | (body.position.x > world_size) | (body.position.y < -world_size) | (body.position.y > world_size))
        {
            messenge.GetComponent<Text>().text = " орабль не дл€ полетов в глубоком космосе";
            health -= 0.1f;
            health_bar.GetComponent<Image>().fillAmount = 1 - 1 / health;
            if (health <= 0) 
            {
                this.Death();
            }
        }
        else
        {
            messenge.GetComponent<Text>().text = " ";
        }
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float angle = Mathf.Atan2(mousePosition.y - Mathf.Abs(body.transform.position.y), mousePosition.x - Mathf.Abs(body.transform.position.y)) * Mathf.Rad2Deg;
        //body.MoveRotation(angle + 360 - 90);
        if (direction != new Vector2())
        {
            view = direction;
        }
        if (view.x == 1)
        {
            body.MoveRotation(-90);
        }
        else if (view.x == -1)
        {
            body.MoveRotation(90);
        }
        else if (view.y == -1)
        {
            body.MoveRotation(180);
        }
        else if (view.y == 1)
        {
            body.MoveRotation(0);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        health_bar.GetComponent<Image>().fillAmount = 1 - 1 / health;
        if (health <= 0)
        {
            this.Death();
        }
    }
    public void Messenge(string msg)
    {
        messenge.GetComponent<Text>().text = msg;
    }
    void Death()
    {
        GameObject.Find("WorldGenerator").GetComponent<WorldGenerator>().PlayerDeath();
    }
}

