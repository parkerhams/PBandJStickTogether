using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour {

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;
    public Vector2 savedVelocity;

    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private AudioSource dashSound;
    [SerializeField]
    private GameObject dashParticles;

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    //rigidbody.velocity = Vector3.zero;
                    savedVelocity = rigidbody.velocity;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x * 3f, rigidbody.velocity.y);
                    dashSound.Play();
                    Instantiate(dashParticles, transform.position, Quaternion.identity);
                    dashState = DashState.Dashing;
                }
                break;
                //This case ,ayout is courtesy of user Alanissac on Unity3D forums --- 
                //these next two cases WERE NOT MINE, and I based the previous code form on this forum.
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rigidbody.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
