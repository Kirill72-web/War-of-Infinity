using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldGenerator : MonoBehaviour
{
    public GameObject star;
    public GameObject small_star;
    public GameObject station;
    public GameObject meteor;
    public GameObject enemy;
    public GameObject menu;
    public GameObject score;
    public GameObject manager;
    private int star_count;
    private int small_star_count;
    private int level = 1;
    private float world_size = 50.0f;
    void Start()
    {
        Generate();
        menu.SetActive(false);
    }
    void Generate()
    {
        small_star_count = Random.Range(1500, 2500);
        star_count = Random.Range(150, 250);
        for (int i = 0; i < small_star_count; i++)
        {
            Vector3 spawn_pos = Vector3.zero;
            spawn_pos.x = Random.Range(-world_size, world_size);
            spawn_pos.y = Random.Range(-world_size, world_size);
            spawn_pos.z = 0;
            Instantiate(small_star, spawn_pos, Quaternion.identity).transform.parent = transform;
        }
        for (int i = 0; i < star_count; i++)
        {
            Vector3 spawn_pos = Vector3.zero;
            spawn_pos.x = Random.Range(-world_size, world_size);
            spawn_pos.y = Random.Range(-world_size, world_size);
            spawn_pos.z = 0;
            Instantiate(star, spawn_pos, Quaternion.identity).transform.parent = transform;
        }
        for (int i = 0; i < level*3; i++)
        {
            Vector3 spawn_pos = Vector3.zero;
            spawn_pos.x = Random.Range(-world_size, world_size);
            spawn_pos.y = Random.Range(-world_size, world_size);
            spawn_pos.z = 0;
            Instantiate(station, spawn_pos, Quaternion.identity);
        }
        for (int i = 0; i < 12; i++)
        {
            Vector2 spawn_pos = Vector3.zero;
            spawn_pos.x = Random.Range(-world_size, world_size);
            spawn_pos.y = Random.Range(-world_size, world_size);
            Instantiate(meteor, spawn_pos, Quaternion.identity);
        }
        for (int i = 0; i < level*20; i++)
        {
            Vector2 spawn_pos = Vector3.zero;
            spawn_pos.x = Random.Range(-world_size, world_size);
            spawn_pos.y = Random.Range(-world_size, world_size);
            Instantiate(enemy, spawn_pos, Quaternion.identity);
        }
    }
    public void PlayerDeath()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        score.GetComponent<Text>().text = ""+manager.GetComponent<Manager>().score;
    }
}
