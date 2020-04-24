using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioClip Main, Ending;
    public AudioSource Audio;
    
    private void Start() {
        Audio.loop = true;
        Audio.clip = Main;
        Audio.Play();
        
        EventManager.StartListening(Constants.WIN_EVENT_NAME, SwitchTrack);
        EventManager.StartListening(Constants.LOSE_EVENT_NAME, SwitchTrack);
    }

    private void SwitchTrack() {
        Audio.clip = Ending;
        Audio.Play();
    }

}
