using UnityEngine;

public class MeleeAi : MonoBehaviour {

    private void Start() {
        
    }
    
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) { return; }
        EventManager.TriggerEvent(Constants.PLAYER_DEATH_EVENT_NAME);
    }
}
