using UnityEngine;

public class SceneLoadGame : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("currentHero", 0);
    }
}
