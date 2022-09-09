using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    public float speed = 3.0f;

    public const float baseSpeed = 3.0f;

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }

    private void OnSpeedChange(float value)
    {
        speed = baseSpeed * value;
    }

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(12.24f, 1.75f, -5.54f);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy.GetComponent<WanderingAI>().speed = speed;
        }
    }
}
