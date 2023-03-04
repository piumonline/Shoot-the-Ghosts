using UnityEngine;

public class Ghost : MonoBehaviour
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

    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    void Update()
    {
        Raycasting();

        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.x < -12)
        {
            EndParth();
            return;
        }
    }

    private void EndParth()
    {
        Stats.lives--;
        GhostSpawn.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GetComponent<AudioSource>().Stop();
        GameObject e= Instantiate(_cloudParticle,transform.position,Quaternion.identity);
        Stats.kills++; 
        GhostSpawn.EnemiesAlive--;
        Destroy(gameObject);
        //Destroy(e, 0.8f); destroy clone particle after 0.8s
        return;
    }

    void Raycasting()
    {
        Physics2D.IgnoreLayerCollision(9,8);
    }
}
