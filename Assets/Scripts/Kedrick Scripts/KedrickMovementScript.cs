using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class KedrickMovementScript : MonoBehaviour
{
    public FocusBar healthBar;
    public FocusBar powerBar;
    public float maxPower = 100;
    public float maxHealth = 100;
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
    public static bool RewardedAdWatched;
    public AdsManager ads;
    public KedrickGameFlow gameManager;
    [SerializeField] ParticleSystem LightningParticles = null;
    [SerializeField] ParticleSystem PowerUpParticles = null;
   // public Transform shield;
   

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

        if (GameObject.Find("PlayerCharacter 1").transform.position.z < KedrickGameFlow.courtCoord)
        {
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
            GetComponent<Animator>().speed = acceleration;
            if (KedrickGameFlow.currentScene == "Penn Station" && ascented && !jumping)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
            }
            if ((GameObject.Find("PlayerCharacter 1").transform.position.z > KedrickGameFlow.pennStationExitCoord || GameObject.Find("PlayerCharacter 1").transform.position.z < KedrickGameFlow.subwayExitCoord) && !jumping && !ascending && !descending && GameObject.Find("PlayerCharacter 1").transform.position.z < KedrickGameFlow.subwayCoord - 4 && ascented && KedrickGameFlow.currentScene != "Penn Station")
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, .2f, this.gameObject.transform.position.z);
            }
            if (GameObject.Find("PlayerCharacter 1").transform.position.z >= KedrickGameFlow.subwayCoord - 2 && !descented && KedrickGameFlow.currentScene == "Subway")
            {
                descented = true;
                descending = true;
                StartCoroutine(descent());
                jumping = false;
                GetComponent<Animator>().SetBool("Jumping", false);
            }
            if (GameObject.Find("PlayerCharacter 1").transform.position.z >= KedrickGameFlow.subwayExitCoord - 15 && !ascented)
            {

                StartCoroutine(ascent());
            }
            if (GameObject.Find("PlayerCharacter 1").transform.position.y != 0 && !jumping && descented && !descending && !ascented && !ascending)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -8.58f, this.gameObject.transform.position.z);
            }
            if (!moving && !jumping)
            {
                if (GameObject.Find("PlayerCharacter 1").transform.position.x < 5 && GameObject.Find("PlayerCharacter 1").transform.position.x > 1)
                    this.gameObject.transform.position = new Vector3(3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                else if (GameObject.Find("PlayerCharacter 1").transform.position.x < 9 && GameObject.Find("PlayerCharacter 1").transform.position.x > 6)
                    this.gameObject.transform.position = new Vector3(7, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                else if (GameObject.Find("PlayerCharacter 1").transform.position.x < 0 && GameObject.Find("PlayerCharacter 1").transform.position.x > -3)
                    this.gameObject.transform.position = new Vector3(-1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }




            if (SwipeManager.swipeLeft && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4) && !moving)
            {

                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChL());
                GetComponent<Animator>().Play("player_slide_left");
            }
             if (SwipeManager.swipeRight && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4) && !moving)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChR());
                GetComponent<Animator>().Play("player_slide_right_crossover");
            }
             if (SwipeManager.swipeRight && !(GameObject.Find("PlayerCharacter 1").transform.position.x > -4) && !moving)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChR());
                GetComponent<Animator>().Play("player_slide_right");
            }



            if (SwipeManager.swipeRight && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8) && !moving)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChR());
                GetComponent<Animator>().Play("player_slide_right");

            }
             if (SwipeManager.swipeLeft && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8) && !moving)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChL());
                GetComponent<Animator>().Play("player_slide_left_crossover");
            }
             if (SwipeManager.swipeLeft && !(GameObject.Find("PlayerCharacter 1").transform.position.x < 6.8) && !moving)
            {
                moving = true;
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * acceleration, this.GetComponent<Rigidbody>().velocity.y, 12 * acceleration);
                Debug.Log(moving);
                StartCoroutine(stopLaneChL());
                GetComponent<Animator>().Play("player_slide_left");
            }

             if (SwipeManager.swipeUp && !jumping && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {

                jumping = true;
                GetComponent<Animator>().Play("player_jump_start_1");
                GetComponent<Animator>().SetBool("Jumping", true);
                GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 6 * acceleration, 12 * acceleration);
                Debug.Log(moving);

                StartCoroutine(stopJumpRight());

            }


             if (SwipeManager.swipeUp && !jumping && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                jumping = true;
                GetComponent<Animator>().Play("player_jump_start");
                GetComponent<Animator>().SetBool("Jumping", true);
                GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 6 * acceleration, 12 * acceleration);
                Debug.Log(moving);

                StartCoroutine(stopJumpLeft());

            }
             if (SwipeManager.doubleTap && zonePowerupMeter > 99 && !slowed && !jumping)
            {
                
                Handheld.Vibrate();
                PowerUp();
                slowed = true;
                zonePowerupMeter = 0;
                Time.timeScale = .3f;
                StartCoroutine(scaleTimeBack());


            }

        } 
        else
        {
            
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().Play("player_idle_001");
            
        }
    }





    




    void SetMaxPower()
    {
        currentPower = 100;
        powerBar.SetPower(currentPower);
    }
    void TakePower(float powerUse)
    {
        currentPower -= powerUse;
        powerBar.SetPower(currentPower);
    }
    void TakeDamage(float damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
    void GetHealth(float life)
    {
        currentHealth += life;
        healthBar.SetHealth(currentHealth);
    }
    void SetMaxHealth()
    {
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
    }
    void SetHealth(float life)
    {
        currentHealth = life;
        healthBar.SetHealth(life);
    }
    void GetPower(float powerUse)
    {
        currentPower += powerUse;
        powerBar.SetPower(currentPower);
    }


    void SetPower(float power)
    {
        currentPower = power;
        powerBar.SetPower(power);
    }

    IEnumerator stopJumpLeft()
    {
        GetComponent<Animator>().Play("player_jump_hold_1");
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, -6 * acceleration, 12 * acceleration);
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Animator>().Play("player_jump_end_1");
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0, 12 * acceleration);
        jumping = false;
    }
    IEnumerator stopJumpRight()
    {
        GetComponent<Animator>().Play("player_jump_hold");
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, -6 * acceleration, 12 * acceleration);
        yield return new WaitForSeconds(.5f / acceleration);
        GetComponent<Animator>().Play("player_jump_end");
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0, 12 * acceleration);
        jumping = false;
    }

    IEnumerator stopLaneChR()
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
    IEnumerator stopLaneChL()
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

        IEnumerator OnTriggerEnter(Collider other)
        {

            if (other.tag == "ZonePowerup")
            {
                
                GetPower(25);
                TakeDamage(0);
                if (currentPower > 100)
                {
                    SetMaxPower();
                }

            Destroy(other.gameObject);
        }



            else if (other.tag == "InvPowerup")
            {
                 Invincible();
                GetHealth(25);
                if (currentHealth > 100)
                {
                    SetMaxHealth();
                }
            Destroy(other.gameObject);

            StartCoroutine(invulnerableState());

            }

            else if (other.tag == "Cat" || other.tag == "Rat" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                GetComponent<Animator>().Play("TripLeft");
                Handheld.Vibrate();
                
                if(!invulnerable)
                {
                TakeDamage(25);
                }

                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");

                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }

            else if (other.tag == "Cat" || other.tag == "Rat" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                GetComponent<Animator>().Play("TripRight");
                Handheld.Vibrate();
                if(!invulnerable)
                {
                
                TakeDamage(25);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");

                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }
            else if (other.tag == "person" || other.tag == "IcyCart" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                Handheld.Vibrate();
                 if(!invulnerable)
                {
                TakeDamage(75);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");
                    Handheld.Vibrate();
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);




                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;

                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }
            else if (other.tag == "person" || other.tag == "IcyCart" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                Handheld.Vibrate();
                 if(!invulnerable)
                {
                TakeDamage(75);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");
                    Handheld.Vibrate();
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);




                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;

                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }
        




            else if (other.tag == "InstaDeath" || other.tag == "Horse" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                Handheld.Vibrate();
                 if(!invulnerable)
                {
                
                     
                TakeDamage(101);
                }
                if (!invulnerable)
                {
                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");

                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                    yield return new WaitForSeconds(2);
                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }
            else if (other.tag == "InstaDeath" || other.tag == "Horse" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                Handheld.Vibrate();
                 if(!invulnerable)
                {
                
                     
                TakeDamage(101);
                }
                if (!invulnerable)
                {
                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");

                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                    yield return new WaitForSeconds(2);
                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));


                }
            }
            else if (other.tag == "pidgeon" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                Handheld.Vibrate();
                if(!invulnerable)
                {
                
                     
                TakeDamage(20);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));
                }
            }
            else if (other.tag == "pidgeon" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                Handheld.Vibrate();
                 if(!invulnerable)
                {
                
                     
                TakeDamage(20);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));
                }
            }



            else if (other.tag == "Sign" || other.tag == "Store Cellar" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                Handheld.Vibrate();
                if(!invulnerable)
                {
                
                     
                TakeDamage(50);
                }
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                else
                {
                    StartCoroutine(blastOffObject(other));
                }
            }
            else if (other.tag == "Sign" || other.tag == "Store Cellar" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                Handheld.Vibrate();
                TakeDamage(50);
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                StartCoroutine(blastOffObject(other));
            }




            else if (other.tag == "Garbage" && !(GameObject.Find("PlayerCharacter 1").transform.position.x > 6.8))
            {
                Handheld.Vibrate();
                TakeDamage(90);
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash_1");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                StartCoroutine(blastOffObject(other));
            }

            else if (other.tag == "Garbage" && !(GameObject.Find("PlayerCharacter 1").transform.position.x < -4))
            {
                Handheld.Vibrate();
                TakeDamage(90);
                if (!invulnerable && currentHealth <= 0)
                {

                    acceleration = 0;
                    GetComponent<Animator>().Play("player_crash");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                    yield return new WaitForSeconds(2);

                    KedrickGameFlow.gameOver = true;
                    ScoreManager.scoreCount = 0;
                }
                StartCoroutine(blastOffObject(other));
            }




        


        }


        private IEnumerator descent()
        {
            moving = true;
            if (GameObject.Find("PlayerCharacter 1").transform.position.x != 3)
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

            if (GameObject.Find("PlayerCharacter 1").transform.position.y != 0)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -8.58f, this.gameObject.transform.position.z);
            }
        }
        private IEnumerator ascent()
        {
            moving = true;
            if (GameObject.Find("PlayerCharacter 1").transform.position.x != 3)
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
            KedrickGameFlow.subwayCoord = 100000000000000f;
            KedrickGameFlow.subwayExitCoord = 10000000000000f;
            if (GameObject.Find("PlayerCharacter 1").transform.position.y != 0)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
            }
        }

        private IEnumerator blastOffObject(Collider other)
        {
            for (int i = 0; i < 8; i++)
            {
                if (other != null)
                {
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
            GetComponent<Animator>().Play("player_crash_1");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



                yield return new WaitForSeconds(1);

                KedrickGameFlow.gameOver = true;
                ScoreManager.scoreCount = 0;
            }
        }


        public static void OnRewardedAdSuccess()
        {
            RewardedAdWatched = true;

            Debug.Log("it reached");
        }
   

    public void Invincible()
    {
        LightningParticles.Play();
    }
    public void PowerUp()
    {
        PowerUpParticles.Play();
    }
}
    

