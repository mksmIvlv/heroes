using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject allHeroes;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private GameObject allArrows;

    private GameObject currentHero;
    private int indexHero;

    void Awake()
    {
        Time.timeScale = 1f;

        SetHero();

        ActivatedArrowScene();
    }


    void SetHero()
    {
        indexHero = PlayerPrefs.GetInt("currentHero");

        currentHero = allHeroes.transform.GetChild(indexHero).gameObject;

        allHeroes.transform.GetChild(indexHero).gameObject.SetActive(true);

        cinemachineVirtualCamera.Follow = allHeroes.transform.GetChild(indexHero).transform;
    }


    void ActivatedArrowScene()
    {
        allArrows = GameObject.Find("AllArrows");

        if (indexHero == 0)
        {
            allArrows.SetActive(true);
        }
        else
        {
            allArrows.SetActive(false);
        }
    }
}
