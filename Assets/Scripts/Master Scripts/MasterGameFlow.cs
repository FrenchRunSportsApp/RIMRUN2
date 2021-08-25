using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class MasterGameFlow : MonoBehaviour
{
public GameObject gameOverPanel;
public Transform tile1Obj;
public Transform subwayEnterance;
public Transform pennStationRoom;
public Transform pennStationExit;
public Transform building1;
public Transform building2;
public Transform building3;
public Transform building4;
public Transform building5;
public Transform building6;
public Transform building7;
public Transform timesSquareBuilding1;
public Transform timesSquareBuilding2;
public Transform timesSquareBuilding3;
public Transform timesSquareBuilding4;
public Transform timesSquareBuilding5;
public Transform timesSquareBuilding6;
public Transform timesSquareBuilding7;
public Transform harlemBuilding1;
public Transform harlemBuilding2;
public Transform harlemBuilding3;
public Transform harlemBuilding4;
public Transform harlemBuilding5;
public Transform courtObj;
public Transform leftBuildingObj;
public Transform hydrantObj;
public Transform fruitCartObj;
public Transform catObj;
public Transform businessManBlack;
public Transform businessManWhite;
public Transform businessManAsian;
public Transform businessManHispanic;
public Transform businessWomanWhite;
public Transform businessWomanBlack;
public Transform businessWomanAsian;
public Transform businessWomanHispanic;
public Transform trainObj;
public Transform ratObj;
public Transform stairsObj;
public Transform subwayObj;
public Transform zonePowerupObj;
public Transform invulnerabilityPowerupObj;
private Vector3 nextTrainSpawn;
private Vector3 nextCatSpawn;
private Vector3 nextHydrantSpawn;
private Vector3 nextFruitCartSpawn;
private Vector3 nextLeftBuildingSpawn;
private Vector3 nextTileSpawn;
private Vector3 nextObjSpawn;
private Vector3 nextPersonSpawn;
private Vector3 nextRatSpawn;
private Vector3 nextStairsSpawn;
private Vector3 nextPowerupSpawn;
private bool spawnCat = true;
public static bool gameOver;
private int counter = 0;
private int randBuilding;
private int randX;
private int randCoord;
public static float courtCoord = 1000000000f;
public static float subwayCoord = 100000000000f;
public static float subwayExitCoord = 1000000000000f;
public static float pennStationExitCoord = 100000000000f;
public static string currentScene = "Chinatown";
public AdsManager ads;
public static bool AdShowing = false;
public GameObject completeLevelUI;
public void CompleteLevel()
{
    completeLevelUI.SetActive(true);
}
void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        nextTileSpawn.z = 24;
        nextTileSpawn.x = 3;
        nextPowerupSpawn.z = 24;
        nextPowerupSpawn.y = 1.5f;
        nextLeftBuildingSpawn.x = -8;
        nextLeftBuildingSpawn.z = 15;
        nextPersonSpawn.y = .25f;
        nextPersonSpawn.x = 3;

        spawnStart();
        StartCoroutine(spawnTile());
        StartCoroutine(spawnLeftBuildings());
        StartCoroutine(spawnObjs());

    }


    void Update()
    {
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 450 && GameObject.Find("PlayerCharacter").transform.position.z < 1000)
        {
            currentScene = "Subway";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 1200 && GameObject.Find("PlayerCharacter").transform.position.z < 3200)
        {
            currentScene = "Penn Station";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 3300 && GameObject.Find("PlayerCharacter").transform.position.z < 4900)
        {
            currentScene = "Times Square";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 5000 && currentScene != "Subway" && GameObject.Find("PlayerCharacter").transform.position.z < 5900)
        {
            subwayCoord = nextTileSpawn.z;
            currentScene = "Subway";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 6000 && GameObject.Find("PlayerCharacter").transform.position.z < 7500)
        {
            currentScene = "Central Park";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 7600 && GameObject.Find("PlayerCharacter").transform.position.z < 9100)
        {
            currentScene = "Harlem";
        }
        if (GameObject.Find("PlayerCharacter").transform.position.z >= 9100)
        {
            currentScene = "Court";
        }

        if (gameOver)
        {

            gameOverPanel.SetActive(true);

            Time.timeScale = 0;







        }
    }
    IEnumerator spawnSubwayObjs()
    {
        if (nextObjSpawn.z < subwayCoord + 60)
        {

            nextObjSpawn.z += 66;
        }

        if (nextObjSpawn.z < subwayExitCoord - 60)
        {
            nextObjSpawn.y = -6.4f;
            yield return new WaitForSeconds(3.5f / MasterMovementScript.acceleration);
            nextObjSpawn.x = 3;
            nextStairsSpawn = nextObjSpawn;
            Destroy(Instantiate(stairsObj, nextStairsSpawn, stairsObj.rotation).gameObject, 45);
            randCoord = Random.Range(18, 30);
            nextObjSpawn.z += randCoord;

            randX = Random.Range(-1, 2);
            if (randX == 0)
            {
                nextObjSpawn.x = 3;
            }
            else if (randX == 1)
            {
                nextObjSpawn.x = 7;
            }
            else
            {
                nextObjSpawn.x = randX;
            }
            nextRatSpawn = nextObjSpawn;
            nextRatSpawn.y = -8.4f;
            Destroy(Instantiate(ratObj, nextRatSpawn, ratObj.rotation).gameObject, 45);
            randCoord = Random.Range(10, 20);
            nextObjSpawn.z += randCoord;

            randX = Random.Range(0, 2);
            if (randX == 0)
            {
                nextObjSpawn.x = -1;
                nextPersonSpawn = nextObjSpawn;
                nextPersonSpawn.y = -8.5f;
                randX = Random.Range(0, 2);
                randX = Random.Range(0, 2);
                if (randX == 0)
                {
                    randX = Random.Range(1, 101);
                    if (randX <= 20)
                    {
                        Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 20 && randX <= 45)
                    {
                        Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 45 && randX <= 75)
                    {
                        Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else
                    {
                        Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                }
                else
                {
                    randX = Random.Range(1, 101);
                    if (randX <= 20)
                    {
                        Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 20 && randX <= 45)
                    {
                        Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 45 && randX <= 75)
                    {
                        Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else
                    {
                        Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                }
            }
            else if (randX == 1)
            {
                nextObjSpawn.x = 7;
                nextPersonSpawn = nextObjSpawn;
                nextPersonSpawn.y = -8.5f;
                randX = Random.Range(0, 2);
                if (randX == 0)
                {
                    randX = Random.Range(1, 101);
                    if (randX <= 60)
                    {
                        Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 60 && randX <= 70)
                    {
                        Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 70 && randX <= 90)
                    {
                        Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else
                    {
                        Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                }
                else
                {
                    randX = Random.Range(1, 101);
                    if (randX <= 60)
                    {
                        Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 60 && randX <= 70)
                    {
                        Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else if (randX > 70 && randX <= 90)
                    {
                        Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                    else
                    {
                        Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                        randCoord = Random.Range(8, 12);
                        nextObjSpawn.z += randCoord;
                    }
                }
            }

            randX = Random.Range(0, 101);
            if (randX < 35 && nextObjSpawn.z != nextPowerupSpawn.z)
            {
                randX = Random.Range(-1, 2);
                if (randX == 0)
                {
                    nextPowerupSpawn.x = 3;
                }
                else if (randX == 1)
                {
                    nextPowerupSpawn.x = 7;
                }
                else
                {
                    nextPowerupSpawn.x = randX;
                }

                randX = Random.Range(1, 3);
                if (randX % 2 == 0)
                {
                    Instantiate(zonePowerupObj, nextPowerupSpawn, zonePowerupObj.rotation);
                }
                else
                {
                    Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                }
            }
            randCoord = Random.Range(55, 85);
            nextPowerupSpawn.z += randCoord;
            StartCoroutine(spawnSubwayObjs());
        }




    }
    IEnumerator spawnObjs()
    {
        if (nextObjSpawn.z < subwayCoord - 55 && currentScene == "Chinatown")
        {
            randX = Random.Range(0, 2);
            if (randX == 0)
            {
                spawnCat = false;
            }
            else
            {
                spawnCat = true;
            }
            if (randX == 1)
            {


                nextObjSpawn.x = 7;
                nextHydrantSpawn = nextObjSpawn;
                Destroy(Instantiate(hydrantObj, nextHydrantSpawn, hydrantObj.rotation).gameObject, 42);
                randCoord = Random.Range(10, 20);
                nextObjSpawn.z += randCoord;
            }
            randX = Random.Range(-1, 2);

            if (randX != 0)
            {
                if (randX == -1)
                {
                    fruitCartObj.transform.eulerAngles = new Vector3(
                    fruitCartObj.transform.eulerAngles.x,
                    -90,
                    fruitCartObj.transform.eulerAngles.z
                );
                }
                else if (randX == 1)
                {
                    randX = 7;
                    fruitCartObj.transform.eulerAngles = new Vector3(
                    fruitCartObj.transform.eulerAngles.x,
                    90,
                    fruitCartObj.transform.eulerAngles.z
                );
                }
                nextObjSpawn.x = randX;
                nextFruitCartSpawn = nextObjSpawn;
                Destroy(Instantiate(fruitCartObj, nextFruitCartSpawn, fruitCartObj.rotation).gameObject, 42);

                if (spawnCat && randX != 0)
                {
                    nextCatSpawn = nextFruitCartSpawn;
                    nextCatSpawn.y = 1.6f;
                    nextCatSpawn.z -= 2;
                    Instantiate(catObj, nextCatSpawn, catObj.rotation);
                }
                randCoord = Random.Range(10, 18);
                nextObjSpawn.z += randCoord;

            }


            nextPersonSpawn.z = nextObjSpawn.z;
            randX = Random.Range(0, 2);
            if (randX == 0)
            {
                randX = Random.Range(1, 101);
                if (randX <= 60)
                {
                    Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 60 && randX <= 70)
                {
                    Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 70 && randX <= 90)
                {
                    Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else
                {
                    Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
            }
            else
            {
                randX = Random.Range(1, 101);
                if (randX <= 60)
                {
                    Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 60 && randX <= 70)
                {
                    Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 70 && randX <= 90)
                {
                    Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else
                {
                    Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
            }


            yield return new WaitForSeconds(1.5f / MasterMovementScript.acceleration);

            randX = Random.Range(0, 101);
            if (randX < 35 && nextObjSpawn.z != nextPowerupSpawn.z)
            {
                randX = Random.Range(-1, 2);
                if (randX == 0)
                {
                    nextPowerupSpawn.x = 3;
                }
                else if (randX == 1)
                {
                    nextPowerupSpawn.x = 7;
                }
                else
                {
                    nextPowerupSpawn.x = randX;
                }
                if (MasterScoreManager.scoreCount > 25)
                {
                    randX = Random.Range(1, 3);
                    if (randX % 2 == 0)
                    {
                        Instantiate(zonePowerupObj, nextPowerupSpawn, zonePowerupObj.rotation);
                    }
                    else
                    {
                        Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                    }
                }
            }
            randCoord = Random.Range(35, 60);
            nextPowerupSpawn.z += randCoord;

            StartCoroutine(spawnObjs());
        }

    }
    void spawnStart()
    {
        nextObjSpawn.z = 8;

        for (var i = 0; i < 15; i++)
        {
            randBuilding = Random.Range(1, 8);

            switch (randBuilding)
            {
                case 1:
                    Destroy(Instantiate(building1, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);

                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 2:
                    Destroy(Instantiate(building2, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 3:
                    Destroy(Instantiate(building3, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 4:
                    nextLeftBuildingSpawn.z += 5;
                    Destroy(Instantiate(building4, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 14;
                    break;
                case 5:
                    Destroy(Instantiate(building5, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 6:
                    Destroy(Instantiate(building6, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 7:
                    nextLeftBuildingSpawn.z += 5;
                    Destroy(Instantiate(building7, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 20);
                    nextLeftBuildingSpawn.z += 14;
                    break;
                default:
                    break;


            }

            if (i % 2 == 0)
            {
                Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 45);
                nextTileSpawn.z += 66;
            }



            randX = Random.Range(0, 2);
            if (randX == 1)
            {


                nextObjSpawn.x = 7;
                nextHydrantSpawn = nextObjSpawn;
                Destroy(Instantiate(hydrantObj, nextHydrantSpawn, hydrantObj.rotation).gameObject, 45);
                randCoord = Random.Range(12, 22);
                nextObjSpawn.z += randCoord;
            }
            if (randX == 0)
            {
                spawnCat = false;
            }
            else
            {
                spawnCat = true;
            }
            randX = Random.Range(-1, 2);

            if (randX != 0)
            {
                if (randX == -1)
                {
                    fruitCartObj.transform.eulerAngles = new Vector3(
                    fruitCartObj.transform.eulerAngles.x,
                    -90,
                    fruitCartObj.transform.eulerAngles.z
                    );
                }
                else if (randX == 1)
                {
                    randX = 7;
                    fruitCartObj.transform.eulerAngles = new Vector3(
                    fruitCartObj.transform.eulerAngles.x,
                    90,
                    fruitCartObj.transform.eulerAngles.z
                    );
                }
                nextObjSpawn.x = randX;
                nextFruitCartSpawn = nextObjSpawn;
                Destroy(Instantiate(fruitCartObj, nextFruitCartSpawn, fruitCartObj.rotation).gameObject, 45);
                if (spawnCat && randX != 0 && i > 5)
                {
                    nextCatSpawn = nextFruitCartSpawn;
                    nextCatSpawn.y = 1.6f;
                    nextCatSpawn.z -= 2;
                    Instantiate(catObj, nextCatSpawn, catObj.rotation);
                }
                randCoord = Random.Range(24, 40);
                nextObjSpawn.z += randCoord;

            }

        }

    }
    IEnumerator spawnLeftBuildings()
    {
        if (currentScene == "Chinatown")
        {
            randBuilding = Random.Range(1, 8);

            switch (randBuilding)
            {
                case 1:
                    Destroy(Instantiate(building1, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 2:
                    Destroy(Instantiate(building2, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 3:
                    Destroy(Instantiate(building3, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 4:
                    nextLeftBuildingSpawn.z += 5;
                    Destroy(Instantiate(building4, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 14;
                    break;
                case 5:
                    Destroy(Instantiate(building5, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 6:
                    Destroy(Instantiate(building6, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 9;
                    break;
                case 7:
                    nextLeftBuildingSpawn.z += 5;
                    Destroy(Instantiate(building7, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 45);
                    nextLeftBuildingSpawn.z += 14;
                    break;
                default:
                    break;


            }


            yield return new WaitForSeconds(.35f);

            StartCoroutine(spawnLeftBuildings());
        }
        else
        {
            Destroy(Instantiate(building1, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 9;
            Destroy(Instantiate(building2, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 9;
            Destroy(Instantiate(building3, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 9;
            nextLeftBuildingSpawn.z += 5;
            Destroy(Instantiate(building4, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 14;
            Destroy(Instantiate(building5, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 9;
            Destroy(Instantiate(building6, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 9;
            nextLeftBuildingSpawn.z += 5;
            Destroy(Instantiate(building7, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 35);
            nextLeftBuildingSpawn.z += 14;
        }
    }
    IEnumerator spawnTile()
    {
        if (currentScene == "Chinatown")
        {
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            yield return new WaitForSeconds(3.5f);
            StartCoroutine(spawnTile());
        }
        else
        {
            nextTileSpawn.z -= 5;
            subwayCoord = nextTileSpawn.z;
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 45);
            nextTileSpawn.z += 20;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z = subwayCoord + 14;
            nextTileSpawn.y = 0;
            yield return new WaitForSeconds(2);
            nextTrainSpawn.y = -9.5f;
            nextTrainSpawn.z = nextTileSpawn.z;
            nextTrainSpawn.x = -8.3f;
            StartCoroutine(spawnSubway());
            yield return new WaitForSeconds(2.5f);
            nextPowerupSpawn.y = -6.4f;
            StartCoroutine(spawnSubwayObjs());
        }
    }
    IEnumerator spawnSubway()
    {
        if (currentScene == "Subway")
        {
            if (counter % 13 == 0 || counter == 0)
            {
                yield return new WaitForSeconds(.15f / MasterMovementScript.acceleration);
                if (counter % 2 == 0)
                {
                    nextTrainSpawn.x = -8.3f;
                    nextTrainSpawn.z = nextTileSpawn.z + 5;
                    Destroy(Instantiate(trainObj, nextTrainSpawn, trainObj.rotation).gameObject, 45);
                }
                else
                {
                    nextTrainSpawn.x = 13.7f;
                    nextTrainSpawn.z = nextTileSpawn.z + 5;
                    Destroy(Instantiate(trainObj, nextTrainSpawn, trainObj.rotation).gameObject, 45);
                }
            }
            Destroy(Instantiate(subwayObj, nextTileSpawn, subwayObj.rotation).gameObject, 45);
            nextTileSpawn.z += 6;
            yield return new WaitForSeconds(.35f / MasterMovementScript.acceleration);
            counter += 1;
            StartCoroutine(spawnSubway());
        }
        else if (currentScene == "Penn Station")
        {
            subwayExitCoord = nextTileSpawn.z;
            subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 180, 180);
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 65);
            nextTileSpawn.z += 54;
            nextTileSpawn.y = 0;
            Destroy(Instantiate(pennStationRoom, nextTileSpawn, pennStationRoom.rotation).gameObject, 55);
            nextTileSpawn.z += 54;
            nextPowerupSpawn.y = .2f;
            StartCoroutine(spawnPennStation());
            yield return new WaitForSeconds(20);
            nextObjSpawn.z += 100;
            StartCoroutine(spawnPennStationObjs());
        }
        else
        {
            subwayExitCoord = nextTileSpawn.z;
            subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 180, 180);
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 65);
            StartCoroutine(spawnCentralPark());
            StartCoroutine(spawnCentralParkObjs());
        }
    }

    IEnumerator spawnPennStation()
    {
        if (currentScene == "Penn Station")
        {

            yield return new WaitForSeconds(6 / MasterMovementScript.acceleration);
            Destroy(Instantiate(pennStationRoom, nextTileSpawn, pennStationRoom.rotation).gameObject, 50);
            nextTileSpawn.z += 54;
            StartCoroutine(spawnPennStation());
        }
        else
        {
            pennStationExitCoord = nextTileSpawn.z;
            nextTileSpawn.z -= 54;
            Destroy(Instantiate(pennStationExit, nextTileSpawn, pennStationExit.rotation).gameObject, 60);
            nextTileSpawn.z += 28;
            nextLeftBuildingSpawn.z = nextTileSpawn.z - 5;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            StartCoroutine(spawnTimesSquareBuildings());
            StartCoroutine(spawnTimesSquare());
            StartCoroutine(spawnTimesSquareObjs());
        }
    }
    IEnumerator spawnPennStationObjs()
    {
        if (nextObjSpawn.z < pennStationExitCoord - 55)
        {
            nextPersonSpawn.y = 0;
            yield return new WaitForSeconds(.85f / MasterMovementScript.acceleration);

            randX = Random.Range(-1, 2);
            if (randX == 0)
            {
                nextPersonSpawn.x = 3;
            }
            else if (randX == 1)
            {
                nextPersonSpawn.x = 7;
            }
            else
            {
                nextPersonSpawn.x = randX;
            }
            nextPersonSpawn.z = nextObjSpawn.z;
            randX = Random.Range(0, 2);
            if (randX == 0)
            {
                randX = Random.Range(1, 101);
                if (randX <= 60)
                {
                    Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 60 && randX <= 70)
                {
                    Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 70 && randX <= 90)
                {
                    Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else
                {
                    Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
            }
            else
            {
                randX = Random.Range(1, 101);
                if (randX <= 60)
                {
                    Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 60 && randX <= 70)
                {
                    Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else if (randX > 70 && randX <= 90)
                {
                    Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
                else
                {
                    Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                    randCoord = Random.Range(8, 12);
                    nextObjSpawn.z += randCoord;
                }
            }
            StartCoroutine(spawnPennStationObjs());
        }

    }
    IEnumerator spawnTimesSquareObjs()
    {
        if (currentScene == "Times Square")
        {
            randX = Random.Range(0, 101);
            if (randX < 35 && nextObjSpawn.z != nextPowerupSpawn.z)
            {
                randX = Random.Range(-1, 2);
                if (randX == 0)
                {
                    nextPowerupSpawn.x = 3;
                }
                else if (randX == 1)
                {
                    nextPowerupSpawn.x = 7;
                }
                else
                {
                    nextPowerupSpawn.x = randX;
                }

                randX = Random.Range(1, 3);
                if (randX % 2 == 0)
                {
                    Instantiate(zonePowerupObj, nextPowerupSpawn, zonePowerupObj.rotation);
                }
                else
                {
                    Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                }
            }
            randCoord = Random.Range(35, 60);
            nextPowerupSpawn.z += randCoord;
            yield return new WaitForSeconds(3);
            StartCoroutine(spawnTimesSquareObjs());
        }
    }
    IEnumerator spawnTimesSquare()
    {
        if (currentScene == "Times Square")
        {
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(spawnTimesSquare());
        }
        else
        {
            subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 0, 180);
            nextTileSpawn.z -= 5;
            subwayCoord = nextTileSpawn.z;
            nextObjSpawn.z = subwayCoord + 50;
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 45);
            nextTileSpawn.z += 20;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z = subwayCoord + 14;
            nextTileSpawn.y = 0;
            yield return new WaitForSeconds(2);
            nextTrainSpawn.y = -9.5f;
            nextTrainSpawn.z = nextTileSpawn.z;
            nextTrainSpawn.x = -8.3f;
            StartCoroutine(spawnSubway());
            nextPowerupSpawn.y = -6.4f;
            StartCoroutine(spawnSubwayObjs());
        }

    }

    IEnumerator spawnTimesSquareBuildings()
    {
        if (currentScene == "Times Square")
        {
            randBuilding = Random.Range(1, 8);

            switch (randBuilding)
            {
                case 1:
                    Destroy(Instantiate(timesSquareBuilding1, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 2:
                    Destroy(Instantiate(timesSquareBuilding2, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 3:
                    Destroy(Instantiate(timesSquareBuilding3, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 4:
                    Destroy(Instantiate(timesSquareBuilding4, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 5:
                    Destroy(Instantiate(timesSquareBuilding5, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 6:
                    Destroy(Instantiate(timesSquareBuilding6, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 7:
                    Destroy(Instantiate(timesSquareBuilding7, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                default:
                    break;


            }


            yield return new WaitForSeconds(.35f);

            StartCoroutine(spawnTimesSquareBuildings());
        }
    }
    IEnumerator spawnCentralPark()
    {
        if (currentScene == "Central Park")
        {
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(spawnCentralPark());
        }
        else
        {
            nextLeftBuildingSpawn.z = nextTileSpawn.z;
            StartCoroutine(spawnHarlem());
            StartCoroutine(spawnHarlemBuildings());
            StartCoroutine(spawnHarlemObjs());
        }
    }
    IEnumerator spawnCentralParkObjs()
    {
        yield return null;
    }

    IEnumerator spawnHarlem()
    {
        if (currentScene == "Harlem")
        {
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 66;
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(spawnHarlem());
        }
    }
    IEnumerator spawnHarlemBuildings()
    {
        nextLeftBuildingSpawn.y = 0;
        nextLeftBuildingSpawn.x = -8;
        if (currentScene == "Harlem" && nextLeftBuildingSpawn.z < courtCoord)
        {
            randBuilding = Random.Range(1, 6);

            switch (randBuilding)
            {
                case 1:
                    nextLeftBuildingSpawn.y = -1.6f;
                    Destroy(Instantiate(harlemBuilding1, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 2:
                    nextLeftBuildingSpawn.y = -1.6f;
                    Destroy(Instantiate(harlemBuilding2, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 3:
                    nextLeftBuildingSpawn.y = -2.9f;
                    nextLeftBuildingSpawn.x = -10;
                    nextLeftBuildingSpawn.z += 10;
                    Destroy(Instantiate(harlemBuilding3, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 20;
                    break;
                case 4:
                    Destroy(Instantiate(harlemBuilding4, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 10;
                    break;
                case 5:
                    nextLeftBuildingSpawn.z += 5;
                    Destroy(Instantiate(harlemBuilding5, nextLeftBuildingSpawn, leftBuildingObj.rotation).gameObject, 55);
                    nextLeftBuildingSpawn.z += 15;
                    break;
                default:
                    break;


            }


            yield return new WaitForSeconds(.6f);

            StartCoroutine(spawnHarlemBuildings());
        }
        else
        {
            StartCoroutine(spawnCourt());
        }
    }
    IEnumerator spawnHarlemObjs()
    {
        yield return null;
    }

    IEnumerator spawnCourt()
    {
        courtCoord = nextTileSpawn.z - 10;
        nextTileSpawn.z -= 10;
        Instantiate(courtObj, nextTileSpawn, courtObj.rotation);
        yield return null;
    }
}
