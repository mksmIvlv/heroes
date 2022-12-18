using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCanvas : MonoBehaviour
{
    protected AudioSource buttonClick;
    protected string sceneName;

    /// <summary>
    /// Кнопка перезагрузки сцены
    /// </summary>
    public void ButtonRestart()
    {
        buttonClick.Play();

        SceneManager.LoadScene(sceneName);

        Time.timeScale = 1f;
    }
}
