using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.name == "Player")
        {
            obj.GetComponent<Player>().Messenge("�������� ��������");
            obj.GetComponent<Player>().Damage(Mathf.Round(1 / Vector3.Distance(obj.GetComponent<Rigidbody2D>().position, transform.position))*0.1f);
            /* �������� ������������� �� �������:
             * 1/���������� ����� �������� ����������� �� �������������� ����� � ���������� �� 0.1
             */
        }
    }
}