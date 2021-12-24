using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject obj;
    void Update()
    {
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -10f);
    }
}

