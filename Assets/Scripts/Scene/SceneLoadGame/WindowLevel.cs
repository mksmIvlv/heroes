using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WindowLevel : MonoBehaviour
{
    AudioSource buttonClick;

    void Awake()
    {
        buttonClick = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Кнопка закрытия текущего окна
    /// </summary>
    public void ButtonClose()
    {
        buttonClick.Play();

        gameObject.SetActive(false);
    }
}
