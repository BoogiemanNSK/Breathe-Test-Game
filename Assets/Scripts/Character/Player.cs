using UnityEngine;

public class Player : MonoBehaviour {

    public AudioSource PlayerSounds;
    public Controller2D Controller;
    
    private void Start() {
        EventManager.StartListening(Constants.PLAYER_DEATH_EVENT_NAME, OnDeath);
    }

    private void OnDeath() {
        if (GameState.IsGameFinished()) { return; }
        
        PlayerSounds.Play();
        Controller.Die();
        GameState.FinishGame();
        EventManager.TriggerEvent(Constants.LOSE_EVENT_NAME);
    }
    
}
