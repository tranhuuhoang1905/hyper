using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private float speed;
    void Awake()
{
    myRigidbody = GetComponent<Rigidbody2D>(); // ✅ Luôn có giá trị ngay khi Bullet được tạo
}
    public void Initialize(float bulletSpeed, float direction)
    {
        float direction2 = transform.rotation.y == 0 ? 1 : -1;
        speed = bulletSpeed*direction2 ;
        // transform.localScale = new Vector2(Mathf.Sign(speed), 1f);
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(speed, 0f);
    }
}