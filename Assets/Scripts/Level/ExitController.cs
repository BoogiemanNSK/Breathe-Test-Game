using UnityEngine;

public class ExitController : MonoBehaviour {

    public GameObject KeyIcon;

    private bool _triggerEntered;

    private void Start() {
        KeyIcon.SetActive(false);
        _triggerEntered = false;
    }

    private void Update() {
        if (_triggerEntered) {
            if (Input.GetKeyDown("e")) {
                EventManager.TriggerEvent(GameState.IsKeyAcquired() ?
                    Constants.WIN_EVENT_NAME : Constants.KEY_REQ_EVENT_NAME);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        _triggerEntered = true;
        KeyIcon.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        _triggerEntered = false;
        KeyIcon.SetActive(false);
    }
}
