using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject[] childComponents;
    GameObject[] allButton;
    GameObject choicePlayer;


    void Awake()
    {
        PlayerPrefs.SetInt("currentHero", -1);

        GetChildComponents();

        FindAndDisableComponents();
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckSetInHero();
    }

    /// <summary>
    /// Кнопка старта игры
    /// </summary>
    public void ButtonPlay() 
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Кнопка выбора героя для игры
    /// </summary>
    public void ButtonСhoosingHero() 
    {
        choicePlayer.SetActive(true);
    }

    /// <summary>
    /// Поиск и отключение компонентов на сцене
    /// </summary>
    void FindAndDisableComponents() 
    {
        choicePlayer = GameObject.Find("ChoicePlayer");

        allButton[0].gameObject.SetActive(false);

        choicePlayer.SetActive(false);
    }

    /// <summary>
    /// Получение всех дочерних элементов
    /// </summary>
    void GetChildComponents() 
    {
        childComponents = new GameObject[transform.childCount];

        for (int i = 0; i < childComponents.Length; i++)
        {
            childComponents[i] = transform.GetChild(i).gameObject;
        }

        allButton = new GameObject[childComponents[0].gameObject.transform.childCount];

        for (int i = 0; i < allButton.Length; i++)
        {
            allButton[i] = childComponents[0].transform.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// Проверка, выбран ли персонаж для игры
    /// </summary>
    void CheckSetInHero() 
    {
        if (PlayerPrefs.GetInt("currentHero") == -1) 
        {
            allButton[0].gameObject.SetActive(false);
        }
        else
            allButton[0].gameObject.SetActive(true);
    }
}
