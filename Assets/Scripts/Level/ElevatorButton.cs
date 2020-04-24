using UnityEngine;

public class ElevatorButton : MonoBehaviour {

    public GameObject KeyIcon;
    public ElevatorController Controller;
    public AudioSource Sound;
    
    private bool _buttonPressed;
    private bool _triggerEntered;
    
    private void Start() {
        _buttonPressed = false;
        KeyIcon.SetActive(false);
    }

    private void Update() {
        if (!_buttonPressed && _triggerEntered) {
            if (Input.GetKeyDown("e")) {
                _buttonPressed = true;
                Controller.OnTriggered(0);
                Sound.Play();
                KeyIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        if (!_buttonPressed) {
            KeyIcon.SetActive(true);
            _triggerEntered = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        if (!_buttonPressed) {
            KeyIcon.SetActive(false);
            _triggerEntered = false;
        }
    }
    
}
