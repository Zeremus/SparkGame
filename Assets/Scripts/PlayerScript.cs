using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public bool canMove = true;
    private Rigidbody2D playerRB;
    public Transform firePoint;
    public GameObject fireBallPrefab;
    public GameObject empoweredFireBallPrefab;
    private Animator playerAnim;
    public float speed = 4.0f;
    public bool isFacingRight = true;
    public bool canFire;
    public float fireRate = 1.0f;
    public float nextAttack;
    public int life = 5;
    public bool isGrounded = true;
    public float jumpPower = 5;
    private bool isInvulnerable;
    public AudioSource walk;
    public AudioSource jump;
    public AudioSource fire;
    public AudioSource takeDamage;
    public bool hasLetter;
    public int totalLetters;
    private int letterH;
    private int letterE;
    private int letterR;
    private int letterO;
    public bool isEmpowered = false;
    
    void Start()
    { 
        // To assure the player does not have any letters he is not supposed to by loading a game on a earlier level
        int x = SceneManager.GetActiveScene().buildIndex;
        if(x == 1)
        {
            PlayerPrefs.SetInt("letterH", 0);
            PlayerPrefs.SetInt("letterE", 0);
            PlayerPrefs.SetInt("letterR", 0);
            PlayerPrefs.SetInt("letterO", 0);
            PlayerPrefs.Save();
        }
        if(x == 2)
        {
            PlayerPrefs.SetInt("letterE", 0);
            PlayerPrefs.SetInt("letterR", 0);
            PlayerPrefs.SetInt("letterO", 0);
            PlayerPrefs.Save();
        }
        if(x == 3)
        {
            PlayerPrefs.SetInt("letterR", 0);
            PlayerPrefs.SetInt("letterO", 0);
            PlayerPrefs.Save();
        }
        if(x == 4)
        {
            PlayerPrefs.SetInt("letterO", 0);
            PlayerPrefs.Save();
        }
        letterH = PlayerPrefs.GetInt("letterH", 0);
        letterE = PlayerPrefs.GetInt("letterE", 0);
        letterR = PlayerPrefs.GetInt("letterR", 0);
        letterO = PlayerPrefs.GetInt("letterO", 0);
        // Check if the player has all the letters and if so empowers him
        totalLetters = letterH + letterE + letterR + letterO;
        if(totalLetters == 4) isEmpowered = true;
        hasLetter = false;
        isInvulnerable = false;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(life > 0)
        {
            if (life > 5) life = 5;

            if(canMove)
            {
                var movement = Input.GetAxisRaw("Horizontal");
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime *speed;
                if(Input.GetAxis("Horizontal") != 0 && isGrounded)
                {
                    if(!walk.isPlaying) walk.Play();
                } else if (Input.GetAxis("Horizontal") == 0)
                {
                    walk.Stop();
                }

                if(Input.GetKey(KeyCode.D))
                {
                    playerAnim.SetBool("isWalking", true);
                }
                else if(Input.GetKey(KeyCode.A))
                {
                    playerAnim.SetBool("isWalking", true);
                }
                else playerAnim.SetBool("isWalking", false);

                if(Input.GetKeyDown(KeyCode.W) && isGrounded)
                {
                    playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                    playerAnim.SetBool("isJumping", true);
                    jump.Play();
                } 
            }

            if(Time.timeSinceLevelLoad > nextAttack) canFire = true;

            if(canFire)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(isGrounded) canMove = false;
                    if(isEmpowered == false)
                    {
                        GameObject newFireBall = Instantiate(fireBallPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    }else if (isEmpowered)
                    {
                        GameObject newFireBall = Instantiate(empoweredFireBallPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    }
                 
                    playerAnim.SetBool("isAttacking", true);
                    Invoke("NotAttacking", 0.3f);
                    nextAttack = Time.timeSinceLevelLoad + fireRate;
                    canFire = false;
                    fire.Play();
                }
            }
            
            if(Input.GetKeyDown(KeyCode.A) && isFacingRight)
            {
                FlipLeft();
            }
            if(Input.GetKeyDown(KeyCode.D) && !isFacingRight)
            {
                FlipRight();
            }
        } 

        if(life <= 0) 
        {
            playerAnim.SetBool("isDead", true);
            GetComponent<CapsuleCollider2D>().enabled = false;
            FreezePlayer();
            gameOverCanvas.SetActive(true);
        }

        if(life >= 1) image1.SetActive(true); else image1.SetActive(false);
        if(life >= 2) image2.SetActive(true); else image2.SetActive(false);
        if(life >= 3) image3.SetActive(true); else image3.SetActive(false);
        if(life >= 4) image4.SetActive(true); else image4.SetActive(false);
        if(life >= 5) image5.SetActive(true); else image5.SetActive(false);  
        
    }
    void NotAttacking()
    {
        UnfreezePlayer();
        playerAnim.SetBool("isAttacking", false);
        canMove = true;
    }

    void FlipLeft()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
        isFacingRight = false;
    }
    void FlipRight()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
        isFacingRight = true;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(!isInvulnerable)
        {
            if(col.gameObject.tag == "Enemy")
            {
                canMove = false;
                isInvulnerable = true;
                FreezePlayer();
                Invoke("UnfreezePlayer", 0.5f);
                Invoke("Vulnerable", 1f);
                playerAnim.SetBool("isHit", true);
                life--;
                takeDamage.Play();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            if(isGrounded) playerAnim.SetBool("isJumping", false);
        }
    }

    void DisableRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void Vulnerable()
    {
        if(life >= 1)
        {
            isInvulnerable = false;
        }
    }
    void FreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;  
    }
    void UnfreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerAnim.SetBool("isHit", false);
        canMove = true;
    }
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "MagicAttack")
        {
            if(!isInvulnerable)
            {
                canMove = false;
                isInvulnerable = true;
                FreezePlayer();
                Invoke("UnfreezePlayer", 0.5f);
                Invoke("Vulnerable", 1f);
                playerAnim.SetBool("isHit", true);
                life--;
                takeDamage.Play();
            }
        }
    }
}
