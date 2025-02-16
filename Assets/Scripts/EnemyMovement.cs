using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
    [SerializeField] bool isBoss = false;
    Rigidbody2D myRigidbody;
    private Animator            m_animator;
    private bool isAttacking = false;
    private Transform playerTransform;
    private Transform mainCameraTransform;
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

        transform.localScale = new Vector2 ((Mathf.Sign(moveSpeed)), 1f);
    }

    void Update()
    {
        if (!isAttacking) // Chỉ di chuyển khi không tấn công
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            if (isBoss)
            {
                m_animator.SetInteger("AnimState", 1);
                m_animator.SetBool("Grounded", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Object OnTriggerEnter2D: ");
        if ( isBoss && other.tag == "Player")
        {
            m_animator.SetInteger("AnimState", 0);
            m_animator.SetBool("Grounded", false);
            isAttacking = true; // Đánh dấu là đang tấn công
            myRigidbody.velocity = Vector2.zero; // Dừng di chuyển
            playerTransform = other.transform; // Lưu lại transform của player

            StartCoroutine(AttackCoroutine()); // Bắt đầu coroutine tấn công
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAttacking = false; // Dừng tấn công
            StopCoroutine(AttackCoroutine()); // Dừng coroutine tấn công nếu đang chạy
            playerTransform = null; // Xóa tham chiếu player
            if(isBoss)
            {
                m_animator.SetInteger("AnimState", 1);
                m_animator.SetBool("Grounded", true);
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        while (isAttacking && playerTransform != null) // Tấn công khi isAttacking là true và player còn tồn tại
        {
            m_animator.SetTrigger("Attack2");
            yield return new WaitForSeconds(1f); // Chờ 1 giây
        }
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
