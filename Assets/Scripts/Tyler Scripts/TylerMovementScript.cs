using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TylerMovementScript : MonoBehaviour
{
    public TylerFocusBar healthBar;
    public TylerFocusBar powerBar;
    public int maxPower = 100;
    public int maxHealth = 100;
    public static float currentPower;
    public static float currentHealth;
    public static float acceleration = 1;
    private readonly float maxAcceleration = 2.15f;
    public static float zonePowerupMeter = 0;
    public bool moving = true;
    public bool jumping = false;
    public static bool slowed = false;
    public bool invulnerable = false;
    public static bool descented = false;
    public static bool descending = false;
    public static bool ascented = true;
    public static bool ascending = false;
    void Start()
    {
        currentPower = 0;
        currentHealth = 0;
        acceleration = 1;
        Time.timeScale = 1;
        slowed = false;
        moving = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12);
        StartCoroutine(increaseAcceleration());
    }

    void Update()
    {
        if(GameObject.Find("PlayerCharacter").transform.position.z <TylerGameFlow.courtCoord){
        StartCoroutine(checkHealth());
        if (currentHealth! < maxHealth)
        {
            currentHealth += (Time.deltaTime) / 2;
            healthBar.SetHealth(currentHealth);
        }
        if (currentPower! <= 100)
        {
            currentPower += (10 * Time.deltaTime * acceleration) / 15;
            powerBar.SetPower(currentPower);
        }
        //GetComponent<Animator>().speed = acceleration;
        if(TylerGameFlow.currentScene=="Penn Station" &&ascented&&!jumping){
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
        }
        if((GameObject.Find("PlayerCharacter").transform.position.z > TylerGameFlow.pennStationExitCoord||GameObject.Find("PlayerCharacter").transform.position.z < TylerGameFlow.subwayExitCoord)&&!jumping&&!ascending&&!descending&&GameObject.Find("PlayerCharacter").transform.position.z < TylerGameFlow.subwayCoord-4&&ascented&&TylerGameFlow.currentScene!="Penn Station"){
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, .2f, this.gameObject.transform.position.z);
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= TylerGameFlow.subwayCoord - 2 && !descented&& TylerGameFlow.currentScene == "Subway")
        {
            descented = true;
            descending = true;
            StartCoroutine(descent());
            jumping = false;
            GetComponent<Animator>().SetBool("Jumping", false);
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= TylerGameFlow.subwayExitCoord - 15 && !ascented)
        {
            
            StartCoroutine(ascent());
        }
                if (GameObject.Find("PlayerCharacter").transform.position.y != 0 && !jumping && descented&&!descending&&!ascented&&!ascending)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -8.58f, this.gameObject.transform.position.z);
        }
        if (!moving && !jumping)
        {
            if (GameObject.Find("PlayerCharacter").transform.position.x < 5 && GameObject.Find("PlayerCharacter").transform.position.x > 1)
                this.gameObject.transform.position = new Vector3(3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            else if (GameObject.Find("PlayerCharacter").transform.position.x < 9 && GameObject.Find("PlayerCharacter").transform.position.x > 6)
                this.gameObject.transform.position = new Vector3(7, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            else if (GameObject.Find("PlayerCharacter").transform.position.x < 0 && GameObject.Find("PlayerCharacter").transform.position.x > -3)
                this.gameObject.transform.position = new Vector3(-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }


        if (Input.GetKey("a") && !(GameObject.Find("PlayerCharacter").transform.position.x < -.2) && !moving)
        {
            if (slowed)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(-12 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                StartCoroutine(stopLaneCh());
                GetComponent<Animator>().Play("player_slide_left");
            }
            else
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                StartCoroutine(stopLaneCh());
                GetComponent<Animator>().Play("player_slide_left");
            }

        }
        if (Input.GetKey("d") && !(GameObject.Find("PlayerCharacter").transform.position.x > 6.8) && !moving)
        {
            if (slowed)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(12 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                StartCoroutine(stopLaneCh());
                GetComponent<Animator>().Play("player_slide_right_001");
            }
            else
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                StartCoroutine(stopLaneCh());
                GetComponent<Animator>().Play("player_slide_right_001");
            }
        }
        if (Input.GetKey("space") && !jumping)
        {
            jumping = true;
            GetComponent<Animator>().Play("player_jump_start_L");
            GetComponent<Animator>().SetBool("Jumping", true);
            GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 6 * acceleration, 12 * acceleration);

            StartCoroutine(stopJump());

        }
        if (Input.GetKeyDown("q") && currentPower > 99 && !slowed && !jumping)
        {
            slowed = true;
            TakePower(100);
            Time.timeScale = .3f;
            StartCoroutine(scaleTimeBack());


        }
        }else {
             GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
             GetComponent<Animator>().Play("player_idle_001");
        }

    }

    void SetMaxPower()
    {
        currentPower = 100;
        powerBar.SetPower(currentPower);
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


    void SetPower(float power)
    {
        currentPower = power;
        powerBar.SetPower(power);
    }
    IEnumerator stopJump()
    {
        GetComponent<Animator>().Play("player_jump_hold_L");
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, -6 * acceleration, 12 * acceleration);
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Animator>().Play("player_jump_end_L");
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0, 12 * acceleration);
        jumping = false;
    }

    IEnumerator stopLaneCh()
    {
        if (slowed)
        {
            yield return new WaitForSeconds(.33333333f / acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
            moving = false;
        }
        else
        {
            yield return new WaitForSeconds(.5f / acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
            moving = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonePowerup")
        {
            GetPower(25);
            if (currentPower > 100)
            {
                SetMaxPower();
            }

            Destroy(other.gameObject);
        }
        else
        if (other.tag == "InvPowerup")
        {
            StartCoroutine(invulnerableState());
            Destroy(other.gameObject);
        }
        else
        if (other.tag == "Obstacle" || other.tag == "BusinessPerson" || other.tag == "Horse")
        {
            if (!invulnerable)
            {
                TakeDamage(101);
            }
            else
            {
                StartCoroutine(blastOffObject(other));
            }
        }
        else
        if (other.tag == "Cat" || other.tag == "Rat"|| other.tag == "Pigeon")
        {

            if (!invulnerable)
            {
                TakeDamage(25);
            }
            else
            {
                StartCoroutine(blastOffObject(other));
            }

        }

    }


    private IEnumerator descent()
    {
        moving = true;
        if (GameObject.Find("PlayerCharacter").transform.position.x != 3)
        {
            this.gameObject.transform.position = new Vector3(3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        GetComponent<Rigidbody>().velocity = new Vector3(0, -8.73f, 12) * acceleration;
        yield return new WaitForSeconds(1 / acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12 * acceleration);
        descending = false;
        jumping = false;
        moving = false;
        ascented = false;
        
        if (GameObject.Find("PlayerCharacter").transform.position.y != 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -8.58f, this.gameObject.transform.position.z);
        }
    }
    private IEnumerator ascent()
    {
        moving = true;
        if (GameObject.Find("PlayerCharacter").transform.position.x != 3)
        {
            this.gameObject.transform.position = new Vector3(3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        GetComponent<Rigidbody>().velocity = new Vector3(0, 8.8f, 12) * acceleration;
        yield return new WaitForSeconds(.1f);
        ascending = true;
        yield return new WaitForSeconds(1 / acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12 * acceleration);
        ascending = false;
        jumping = false;
        moving = false;
        descented = false;
        ascented = true;
        TylerGameFlow.subwayCoord = 100000000000000f;
        TylerGameFlow.subwayExitCoord = 10000000000000f;
        if (GameObject.Find("PlayerCharacter").transform.position.y != 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
        }
    }

    private IEnumerator blastOffObject(Collider other)
    {
        for (int i = 0; i < 8; i++)
        {
            if(other!=null){
            other.GetComponent<Transform>().position = new Vector3(other.transform.position.x + 6, other.transform.position.y, other.transform.position.z + 5);
            yield return new WaitForSeconds(.1f);
            }
        }
        yield return null;
    }
    IEnumerator increaseAcceleration()
    {
        if (acceleration! < maxAcceleration)
        {
            yield return new WaitForSeconds(2.25f);

            acceleration *= 1.06f;
            GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);

        }
        yield return new WaitForSeconds(2.25f);
        StartCoroutine(increaseAcceleration());
    }

    IEnumerator invulnerableState()
    {
        invulnerable = true;
        yield return new WaitForSeconds(10);
        invulnerable = false;
    }
    IEnumerator scaleTimeBack()
    {
        yield return new WaitForSecondsRealtime(8);
        Time.timeScale = 1;
        slowed = false;
    }
    IEnumerator checkHealth()
    {
        yield return new WaitForSeconds(.25f);
        if (currentHealth < 0)
        {
            acceleration = 0;
            GetComponent<Animator>().Play("player_crash_L");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



            yield return new WaitForSeconds(1);

            TylerGameFlow.gameOver = true;
            ScoreManager.scoreCount = 0;
        }
    }

}
