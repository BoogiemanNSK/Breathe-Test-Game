using UnityEngine;

public class RangeAi : MonoBehaviour {

    public int LevelLocation;
    public float DetectionRadius;
    public float ProjectileSpeed;
    public float LaunchTimeMin, LaunchTimeMax;
    public BulletLogic BulletPrefab;
    public AudioSource Audio, BulletMiss;
    public AudioClip Death, Shot;

    private GameObject _player;
    private float _nextShot;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        _nextShot = Time.fixedTime;
    }

    private void Update() {
        if (Time.fixedTime >= _nextShot) {
            ShootAttempt();
        }
    }

    private void ShootAttempt() {
        Vector3 playerLocation = _player.transform.position;
        Vector3 shooterLocation = gameObject.transform.position;

        if (LevelLocation == GameState.GetPlayerLevel() &&
            Vector3.Distance(playerLocation, shooterLocation) < DetectionRadius) {
            Vector3 targetDestination = playerLocation - shooterLocation;

            BulletMiss.transform.position = playerLocation;
            BulletLogic spawnedBullet = Instantiate(BulletPrefab, gameObject.transform);
            spawnedBullet.FireAt(gameObject, Vector3.Normalize(targetDestination), ProjectileSpeed, BulletMiss);

            Audio.clip = Shot;
            Audio.Play();
        }
        
        _nextShot = Time.fixedTime + Random.Range(LaunchTimeMin, LaunchTimeMax);
    }

    public void Die() {
        Audio.clip = Death;
        Audio.Play();
        Destroy(gameObject);
    }

}
