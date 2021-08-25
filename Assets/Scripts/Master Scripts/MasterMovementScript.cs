using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MasterMovementScript : MonoBehaviour
{
    public FocusBar healthBar;
    public FocusBar powerBar;
    public int maxPower = 100;
    public int maxhealth = 100;
    public int currentPower;
    public int currentHealth;
    public bool moving = true;
    private bool jumping = false;
    public static float acceleration = 1;
    private readonly float maxAcceleration = 2.15f;
    public static float zonePowerupMeter = 0;
    public static bool slowed = false;
    private bool invulnerable = false;
    private bool descented = false;
    public static bool descending = false;
    void Start()
    {
        currentPower = 0;
        currentHealth = 0;
        acceleration = 1;
        Time.timeScale = 1;
        slowed = false;
        moving = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,12);
        StartCoroutine(increaseAcceleration());
    }

    void Update()
    {
        //GetComponent<Animator>().speed = acceleration;
        if(GameObject.Find("PlayerCharacter").transform.position.z >= MasterGameFlow.subwayCoord-25&&!descented){
            jumping = true;
        }
        if(GameObject.Find("PlayerCharacter").transform.position.z >= MasterGameFlow.subwayCoord-2&&!descented){
            descented = true;
            descending = true;
            StartCoroutine(descent());
        }
       if(GameObject.Find("PlayerCharacter").transform.position.y !=.15f && !jumping&&!descending&&!descented){
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, .15f, this.gameObject.transform.position.z);
        }
        if(!moving&&!jumping){
        if(GameObject.Find("PlayerCharacter").transform.position.x < 4 && GameObject.Find("PlayerCharacter").transform.position.x>2)
        this.gameObject.transform.position = new Vector3(3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        else if(GameObject.Find("PlayerCharacter").transform.position.x < 8 && GameObject.Find("PlayerCharacter").transform.position.x>6)
        this.gameObject.transform.position = new Vector3(7, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        else if(GameObject.Find("PlayerCharacter").transform.position.x < 0 && GameObject.Find("PlayerCharacter").transform.position.x>-2)
        this.gameObject.transform.position = new Vector3(-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        
        if (Input.GetKey("a") && !(GameObject.Find("PlayerCharacter").transform.position.x < -.2)&& !moving){
            moving = true;
            GetComponent<Rigidbody>().velocity = new Vector3(-8*acceleration,this.GetComponent<Rigidbody>().velocity.y,12*acceleration);
            StartCoroutine(stopLaneCh());
            GetComponent<Animator>().Play("player_slide_left");
           
           
        }
         if (Input.GetKey("d") && !(GameObject.Find("PlayerCharacter").transform.position.x > 6.8)&& !moving){
            moving = true;
            GetComponent<Rigidbody>().velocity = new Vector3(8*acceleration,this.GetComponent<Rigidbody>().velocity.y,12*acceleration);
            StartCoroutine(stopLaneCh());
             GetComponent<Animator>().Play("player_slide_right_001");
           
        }
         if (Input.GetKey("space")&&!jumping){
            jumping = true;
            GetComponent<Animator>().Play("player_jump_start");
            GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x,6*acceleration,12*acceleration);
            
            StartCoroutine(stopJump());

        }
        if(Input.GetKeyDown("q")&& zonePowerupMeter>99 && !slowed&&!jumping){
            slowed = true;
            zonePowerupMeter=0;
            Time.timeScale = .3f;
            StartCoroutine(scaleTimeBack());
            
            
        }




    }
        void TakePower(int powerUse)
        {
            currentPower -= powerUse;
            powerBar.SetPower(currentPower);
        }
        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        void GetHealth(int life)
        {
            currentHealth += life;
            healthBar.SetHealth(currentHealth);
        }
        void GetPower(int powerUse)
        {
            currentPower += powerUse;
            powerBar.SetPower(currentPower);
        }

    IEnumerator stopJump(){
            GetComponent<Animator>().Play("player_jump_hold");
            yield return new WaitForSeconds(.5f/acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x,-6*acceleration,12*acceleration);
            yield return new WaitForSeconds(.5f/acceleration);
            GetComponent<Animator>().Play("player_jump_end");
            GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x,0,12*acceleration);
            jumping = false;
        }

        IEnumerator stopLaneCh(){
            yield return new WaitForSeconds(.5f/acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0,this.GetComponent<Rigidbody>().velocity.y,12*acceleration);
             moving = false;
        }        
        IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonePowerup")
        {

            GetPower(25);
            if (zonePowerupMeter!<= 100){
            zonePowerupMeter+=25;
            if(zonePowerupMeter > 100){
                zonePowerupMeter = 100;
            }
            }
            Destroy(other.gameObject);
        } else  
        if (other.tag == "InvPowerup")
        {
            GetHealth(25);
            StartCoroutine(invulnerableState());
            Destroy(other.gameObject);
        } else 
        if (other.tag == "Obstacle" || other.tag == "BusinessPerson")
        {
            TakeDamage(40);
            if (!invulnerable){
            acceleration = 0;
            GetComponent<Animator>().Play("player_crash_001");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(1);
            MasterGameFlow.gameOver = true;
            MasterScoreManager.scoreCount = 0;
            } else{
                StartCoroutine(blastOffObject(other));
                
            
        }
        } else 
        if(other.tag == "Cat")
        {
             if(!invulnerable){
                if(MasterScoreManager.focusCount >= 20){
                MasterScoreManager.focusCount-= 15;
                zonePowerupMeter = 0;
                } else {
                acceleration = 1.0f;
                MasterScoreManager.scoreCount = 0;
                MasterScoreManager.focusCount = 0;
                zonePowerupMeter = 0;
                SceneManager.LoadScene("Scenes/Master");
                }
            } else{
                StartCoroutine(blastOffObject(other));
                
            }
        }
        
        }
    

    private IEnumerator descent(){
        moving = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0,-8, 12)*acceleration;
        yield return new WaitForSeconds(1.07f/acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0, 12*acceleration);
        descending = false;
        jumping = false;
        moving = false;
    }
    private IEnumerator blastOffObject(Collider other){
        for(int i = 0; i <8; i++){
            other.GetComponent<Transform>().position = new Vector3(other.transform.position.x+6,other.transform.position.y,other.transform.position.z+5);
            yield return new WaitForSeconds(.1f);
        }
        Destroy(other);
        yield return null;
    }
    IEnumerator increaseAcceleration(){
        if(acceleration!<maxAcceleration){
        yield return new WaitForSeconds(2.25f);
        
        acceleration*=1.06f;
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x,this.GetComponent<Rigidbody>().velocity.y,12*acceleration);

        }
        yield return new WaitForSeconds(2.25f);
        StartCoroutine(increaseAcceleration());
    }

    IEnumerator invulnerableState(){
        invulnerable = true;
        yield return new WaitForSeconds(10);
        invulnerable = false;
    }
    IEnumerator scaleTimeBack(){
    yield return new WaitForSecondsRealtime(6);
    Time.timeScale = 1;
    slowed = false;
}
}
