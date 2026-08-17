using UnityEngine;

public class SmallStone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform player;
    public float damage = 10f;
    public float speed = 2f;
    public float health = 20f;

    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        MovementToPlayer();
    }


    void MovementToPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
       
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("SmallStone lost" + damage + "hp");
        }
    }
}
