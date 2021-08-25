using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KedrickObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform businessPersonObj;
    public Transform catObj;
    public Transform ratObj;
    public Transform horseObj;
    public Transform pigeonObj;
    public Transform carriageObj;
    public Transform carObj;
    private bool pigeonMoving = false;
    private bool catMoving = false;
    private bool ratMoving = false;
    private bool moving = false;
    private bool horseMoving = false;
    private bool carriageMoving = false;
    private bool carMoving = false;
    private int randX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (this.tag == "person" && this.transform.position.z > 0 && !moving)
        {
            if (this.transform.position.z - 70 <= GameObject.Find("PlayerCharacter 1").transform.position.z)
            {
                StartCoroutine(personMove());
            }
        }
        else if (this.tag == "Cat" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 30 >= this.transform.position.z && !catMoving)
            {
                catMoving = true;
                StartCoroutine(catMove());
            }
        }
        else if (this.tag == "Rat" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 25 >= this.transform.position.z && !ratMoving)
            {
                ratMoving = true;
                StartCoroutine(ratMove());
            }
        }
        else if (this.tag == "Horse" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 30 >= this.transform.position.z && !horseMoving)
                StartCoroutine(horseMove());
        }
        else if (this.tag == "Pigeon" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 25 >= this.transform.position.z && !pigeonMoving)
            {
                pigeonMoving = true;
                StartCoroutine(pigeonMove());
            }
        }
        else if (this.tag == "Carriage" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 30 >= this.transform.position.z && !carriageMoving)
                carriageMoving = true;
            StartCoroutine(carriageMove());
        }
        else if (this.tag == "Car" && this.transform.position.z > 0)
        {
            if (GameObject.Find("PlayerCharacter 1").transform.position.z + 30 >= this.transform.position.z && !carMoving)
                carMoving = true;
            StartCoroutine(carMove());
        }
    }


    private IEnumerator ratMove()
    {
        if (this.transform.position.x == 7)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-8 * KedrickMovementScript.acceleration, 0, 0);
            yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else if (this.transform.position.x == -1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(8 * KedrickMovementScript.acceleration, 0, 0);
            yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            randX = Random.Range(1, 3);
            if (randX == 1)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * KedrickMovementScript.acceleration, 0, 0);
                yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(8 * KedrickMovementScript.acceleration, 0, 0);
                yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
    private IEnumerator catMove()
    {
        if (this.transform.position.x == 7)
        {
            this.GetComponent<Animator>().Play("cat_jump_001");
            GetComponent<Rigidbody>().velocity = new Vector3(-8.19f, -2.8f, 0);
            yield return new WaitForSeconds(.5f);
            this.GetComponent<Animator>().Play("cat_walk");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -8 * KedrickMovementScript.acceleration);
            yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);
        }
        else
        {
            this.GetComponent<Animator>().Play("cat_jump_001");
            GetComponent<Rigidbody>().velocity = new Vector3(8.21f, -2.8f, 0);
            yield return new WaitForSeconds(.5f);
            this.GetComponent<Animator>().Play("cat_walk");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -8 * KedrickMovementScript.acceleration);
            yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator personMove()
    {
        if (!moving)
        {
            GetComponentInChildren<Animator>().speed = KedrickMovementScript.acceleration;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -9 * KedrickMovementScript.acceleration);
            if (GameObject.Find("PlayerCharacter 1").transform.position.z > 4000 && !moving)
            {
                if (Random.Range(0, 3) == 0)
                {
                    moving = true;
                    yield return new WaitForSeconds(Random.Range(.5f, 1));
                    if (this.transform.position.x == 7)
                    {
                        GetComponent<Rigidbody>().velocity = new Vector3(-8 * KedrickMovementScript.acceleration, 0, -9 * KedrickMovementScript.acceleration);
                        yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                    }
                    else if (this.transform.position.x == -1)
                    {
                        GetComponent<Rigidbody>().velocity = new Vector3(8 * KedrickMovementScript.acceleration, 0, -9 * KedrickMovementScript.acceleration);
                        yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                    }
                    else if (Random.Range(1, 3) % 2 == 0 && this.transform.position.x == 4)
                    {
                        GetComponent<Rigidbody>().velocity = new Vector3(-8 * KedrickMovementScript.acceleration, 0, -9 * KedrickMovementScript.acceleration);
                        yield return new WaitForSeconds(2 / KedrickMovementScript.acceleration);
                    }
                    else if (this.transform.position.x == 4)
                    {
                        GetComponent<Rigidbody>().velocity = new Vector3(8 * KedrickMovementScript.acceleration, 0, -9 * KedrickMovementScript.acceleration);
                        yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                    }
                }
            }
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -9 * KedrickMovementScript.acceleration);
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator horseMove()
    {
        if (!horseMoving)
        {
            horseMoving = true;
            if (this.transform.position.x == -3)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(8 * KedrickMovementScript.acceleration, 0, 0);
                this.GetComponent<Animator>().Play("horse_trot");
                yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-8 * KedrickMovementScript.acceleration, 0, 0);
                this.GetComponent<Animator>().Play("horse_trot");
                yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(5 / KedrickMovementScript.acceleration);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator pigeonMove()
    {
        if (Random.Range(1, 3) % 2 == 0)
        {

            pigeonMoving = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5 * KedrickMovementScript.acceleration, 0);
            this.GetComponent<Animator>().Play("bird_liftoff_001");
            yield return new WaitForSeconds(.25f / KedrickMovementScript.acceleration);
            this.GetComponent<Animator>().Play("bird_fly");
            yield return new WaitForSeconds(.5f / KedrickMovementScript.acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        }
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    private IEnumerator carriageMove()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -7);
        this.transform.GetChild(0).GetComponent<Animator>().Play("horse_trot");
        yield return new WaitForSeconds(11);
        Destroy(this.gameObject);
    }

    private IEnumerator carMove()
    {
        if (this.transform.position.x == 19)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -6);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
        }
        yield return new WaitForSeconds(50);
        Destroy(this.gameObject);
    }
}


