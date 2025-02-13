using UnityEngine;

public class levelOneEnemyScript : MonoBehaviour
{
    //Initialize variables
    [SerializeField] int enemySpeed = 3;
    GameLogic gameLogic;
    private void Start()
    {
        gameLogic = FindAnyObjectByType<GameLogic>();
    }


    // Update is called once per frame
    void Update()
    {
        //Move Enemy down
        transform.Translate(Vector2.down * Time.deltaTime * enemySpeed);
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
            gameLogic.playerLife--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        BulletProjectileScript bullet = collision.gameObject.GetComponent<BulletProjectileScript>();

        //If enemy hits player
        if (player != null)
        {
            gameLogic.playerLife--;
            Destroy(gameObject);
        }

        // If projectile hit enemy
        else if (bullet != null)
        gameLogic.playerScore++;
        gameLogic.DisplayScore();
        Destroy(gameObject);
    }
}
