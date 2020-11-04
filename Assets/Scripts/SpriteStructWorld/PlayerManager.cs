using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlayerState
{
    idle,
    walk,
    jump,
    attack,
    dashing
}
/// <summary>
/// player manager
/// </summary>
public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    //public variable
    public float playerWalkSpeed;
    public float jumpForce;
    public float dashForce;
    public GameObject walkFX;
    public GameObject haveSwordEntity;
    public GameObject noHaveSwordEntity;
    public Transform hitPoint;
    public PlayerState playerState = PlayerState.idle;
    //public Transform checkPointWall;
    //public Transform checkPointGround;
    public LayerMask whatiswall;
    [HideInInspector]
    public bool canCtrl = true;
    [HideInInspector]
    public Rigidbody2D mRig;

    //private variable
    private float horizontalValue;
    private Animator anim;
    private SpriteRenderer msr;
    private float vel;
    private bool playerisOnWall = false;
    private float dashingTimer = 0;
    private float dashingCD = 3f;
    //private bool isHitWall = false;
    /// <summary>
    /// is have a sword?
    /// </summary>
    private bool haveSword;

    private bool canDashing;

    /// <summary>
    /// 可以跳跃
    /// </summary>
    private bool canJumpOnce = true;
    /// <summary>
    /// 可以二段跳
    /// </summary>
    private bool canJumpTwice = true;
    /// <summary>
    /// 是否拥有了剑
    /// </summary>
    public bool HaveSword { get => haveSword; set => haveSword = value; }
    public bool CanDashing { get => canDashing; set => canDashing = value; }
    public Animator Anim { get => anim; set => anim = value; }

    void Start()
    {
        mRig = GetComponent<Rigidbody2D>();

        CheckHaveSword();
    }

    void Update()
    {
        CheckHaveSword();
        Attack();
        Jump();
        Move();
        CheckCanDash();
        Dash();
       // Collider2D col = Physics2D.OverlapCircle(checkPointGround.position, 1f, whatiswall);
        //if (col != null && col.transform.CompareTag("Ground"))
        // if (col != null && col.transform.CompareTag("Ground"))
        //    {
        //    playerState = PlayerState.idle;
        //    canJumpOnce = true;
        //    canJumpTwice = true;
        //    isHitWall = false;
        //}
    }

    public void CheckHaveSword()
    {
        if (HaveSword)
        {
            Anim = haveSwordEntity.GetComponent<Animator>();
            msr = haveSwordEntity.GetComponent<SpriteRenderer>();
            haveSwordEntity.SetActive(true);
            noHaveSwordEntity.SetActive(false);
        }
        else
        {
            Anim = noHaveSwordEntity.GetComponent<Animator>();
            msr = noHaveSwordEntity.GetComponent<SpriteRenderer>();
            haveSwordEntity.SetActive(false);
            noHaveSwordEntity.SetActive(true);
        }
    }

    /// <summary>
    /// 检测是否可以冲刺
    /// </summary>
    public void CheckCanDash()
    {
        dashingTimer += Time.deltaTime;
        if(dashingTimer>=dashingCD)
        {
            dashingTimer = 0;
            CanDashing = true;
        }
    }

    public void Attack()
    {
        if (HaveSword&&Input.GetMouseButtonDown(0)&& horizontalValue <= 0.1f&&canCtrl)
        {
            int rand = GameUtility.randomDistribution(0, 3, 5);
            if(rand==0)
            {
                Anim.SetTrigger("attack");
            }else if(rand==1)
            {
                Anim.SetTrigger("attack1");
            }
            else if (rand == 2)
            {
                Anim.SetTrigger("attack2");
            }
            playerState = PlayerState.attack;
        }
    }

   

    public void Move()
    {
        if(canCtrl)
        {
            horizontalValue = Input.GetAxis("Horizontal");
            //if (playerState == PlayerState.jump) return;
            //Debug.Log(horizontalValue);
            if (horizontalValue != 0f && playerState != PlayerState.jump)
            {
                playerState = PlayerState.walk;
                if (horizontalValue < 0)
                {
                    //SetPlayerFlip(true);
                    transform.localScale = new Vector3(-1, 1, 1);
                    //hitPoint.transform.localPosition = new Vector3(-1.49f, hitPoint.transform.localPosition.y, 0);
                }
                else
                {
                    //etPlayerFlip(false);
                    transform.localScale = new Vector3(1, 1, 1);
                    //hitPoint.transform.localPosition = new Vector3(1.49f, hitPoint.transform.localPosition.y, 0);
                }
                Anim.SetBool("run", true);
                walkFX.SetActive(true);
            }
            else
            {
                walkFX.SetActive(false);
                Anim.SetBool("run", false);
                playerState = PlayerState.idle;
            }
            mRig.velocity = new Vector2(horizontalValue * playerWalkSpeed, mRig.velocity.y);
        }
    }

    public int GetPlayerDir()
    {
        return (int)transform.localScale.x;
    }
    public void SetPlayerFlip(bool flip)
    {
        msr.flipX = flip;
    }
    public void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)&&CanDashing&&canCtrl)
        {
            CanDashing = false;
            Anim.SetTrigger("roll");
            AudioManager.audioManager.PlaySoundOneShot("dash");
            mRig.DOMove(new Vector2(transform.position.x + dashForce * (GetPlayerDir() == 1 ? 1 : -1), transform.position.y), 1f);
        }
    }

    public void Jump()
    {
        if(canCtrl)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJumpOnce)
            {
                canJumpOnce = false;
                mRig.velocity = new Vector2(mRig.velocity.x, jumpForce);
                Anim.SetBool("jump", true);
                playerState = PlayerState.jump;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && canJumpTwice)
            {
                canJumpTwice = false;
                canDashing = false;
                mRig.velocity = new Vector2(mRig.velocity.x, jumpForce);
                Anim.SetBool("jump", true);
                playerState = PlayerState.jump;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJumpOnce = true;
            canJumpTwice = true;
        }
    }
}
