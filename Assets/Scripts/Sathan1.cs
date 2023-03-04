using UnityEngine;

public class Sathan1 : MonoBehaviour
{
    [SerializeField]
    public GameObject _cloudParticle;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    Vector3 pos, localScale;

	public static float healthAmount = 0.8f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthAmount = 0.8f;

        pos = transform.position;
        localScale = transform.localScale;
    }

    void Update()
    {
        Raycast();

        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

        if (transform.position.x < -12)
        {
            EndParth();
            return;
        }

        if (healthAmount <= 0)
        {
            Destroy(gameObject);
            GhostSpawn.EnemiesAlive--;
            Stats.kills++;
        }
    }

    void Raycast()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    private void EndParth()
    {
        Stats.lives--;
        GhostSpawn.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        healthAmount -= 0.1f;

        GameObject e = Instantiate(_cloudParticle, transform.position, Quaternion.identity);

        //Debug.Log(collisionInfo.collider.name);
       
    }
}
