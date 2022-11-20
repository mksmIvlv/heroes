using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class WindowMenu : MonoBehaviour
{
    GameObject[] childComponents;
    GameObject[] allButton;
    GameObject[] allWindow;
    AudioSource buttonClick;
    
    void Awake()
    {
        GetChildComponents();

        buttonClick = gameObject.GetComponent<AudioSource>();
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
    public void ButtonHero() 
    {
        buttonClick.Play();

        for (int i = 0; i < allWindow.Length; i++)
        {
            allWindow[i].SetActive(false);
        }

        allWindow[0].SetActive(true);
    }

    /// <summary>
    /// Кнопка загрузки уровня
    /// </summary>
    public void ButtonLevel() 
    {
        buttonClick.Play();

        for (int i = 0; i < allWindow.Length; i++)
        {
            allWindow[i].SetActive(false);
        }

        allWindow[1].SetActive(true);
    }

    /// <summary>
    /// Кнопка загрузки настроек
    /// </summary>
    public void ButtonSettings() 
    {
        buttonClick.Play();

        for (int i = 0; i < allWindow.Length; i++)
        {
            allWindow[i].SetActive(false);
        }

        allWindow[2].SetActive(true);
    }

    /// <summary>
    /// Кнопка выхода из игры
    /// </summary>
    public void ButtonQuit() 
    {
        buttonClick.Play();

        Application.Quit();
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

        allWindow = new GameObject[childComponents[1].gameObject.transform.childCount];

        for (int i = 0; i < allWindow.Length; i++)
        {
            allWindow[i] = childComponents[1].transform.GetChild(i).gameObject;

            //Отключаем компоненты
            allWindow[i].SetActive(false);  
        }
    }
}
