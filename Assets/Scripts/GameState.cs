public static class GameState {

    private static bool _keyAcquired;
    private static int _coinsCollected;

    public static bool IsKeyAcquired() {
        return _keyAcquired;
    }

    public static int CollectedCoins() {
        return _coinsCollected; 
    }

    public static void AcquireKey() {
        _keyAcquired = true;
        EventManager.TriggerEvent(Constants.KEY_COLLECT_EVENT_NAME);
    }

    public static void CollectCoin() {
        _coinsCollected++;
        EventManager.TriggerEvent(Constants.COIN_COLLECT_EVENT_NAME);
    }

    public static void ResetGameState() {
        _coinsCollected = 0;
        _keyAcquired = false;
    }

}
