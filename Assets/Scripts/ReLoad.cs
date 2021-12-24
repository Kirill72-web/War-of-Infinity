using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReLoad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
