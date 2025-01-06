using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadinMenu() { Debug.Log("LoadinMenu"); SceneManager.LoadScene("Menu"); }
    public void UnloadMenu() { Debug.Log("UnloadMenu"); SceneManager.UnloadSceneAsync("Menu"); }
    public void LoadinMainStore() { Debug.Log("LoadinMainStore"); SceneManager.LoadScene("MainStore"); }
    public void UnloadMainStore() { Debug.Log("UnloadMainStore"); SceneManager.UnloadSceneAsync("MainStore"); }
    public void LoadinDragTutorial() { Debug.Log("LoadinDragTutorial"); SceneManager.LoadScene("DragTutorial"); }
    public void UnloadDragTutorial() {Debug.Log("UnloadDragTutorial"); SceneManager.UnloadSceneAsync("DragTutorial"); }

}
