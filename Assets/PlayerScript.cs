using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Initialize variables
    [SerializeField] float playerSpeed = 10.0f;
    [SerializeField] GameObject BulletProjectile;

    void Update()
    {
        //Get player movement on key press
        float playerMove = Input.GetAxis("Horizontal");

        //Move player
        transform.Translate(playerMove * Vector2.right * Time.deltaTime * playerSpeed);

        //Keep player in bounds
        KeepInBounds();

        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            FireBullet();
        }

    }

    //Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    //Fire bullets
    private void FireBullet()
    { 
        Instantiate(BulletProjectile, transform.position + (Vector3.up * 1.2f), Quaternion.identity); 
    }

    //Keep objects in bounds
    public void KeepInBounds()
    {

        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}