using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float charger;
    public bool discharge;
    public Rigidbody2D rb;
    private float jumpForce=10;
    public float speed = 3f;
    public float moveInput;
    private bool onGround = true;
    public Text timer;
    public Text clearTime;
    public int numOfJumps = 0;
    public Text jumps;
    public GameObject pauseMenu;
    public GameObject gameCam;
    public GameManager gameManager;
    public GameObject congrats;
    public GameObject ending;
    private Timer time;
    public bool applyRightWind = true;
    public bool applyLeftWind = false; 
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = GameObject.Find("Timer").GetComponent<Timer>();
        StartCoroutine(wind());
    }
    // Update is called once per frame
    void Update()
    {
        y = gameObject.transform.position.y;
        if (Input.GetKey(KeyCode.Space))
         {
             charger += Time.deltaTime;
         }
 
         // On release, set the boolean 'discharge' to true.
         if (Input.GetKeyUp(KeyCode.Space))
         {
            discharge = true;
            numOfJumps ++;
         }
    }
    private void FixedUpdate() {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        if (discharge){
            jumpForce = 10 * charger;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            charger = 0f;
            discharge = false;
        }
        if(applyRightWind && (y > 35.255f && y < 55f)){
            //rb.velocity = new Vector2(1f, rb.velocity.y);
            gameObject.transform.position += new Vector3(1f*Time.deltaTime, 0, 0);
        }
        if(applyLeftWind && (y > 35.255f && y < 55f)){
            //rb.velocity = new Vector2(-1f, rb.velocity.y);
            gameObject.transform.position += new Vector3(-1f*Time.deltaTime, 0, 0);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("NormalGround")){
            Debug.Log("normal ground");
            onGround = true;
            speed = 3f;
        }else if(other.collider.CompareTag("IceGround")){
            onGround = true;
            Debug.Log("on ice");
            speed = 10f;
        }else if(other.collider.CompareTag("Princess")){
            //show ending scene [change cam pos]
            gameManager.endGame = true;
            time.timerIsRunning = false;
            congrats.SetActive(true);
            StartCoroutine(wait3Sec());
        }
    }

    IEnumerator wait3Sec(){
        yield return new WaitForSeconds(3);
        congrats.SetActive(false);
        pauseMenu.SetActive(false);
        gameManager.endGame = true;
        gameCam.transform.position = new Vector3(0, 71f, -10);
        clearTime.text = timer.text;
        jumps.text = numOfJumps + " jumps";
        ending.SetActive(true);
        
    }
    IEnumerator wind(){
        yield return new WaitForSeconds(3);
        applyRightWind = false;
        applyLeftWind = true;
        yield return new WaitForSeconds(3);
        applyRightWind = true;
        applyLeftWind = false;
        StartCoroutine(wind());
    }
}
