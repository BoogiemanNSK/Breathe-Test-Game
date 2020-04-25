using UnityEngine;

public class ElevatorTrigger : MonoBehaviour {

    public ElevatorController Controller;

    public void OnTriggered(int id) {
        Controller.OnTriggered(id);
    }

}
