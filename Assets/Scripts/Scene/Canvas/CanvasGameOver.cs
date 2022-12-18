using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameOver : ManagerCanvas
{
    [SerializeField] private GameObject gameOver;
    GameObject currentHero;

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        buttonClick = gameOver.gameObject.GetComponent<AudioSource>();

        Time.timeScale = 1f;

        SetHero();
    }

    void FixedUpdate()
    {
        ActivateMenuGameOver();
    }

    #region Кнопки


    /// <summary>
    /// Кнопка выхода на уровень загрузки игры
    /// </summary>
    public void ButtonQuit()
    {
        buttonClick.Play();

        SceneManager.LoadScene("SceneLoadGame");
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

            buttonClick.Play();

            Time.timeScale = 0f;
        }
    }

    #endregion
}
