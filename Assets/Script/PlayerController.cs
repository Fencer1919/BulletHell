using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody;
    public Text collectedText;
    public static int collectedAmount;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
        
        collectedText.text = "Items Collected: " + collectedAmount;
    }
}
