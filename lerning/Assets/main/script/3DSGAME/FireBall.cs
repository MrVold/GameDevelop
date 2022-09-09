using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
