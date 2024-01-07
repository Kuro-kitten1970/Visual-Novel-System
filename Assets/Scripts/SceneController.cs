using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] SceneAsset _nextScene;

    public void NextScene()
    {
        SceneManager.LoadScene(_nextScene.name);
    }
}
