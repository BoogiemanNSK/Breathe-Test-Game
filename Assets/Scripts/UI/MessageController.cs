using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour {

    public Text Message;
    public Animation Disapperaing;

    private void Start() {
        EventManager.StartListening(Constants.KEY_COLLECT_EVENT_NAME, OnKeyCollect);
        EventManager.StartListening(Constants.KEY_REQ_EVENT_NAME, OnExitWithoutKey);
    }

    private void OnExitWithoutKey() {
        Message.text = Constants.KEY_REUIRED;
        Disapperaing.Play();
    }

    private void OnKeyCollect() {
        Message.text = Constants.KEY_ACQUIRED;
        Disapperaing.Play();
    }
}
