using Cinemachine;
using UnityEngine;

public class AllHeroes : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    GameObject[] allHeroes;
    int indexHero;

    void Awake()
    {
        indexHero = PlayerPrefs.GetInt("currentHero");
    }

    void Start()
    {
        SetHero();
    }

    /// <summary>
    /// Устанавливает камеру за каким героем следить
    /// </summary>
    void SetHero() 
    {
        allHeroes = new GameObject[transform.childCount];

        for (int i = 0; i < allHeroes.Length; i++)
        {
            allHeroes[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < allHeroes.Length; i++)
        {
            if (indexHero == i)
            {
                allHeroes[i].SetActive(true);

                cinemachineVirtualCamera.Follow = allHeroes[i].transform;
            }
        }
    }
}
