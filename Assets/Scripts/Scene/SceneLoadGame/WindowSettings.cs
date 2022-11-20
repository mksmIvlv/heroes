using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WindowSettings : MonoBehaviour
{
    GameObject[] childComponents;
    GameObject[] allButton;
    AudioSource buttonClick;
    AudioSource soundBackground;
    TextMeshProUGUI onOffText;

    void Awake()
    {
        GetChildComponents();

        onOffText = allButton[0].gameObject.GetComponent<TextMeshProUGUI>();

        buttonClick = gameObject.GetComponent<AudioSource>();

        soundBackground = GameObject.Find("Background").GetComponent<AudioSource>();
    }

    /// <summary>
    /// Кнопка включения и отключения звука
    /// </summary>
    public void ButtonOnOffSound() 
    {
        buttonClick.Play();

        if (soundBackground.isPlaying) 
        {
            soundBackground.Stop();

            onOffText.text = "On";
        }
        else 
        {
            soundBackground.Play();

            onOffText.text = "Off";
        }
    }

    /// <summary>
    /// Кнопка закрытия текущего окна
    /// </summary>
    public void ButtonClose()
    {
        buttonClick.Play();

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

        allButton = new GameObject[childComponents[1].gameObject.transform.childCount];

        for (int i = 0; i < allButton.Length; i++)
        {
            allButton[i] = childComponents[1].transform.GetChild(i).gameObject;
        }
    }
}
