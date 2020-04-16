using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    Transition transition;

    void Awake()
    {
        transition = FindObjectOfType<Transition>();
    }

    public void Load(string sceneName)
    {
        transition.LoadScene(sceneName);
    }
}
