using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameOver : ManagerCanvas
{
    GameObject gameOver;
    GameObject currentHero;
    AudioSource buttonClick;

    void Awake()
    {
        gameOver = gameObject.transform.GetChild(0).gameObject;

        buttonClick = gameOver.GetComponent<AudioSource>();

        SetHero();
    }

    void FixedUpdate()
    {
        ActivateMenuGameOver();
    }

    #region Кнопки
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
    /// Метод для установки ссылки, за каким героем нужно наблюдать
    /// </summary>
    protected void SetHero()
    {
        var indexHero = PlayerPrefs.GetInt("currentHero");

        var allHeroes = GameObject.Find("AllHeroes");

        currentHero = allHeroes.transform.GetChild(indexHero).gameObject;
    }

    /// <summary>
    /// Активация меню проигрыша игры
    /// </summary>
    public void ActivateMenuGameOver()
    {
        if (currentHero == null) 
        {
            gameOver.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    #endregion
}
