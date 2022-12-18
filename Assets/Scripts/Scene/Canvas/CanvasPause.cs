using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : ManagerCanvas
{
    [SerializeField] private GameObject menuPause;
    
    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        buttonClick = gameObject.GetComponent<AudioSource>();
        Time.timeScale = 1f;
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

        menuPause.gameObject.SetActive(false);

        Time.timeScale = 1f;
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

            buttonClick.Play();

            Time.timeScale = 0f;
        }
    }

    #endregion


}
