using UnityEngine;

public class Spiner : MonoBehaviour
{
    public float _spin_speed = 3f;
    void Update()
    {
        transform.Rotate(_spin_speed, _spin_speed, 0, Space.Self);
    }
}
