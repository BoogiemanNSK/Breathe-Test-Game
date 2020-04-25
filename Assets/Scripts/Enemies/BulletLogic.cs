using UnityEngine;

public class BulletLogic : MonoBehaviour {
    private AudioSource _missSound;
    private GameObject _shooter;
    private Vector3 _destination;
    private float _speed;

    private void Update() {
        gameObject.transform.position += _destination * _speed * Time.deltaTime;
    }

    public void FireAt(GameObject shooter, Vector3 destination, float bulletSpeed, AudioSource missSound) {
        _shooter = shooter;
        _destination = destination;
        _speed = bulletSpeed;
        _missSound = missSound;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == _shooter) { return; }
        
        // If hit player
        if (other.CompareTag(Constants.PLAYER_TAG)) {
            EventManager.TriggerEvent(Constants.PLAYER_DEATH_EVENT_NAME);
            return;
        }

        // If hit melee
        if (other.CompareTag(Constants.MELEE_TAG)) {
            MeleeAi melee = other.gameObject.GetComponent<MeleeAi>();
            melee.Die();
            Destroy(gameObject);
            return;
        }
        
        // If hit other ranged
        if (other.CompareTag(Constants.RANGED_TAG)) {
            RangeAi range = other.gameObject.GetComponent<RangeAi>();
            range.Die();
            Destroy(gameObject);
            return;
        }

        // Any other hit
        _missSound.Play();
        Destroy(gameObject);
    }

}
