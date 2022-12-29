using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevelPassed : ManagerCanvas
{
    GameObject levelPassed;
    AudioSource buttonClick;

    void Awake()
    {
        levelPassed = gameObject.transform.GetChild(0).gameObject;

        buttonClick = levelPassed.GetComponent<AudioSource>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    #region Кнопки

    /// <summary>
    /// Кнопка загрузки следующей сцены
    /// </summary>
    public void ButtonNext() 
    {
        buttonClick.Play();

        SceneManager.LoadScene($"Level{sceneIndex + 1}");
    }

    protected new void ButtonRestart()
    {
        buttonClick.Play();

        base.ButtonRestart();
    }

    protected override void ButtonQuit()
    {
        buttonClick.Play();

        base.ButtonQuit();
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Метод активации меню паузы
    /// </summary>
    public void Active() 
    {
        levelPassed.SetActive(true);

        Time.timeScale = 0f;
    }

    #endregion
}
