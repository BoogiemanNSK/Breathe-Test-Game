using UnityEngine;

public class Player : MonoBehaviour {

    public AudioSource PlayerSounds;
    public Controller2D Controller;
    public Animator Anim;
    
    private void Start() {
        EventManager.StartListening(Constants.PLAYER_DEATH_EVENT_NAME, OnDeath);
    }

    private void Update() {
        if (Input.GetAxis("Horizontal") != 0) { 
            Anim.SetBool(Constants.ANIM_IS_WALKING, true); 
        } else { 
            Anim.SetBool(Constants.ANIM_IS_WALKING, false); 
        }

        if (Input.GetAxis("Vertical") > 0 && Input.GetButtonDown("Vertical")) {
            Anim.SetTrigger(Constants.ANIM_JUMP);
        }
    }

    private void OnDeath() {
        if (GameState.IsGameFinished()) { return; }
        
        PlayerSounds.Play();
        Controller.Die();
        GameState.FinishGame();
        EventManager.TriggerEvent(Constants.LOSE_EVENT_NAME);
    }
    
}
