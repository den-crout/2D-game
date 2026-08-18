using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            int randomAbility = Random.Range(0, 1);
            if (randomAbility == 0)
            {
                playerMovement.speed += 2f;
            }
        }
    }
}
