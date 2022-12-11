using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class WindowLevel : MonoBehaviour
{
    AudioSource buttonClick;

    void Awake()
    {
        buttonClick = gameObject.GetComponent<AudioSource>();
    }

    #region Кнопки

    /// <summary>
    /// Кнопка закрытия текущего окна
    /// </summary>
    public void ButtonClose()
    {
        buttonClick.Play();

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Кнопка загрузки первого уровня
    /// </summary>
    public void ButtonLoadLevel1()
    {
        buttonClick.Play();

        SceneManager.LoadScene("Level1");
    }

    #endregion
}
