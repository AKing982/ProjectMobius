using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.LoadScene("StartingScene1", parameters);
        Debug.Log("Load 1 of Scene1: " + scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
