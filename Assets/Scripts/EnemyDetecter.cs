using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    public GameObject root;
    private Rigidbody2D body;
    void Start()
    {
        body = root.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = body.position;
    }
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.name == "Player")
        {
            root.GetComponent<Enemy>().battle_mod = true;
        }
    }
}
