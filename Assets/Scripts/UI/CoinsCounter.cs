using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour {

    public Text Counter;

    private void Start() {
        EventManager.StartListening(Constants.COIN_COLLECT_EVENT_NAME, OnCoinCollect);
    }

    private void OnCoinCollect() {
        Counter.text = GameState.CollectedCoins() + " / " + Constants.MAX_COINS;
    }
    
}
