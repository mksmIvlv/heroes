using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCanvas : MonoBehaviour
{
    protected int sceneIndex;

    /// <summary>
    /// Кнопка перезагрузки сцены
    /// </summary>
    protected virtual void ButtonRestart()
    {
        var sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Кнопка выхода на уровень загрузки игры
    /// </summary>
    protected virtual void ButtonQuit()
    {
        SceneManager.LoadScene("SceneLoadGame");
    }
}
