using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject MenuScreen, HelpScreen;
    
    private void Start() {
        OnBackClick();
    }

    public void OnStartClick() {
        SceneManager.LoadScene(Constants.MAIN_SCENE_NAME);
    }
    
    public void OnHelpClick() {
        HelpScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }
    
    public void OnBackClick() {
        HelpScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }
    
    public void OnExitClick() {
        Application.Quit(0);
    }
    
}
