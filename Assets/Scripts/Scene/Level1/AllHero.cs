using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHero : MonoBehaviour
{
    GameObject[] allHero;


    void Awake()
    {
        allHero = new GameObject[transform.childCount];
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHero() 
    {
        allHero = new GameObject[transform.childCount];

        for (int i = 0; i < allHero.Length; i++)
        {
            allHero[i] = transform.GetChild(i).gameObject;
        }

        int indexHero = PlayerPrefs.GetInt("currentHero");

        for (int i = 0; i < allHero.Length; i++)
        {
            if (indexHero == i) 
            {
                allHero[i].SetActive(true);
            }
        }
    }
}
