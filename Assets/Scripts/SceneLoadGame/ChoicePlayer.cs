using UnityEngine;

public class ChoicePlayer : MonoBehaviour
{
    GameObject[] childComponents;
    GameObject[] allButton;
    GameObject[] allHero;
    int indexHero = 0;

    void Awake()
    {
        GetChildComponents();

        EnableScriptsInHero();

        allButton[0].gameObject.SetActive(false);

        allHero[indexHero].gameObject.SetActive(true);
    }

    /// <summary>
    /// Кнопка влево
    /// </summary>
    public void ButtonInLeft()
    {
        if (indexHero == allHero.Length - 1)
        {
            allButton[2].gameObject.SetActive(true);
        }
        if (indexHero != 0)
        {
            allHero[indexHero].gameObject.SetActive(false);
            indexHero--;
            allHero[indexHero].gameObject.SetActive(true);
        }
        if (indexHero == 0)
        {
            allButton[0].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Кнопка вправо
    /// </summary>
    public void ButtonInRight()
    {
        if (indexHero == 0)
        {
            allButton[0].gameObject.SetActive(true);
        }
        if (indexHero != allHero.Length - 1)
        {
            allHero[indexHero].gameObject.SetActive(false);
            indexHero++;
            allHero[indexHero].gameObject.SetActive(true);
        }
        if (indexHero == allHero.Length - 1)
        {
            allButton[2].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Кнопка выбора текущего героя, для дальнейшей загрузки его
    /// </summary>
    public void ButtonSet()
    {
        PlayerPrefs.SetInt("currentHero", indexHero);
    }

    /// <summary>
    /// Кнопка закрытия текущего окна
    /// </summary>
    public void ButtonClose() 
    {
        gameObject.SetActive(false);
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

        allHero = new GameObject[childComponents[1].gameObject.transform.childCount];

        for (int i = 0; i < allHero.Length; i++)
        {
            allHero[i] = childComponents[1].transform.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// Выключение скриптов у героев. Нужно, чтоб работала анимация, что герой стоит на месте 
    /// </summary>
    void EnableScriptsInHero() 
    {
        for (int i = 0; i < allHero.Length; i++)
        {
            allHero[i].GetComponent<ManagerHero>().enabled = false;

        }
    }
}
