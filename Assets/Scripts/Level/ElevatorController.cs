using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public GameObject F1Lights, F2Lights, ElevatorLights;
    public Animation ElevatorAnim, F1LeftAnim, F2LeftAnim, F2RightAnim;
    public AudioSource ElevatorSound, ArrivalSound;

    public void OnTriggered(int id) {
        switch (id) {
            case 0:
                F1LeftAnim.Play();
                F1Lights.SetActive(false);
                ElevatorLights.SetActive(true);
                break;
            case 1:
                ElevatorAnim.Play();
                ElevatorSound.Play();
                break;
            case 2:
                ElevatorSound.Stop();
                ArrivalSound.Play();
                F2LeftAnim.Play();
                F2RightAnim.Play();
                break;
            case 3:
                ElevatorLights.SetActive(false);
                F2Lights.SetActive(true);
                break;
        }
    }

}
