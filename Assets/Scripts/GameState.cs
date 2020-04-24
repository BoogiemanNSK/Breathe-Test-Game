public static class GameState {

    private static bool _keyAcquired;
    private static int _coinsCollected;
    private static bool _gameFinished;

    public static bool IsKeyAcquired() {
        return _keyAcquired;
    }

    public static int CollectedCoins() {
        return _coinsCollected; 
    }
    
    public static bool IsGameFinished() {
        return _gameFinished;
    }

    public static void AcquireKey() {
        _keyAcquired = true;
        EventManager.TriggerEvent(Constants.KEY_COLLECT_EVENT_NAME);
    }

    public static void CollectCoin() {
        _coinsCollected++;
        EventManager.TriggerEvent(Constants.COIN_COLLECT_EVENT_NAME);
    }

    public static void FinishGame() {
        _gameFinished = true;
    }

    public static void ResetGameState() {
        _coinsCollected = 0;
        _keyAcquired = false;
        _gameFinished = false;
    }

}
