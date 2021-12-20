using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Unity Editor Fields
    [Header("Aim")]
    [SerializeField] private float maxUpAim;
    [SerializeField] private AimView aimView;

    
    [Header("mask")]
    [SerializeField] private LayerMask mask;
    [Header("Character related")]
    [SerializeField] private float speed = 6;
    [SerializeField] private Animator leftHand;
    [SerializeField] private Animator righttHand;
    [SerializeField] private Transform NinjaFace;
    [Header("Etc")]
    [SerializeField] private GameOverView gameoverView;
    [SerializeField] private GameObject startScreen;
    #endregion

    #region Fields
    private Vector3 lookAtDirection;
    private Vector3 goTo;
    private enum Side {LEFT=180,RIGHT=0 }
    private Side side = Side.LEFT;
    private bool onTheMove = false;
    private const float maxDistanceFromWall = 0.1f;
    private bool isDead = false;
    private bool firstJump = false;
    private int coinCollect = 0;

    public bool IsDead { get => isDead; set => isDead = value; }
    public int CoinCollect { get => coinCollect; set => coinCollect = value; }
    public bool FirstJump { get => firstJump; set => firstJump = value; }
    #endregion

    #region  Enable
    private void OnEnable()
    {
        InputManager.Instance.OnStartTouch += SetMoveAction;
    }
    private void OnDisable()
    {
        InputManager.Instance.OnEndTouch -= SetMoveAction;
    }
    #endregion

    #region Actions
    private void SetMoveAction()
    {

        if (!onTheMove && startScreen.activeInHierarchy==false)
        {
            leftHand.SetBool("OnMove", true);
            righttHand.SetBool("OnMove", true);
            AudioManager.Instance.Playjump();
            onTheMove = true;
        }
    }
    #endregion

    #region Update
    private void Update()
    {
        
        if(onTheMove && !IsDead)
        {
            if (startScreen.activeInHierarchy == false)
            {
                FirstJump = true;
                MoveCharacter();
                //the move
            }
        }
    }
    private void FixedUpdate()
    {
        if (!onTheMove && !IsDead)
        {
            leftHand.SetBool("OnMove", false);
            righttHand.SetBool("OnMove", false);
            MovingIndicator();
        }
    }
    #endregion

    #region Private Methodes
    private void MoveCharacter()
    {
        if (Vector3.Distance(transform.position, goTo) < maxDistanceFromWall)
        {
            MoveDone();
        }
        transform.position = Vector3.MoveTowards(transform.position, goTo, speed * Time.deltaTime);
    }
    
    private void MoveDone()
    {
        switch(side)
        {
            case Side.LEFT:
                side = Side.RIGHT;
                transform.rotation = new Quaternion(0, (float)side, 0, 0);
                break;
            case Side.RIGHT:
                side = Side.LEFT;
                transform.rotation = new Quaternion(0, (float)side, 0, 0);
                break;

        }
        onTheMove = false;
    }

    private void MovingIndicator()
    {
        //move the indicator up and down
        RaycastHit hit;
        Vector3 vec = transform.TransformDirection(Vector3.right);
        lookAtDirection = new Vector3(vec.x, 0, 0);
        lookAtDirection = new Vector3(lookAtDirection.x, Mathf.PingPong(Time.time, maxUpAim));
        if (Physics.Raycast(transform.position, lookAtDirection, out hit,Mathf.Infinity, mask))
        {
            Debug.DrawRay(transform.position, lookAtDirection, Color.yellow);
            goTo = hit.point;
            aimView.MoveAim(goTo);
        }
        else
        {
            Debug.DrawRay(transform.position, lookAtDirection, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="DeadZone")
        {
            //get hit game over.
            if (!isDead)
            {
                AudioManager.Instance.PlayHit();
            }
            //Debug.Log("Dead");
            leftHand.SetBool("Dead", true);
            righttHand.SetBool("Dead", true);
            NinjaFace.rotation = new Quaternion(0, -180, 0, 1);
            IsDead = true;
            gameoverView.GameOver(this);
          
        }
        if(other.gameObject.tag=="Coin")
        {
            //Debug.Log("Coins");
            coinCollect++;
            //we must put it back into the pool.
            other.gameObject.SetActive(false);
            AudioManager.Instance.PickUpCoin();
        }
    }
    #endregion
}
