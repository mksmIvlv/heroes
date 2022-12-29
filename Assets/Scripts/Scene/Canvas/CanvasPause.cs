using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : ManagerCanvas
{
    GameObject menuPause;
    AudioSource buttonClick;
    
    void Awake()
    {
        menuPause = gameObject.transform.GetChild(0).gameObject;

        buttonClick = menuPause.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ActivateMenuPause();
    }

    #region Кнопки

    /// <summary>
    /// Кнопка продолжение игры
    /// </summary>
    public void ButtonResume()
    {
        buttonClick.Play();

        menuPause.gameObject.SetActive(false);

        Time.timeScale = 1f;
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
    /// Активация меню
    /// </summary>
    public void ActivateMenuPause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuPause.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    #endregion


}
