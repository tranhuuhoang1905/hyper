using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Animator myAnimator;
    
    PlayerMovement playerMovement;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnFire(InputValue value)
    {
        if (!playerMovement.IsAlive) return;

        float direction = Mathf.Sign(transform.localScale.x);
        Quaternion bulletRotation = direction > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        Instantiate(bullet, gun.position, bulletRotation);
    }

    public void AutoFire()
    {
        if (!playerMovement.IsAlive) return;
        
        myAnimator.SetTrigger("IsActack");
        Invoke("InstantiateBullet", 0.2f);
    }

    void InstantiateBullet()
    {
        float direction = Mathf.Sign(transform.localScale.x);
        Quaternion bulletRotation = direction > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        Instantiate(bullet, gun.position, bulletRotation);
    }
}