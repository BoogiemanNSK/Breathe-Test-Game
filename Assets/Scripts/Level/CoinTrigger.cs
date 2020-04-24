using UnityEngine;

public class CoinTrigger : MonoBehaviour {

    public AudioSource Sound;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(Constants.PLAYER_TAG)) return;
        
        Sound.Play();
        GameState.CollectCoin();
        gameObject.SetActive(false);
    }
    
}
