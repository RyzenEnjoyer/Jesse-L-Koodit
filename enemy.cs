using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //[SerializeField] private PlayerHealthAndScore playerStats;
    [SerializeField] private int enemyDamage;
    private Rigidbody2D rb;

    [SerializeField] private bool canMove;
    [SerializeField] private int moveSpeed;
    private int moveDirection = -1;


    [SerializeField] private Transform wallCheckPoint;    // piste joka osuu sein‰‰n
    [SerializeField] private float wallCheckRadius;       // sein‰nkosketuksen s‰de
    [SerializeField] private LayerMask whatIsWall;        // mik‰ on sein‰‰
    private bool touchingWall;

    private bool moveRight = false;

    private bool atEdge;
    [SerializeField] private Transform edgeCheck;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        touchingWall = Physics2D.OverlapCircle(wallCheckPoint.position, wallCheckRadius, whatIsWall);

        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (touchingWall || !atEdge)
        {
            moveRight = !moveRight;
            moveDirection *= -1;
        }

        if (canMove)
        {
            if (moveRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<PlayerHealthAndScore>())
    //    {
    //        playerStats = collision.gameObject.GetComponent<PlayerHealthAndScore>();
    //        //DamagePlayer(enemyDamage);
    //        playerStats.RemoveHealth(enemyDamage);
    //    }
    //}
    //IEnumerator DamagePlayer(int damage)
    //{
    //    playerStats.RemoveHealth(damage);
    //    yield return new WaitForSeconds(1);
    //}
}