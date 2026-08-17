using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 10f;
    public float damage = 5f;
    private GameObject[] enemies;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementToEnemy();
    }

    void MovementToEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
            
        }
        if (closestEnemy != null)
        {
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SmallStone>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
