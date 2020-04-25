using UnityEngine;

public class KeyTrigger : MonoBehaviour {
    
    public AudioSource Sound;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        Sound.Play();
        GameState.AcquireKey();
        gameObject.SetActive(false);
    }
    
}
