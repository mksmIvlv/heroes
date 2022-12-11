using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    AudioSource buttonClick;
    private string sceneName;

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        buttonClick = menuPause.gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ActivateMenuPause();
    }

    #region Кнопки

    /// <summary>
    /// Кнопка закрытия меню
    /// </summary>
    public void ButtonClose()
    {
        buttonClick.Play();

        menuPause.SetActive(false);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Кнопка перезагрузки сцены
    /// </summary>
    public void ButtonRestart()
    {
        buttonClick.Play();

        SceneManager.LoadScene(sceneName);

        ButtonClose();
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Активация меню
    /// </summary>
    void ActivateMenuPause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuPause.SetActive(true);

            buttonClick.Play();

            Time.timeScale = 0f;
        }
    }

    #endregion


}
