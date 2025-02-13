using UnityEngine;

public class BulletProjectileScript : MonoBehaviour
{
    //Variables
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    //Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
