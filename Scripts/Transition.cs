using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DontDestroyOnLoad))]
public class Transition : MonoBehaviour
{
    Animator animator;
    int sceneIndex;
    string sceneName = string.Empty;

    LoadMode loadMode;

    enum LoadMode
    {
        index,
        name
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(int index)
    {
        loadMode = LoadMode.index;
        sceneIndex = index;

        animator.Play("In");
    }

    public void LoadScene(string name)
    {
        loadMode = LoadMode.name;
        sceneName = name;

        animator.Play("In");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if((loadMode == LoadMode.name && sceneName == scene.name) || (loadMode == LoadMode.index && sceneIndex == scene.buildIndex))
        {
            animator.Play("Out");
        }
    }

    public void OnFinishInAnimation()
    {
        if (loadMode == LoadMode.name)
        {
            SceneManager.LoadSceneAsync(sceneName);
        } else
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }


}



