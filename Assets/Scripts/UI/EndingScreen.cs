using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour {

    public GameObject Screen;
    public Text EndingText;

    private void Start() {
        Screen.SetActive(false);
        EventManager.StartListening(Constants.WIN_EVENT_NAME, OnWin);
        EventManager.StartListening(Constants.LOSE_EVENT_NAME, OnLose);
    }

    public void OnRestartClick() {
        GameState.ResetGameState();
        SceneManager.LoadScene(Constants.MAIN_SCENE_NAME);
    }

    public void OnExitClick() {
        GameState.ResetGameState();
        SceneManager.LoadScene(Constants.MENU_SCENE_NAME);
    }
    
    private void OnWin() {
        Screen.SetActive(true);
        EndingText.text = Constants.WINNING_TEXT;
    }
    
    private void OnLose() {
        Screen.SetActive(true);
        EndingText.text = Constants.LOSING_TEXT;
    }
    
}
