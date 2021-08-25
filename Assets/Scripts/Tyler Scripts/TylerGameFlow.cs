using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class TylerGameFlow : MonoBehaviour
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
    public Transform manBlack;
    public Transform manWhite;
    public Transform manAsian;
    public Transform manHispanic;
    public Transform womanBlack;
    public Transform womanWhite;
    public Transform womanAsian;
    public Transform womanHispanic;
    public Transform trainObj;
    public Transform ratObj;
    public Transform stairsObj;
    public Transform subwayObj;
    public Transform grassObj;
    public Transform treeObj;
    public Transform lakeObj;
    public Transform lampObj;
    public Transform trashObj;
    public Transform trashObj2;
    public Transform pigeonObj;
    public Transform horseObj;
    public Transform zonePowerupObj;
    public Transform invulnerabilityPowerupObj;
    public Transform sidewalkNoStreet;
    public Transform streetLightObj;
    public Transform carriageObj;
    public Transform carObj1;
    public Transform carObj2;
    public Transform carObj3;
    public Transform carObj4;
    private Material[] carMat;
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
    private Vector3 nextGrassSpawn;
    private Vector3 nextTreeSpawn;
    private Vector3 nextLampSpawn;
    private Vector3 nextTrashSpawn;
    private Vector3 nextLakeSpawn;
    private Vector3 nextHorseSpawn;
    private Vector3 nextPigeonSpawn;
    private Vector3 nextStreetLightSpawn;
    private Vector3 nextCarriageSpawn;
    private Vector3 nextCarSpawn;
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
    private float harlemSpawn = 100000000000000f;
    private float lastGrassSpawn;
    private bool spawnedLake;
    public static string currentScene = "Chinatown";

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
        nextCarSpawn.z = 105;
        nextPersonSpawn.y = .25f;
        nextPersonSpawn.x = 3;

        spawnStart();
        StartCoroutine(spawnCars());
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
        if(GameObject.Find("PlayerCharacter").transform.position.z >= 3300&& GameObject.Find("PlayerCharacter").transform.position.z < 4900){
            currentScene = "Times Square";
        }
        if(GameObject.Find("PlayerCharacter").transform.position.z >= 5000&&currentScene!="Subway"&&GameObject.Find("PlayerCharacter").transform.position.z < 5900){
           subwayCoord = nextTileSpawn.z;
            currentScene = "Subway";
        }
        if(GameObject.Find("PlayerCharacter").transform.position.z >= 6000 && GameObject.Find("PlayerCharacter").transform.position.z < 7500){
            currentScene = "Central Park";
        }
        if(GameObject.Find("PlayerCharacter").transform.position.z >= 7600 &&GameObject.Find("PlayerCharacter").transform.position.z < 9100){
            currentScene = "Harlem";
        }
        if(GameObject.Find("PlayerCharacter").transform.position.z >= 9100){
            currentScene = "Court";
        }

        if (gameOver)
        {

            gameOverPanel.SetActive(true);

            Time.timeScale = 0;







        }
    }

    IEnumerator spawnCars(){
        
        if(currentScene=="Chinatown"|| currentScene=="Times Square"|| currentScene=="Harlem"){
            
            randX = Random.Range(0,4);
            switch(randX){
                case 0:
            nextCarSpawn.x = 19;
            carObj1.rotation = Quaternion.Euler(-89.98f,180,0);
            carMat = carObj1.GetComponent<Renderer>().materials;
            Destroy(Instantiate(carObj1,nextCarSpawn, carObj1.rotation).gameObject, 50);
            carMat[1].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 1:
            nextCarSpawn.x = 19;
            carObj2.rotation = Quaternion.Euler(-89.98f,180,0);
            carMat = carObj2.GetComponent<Renderer>().materials;
            Destroy(Instantiate(carObj2,nextCarSpawn, carObj2.rotation).gameObject, 50);
            carMat[1].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
             nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 2:
            nextCarSpawn.x = 19;
            carObj3.rotation = Quaternion.Euler(-89.98f,180,0);
            Destroy(Instantiate(carObj3,nextCarSpawn, carObj3.rotation).gameObject, 50);
            carObj3.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
             nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 3:
            nextCarSpawn.x = 19;
            carObj4.rotation = Quaternion.Euler(-89.98f,180,0);
            Destroy(Instantiate(carObj4,nextCarSpawn, carObj4.rotation).gameObject, 50);
             nextCarSpawn.z+= Random.Range(45,70);
            break;
            default:
            break;
            }
            nextCarSpawn.z+= Random.Range(5,10);
            randX = Random.Range(0,4);
            switch(randX){
            
            case 0:
            nextCarSpawn.x = 39;
            carObj1.rotation = Quaternion.Euler(-89.98f,0,0);
            carMat = carObj1.GetComponent<Renderer>().materials;
            Destroy(Instantiate(carObj1,nextCarSpawn, carObj1.rotation).gameObject, 50);
             carMat[1].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 1:
            nextCarSpawn.x = 39;
            carObj2.rotation = Quaternion.Euler(-89.98f,0,0);
            carMat = carObj2.GetComponent<Renderer>().materials;
            Destroy(Instantiate(carObj2,nextCarSpawn, carObj2.rotation).gameObject, 50);
            carMat[1].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 2:
            nextCarSpawn.x = 39;
            carObj3.rotation = Quaternion.Euler(-89.98f,0,0);
            Destroy(Instantiate(carObj3,nextCarSpawn, carObj3.rotation).gameObject, 50);
            carObj3.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
             nextCarSpawn.z+= Random.Range(45,70);
            break;
            case 3:
            nextCarSpawn.x = 39;
            carObj4.rotation = Quaternion.Euler(-89.98f,0,0);
            Destroy(Instantiate(carObj4,nextCarSpawn, carObj4.rotation).gameObject, 50);
             nextCarSpawn.z+= Random.Range(45,70);
            break;
            default:
            break;
            
            }
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(spawnCars());
    }
    IEnumerator spawnSubwayObjs()
    {
         nextPowerupSpawn.y = -6.4f;
        if (nextObjSpawn.z < subwayCoord + 60)
        {
            
            nextObjSpawn.z += 66;
        }

        if (nextObjSpawn.z < subwayExitCoord - 60)
        {
            nextObjSpawn.y = -6.4f;
            yield return new WaitForSeconds(3.5f / TylerMovementScript.acceleration);
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
               randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=20)
            {
                Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 20 && randX <= 45 )
            {
                Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >45 && randX <=75) {
                Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=20)
            {
                Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 20 && randX <= 45 )
            {
                Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >45 && randX <=75) {
                Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
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
                    //Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                }
            }
            randCoord = Random.Range(75, 95);
            nextPowerupSpawn.z += randCoord;
            StartCoroutine(spawnSubwayObjs());
        }




    }
    IEnumerator spawnObjs()
    {
        if (nextObjSpawn.z < subwayCoord - 55 && currentScene=="Chinatown")
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            }


            yield return new WaitForSeconds(1.5f / TylerMovementScript.acceleration);

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
                if (TylerScoreManager.scoreCount > 25)
                {
                    randX = Random.Range(1, 3);
                    if (randX % 2 == 0)
                    {
                        Instantiate(zonePowerupObj, nextPowerupSpawn, zonePowerupObj.rotation);
                    }
                    else
                    {
                        //Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
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
                nextTileSpawn.z += 60;
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
            nextTileSpawn.z += 60;
            yield return new WaitForSeconds(3.1f);
            StartCoroutine(spawnTile());
        }
        else
        {
            nextTileSpawn.z -= 20;
            subwayCoord = nextTileSpawn.z;
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 45);
            nextTileSpawn.z += 40;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 60;
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
         nextPowerupSpawn.y = -6.4f;
        if (currentScene == "Subway")
        {
            if (counter % 13 == 0 || counter == 0)
            {
                yield return new WaitForSeconds(.15f / TylerMovementScript.acceleration);
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
            yield return new WaitForSeconds(.35f / TylerMovementScript.acceleration);
            counter += 1;
            StartCoroutine(spawnSubway());
        }
        else if(currentScene =="Penn Station"){
            subwayExitCoord = nextTileSpawn.z;
            subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 180, 180);
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 65);
            nextTileSpawn.z += 54;
            nextTileSpawn.y = 0;
            Destroy(Instantiate(pennStationRoom, nextTileSpawn, pennStationRoom.rotation).gameObject, 55);
            nextTileSpawn.z += 54;
            nextPowerupSpawn.y = 1.5f;
            StartCoroutine(spawnPennStation());
            yield return new WaitForSeconds(20);
            nextObjSpawn.z+= 100;
            StartCoroutine(spawnPennStationObjs());
        } else {
            subwayExitCoord = nextTileSpawn.z;
            subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 180, 180);
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 65);
            nextGrassSpawn.z = nextTileSpawn.z;
            nextGrassSpawn.x = -14;
            yield return new WaitForSeconds(20);
            StartCoroutine(spawnCentralPark());
             StartCoroutine(spawnCentralParkObjs());
        }
    }

    IEnumerator spawnPennStation()
    {
        if(currentScene == "Penn Station"){

        yield return new WaitForSeconds(6 / TylerMovementScript.acceleration);
        Destroy(Instantiate(pennStationRoom, nextTileSpawn, pennStationRoom.rotation).gameObject, 50);
        nextTileSpawn.z += 54;
        StartCoroutine(spawnPennStation());
        } else {
        pennStationExitCoord = nextTileSpawn.z;
        nextTileSpawn.z-= 54;
        Destroy(Instantiate(pennStationExit, nextTileSpawn, pennStationExit.rotation).gameObject, 60);
        nextTileSpawn.z += 28;
        nextLeftBuildingSpawn.z = nextTileSpawn.z-5;
        Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
        nextTileSpawn.z += 60;
        Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
        nextObjSpawn.y = .15f;
        nextCarSpawn.z = pennStationExitCoord+20;
        StartCoroutine(spawnTimesSquareBuildings());
        StartCoroutine(spawnTimesSquare());
        StartCoroutine(spawnTimesSquareObjs());
    }
    }
    IEnumerator spawnPennStationObjs()
    
    {
        nextPowerupSpawn.y = 1.5f;
        if(nextObjSpawn.z <pennStationExitCoord-55) {
         nextPersonSpawn.y = 0;
         yield return new WaitForSeconds(.85f/TylerMovementScript.acceleration);
        
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessManAsian, nextPersonSpawn, businessManAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessManBlack, nextPersonSpawn, businessManBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessManHispanic, nextPersonSpawn, businessManHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(businessWomanAsian, nextPersonSpawn, businessWomanAsian.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(businessWomanBlack, nextPersonSpawn, businessWomanBlack.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(businessWomanHispanic, nextPersonSpawn, businessWomanHispanic.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessWomanWhite, nextPersonSpawn, businessWomanWhite.rotation);
                randCoord = Random.Range(8, 12);
                nextObjSpawn.z += randCoord;
            }
            }
            StartCoroutine(spawnPennStationObjs());
        }
    
}
IEnumerator  spawnTimesSquareObjs(){
 
 if(currentScene=="Times Square"){
 yield return new WaitForSeconds(1/TylerMovementScript.acceleration);
 if(nextObjSpawn.z<pennStationExitCoord){
     nextObjSpawn.z = pennStationExitCoord+10;
 }
        
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(manAsian, nextPersonSpawn, manAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(manBlack, nextPersonSpawn, manBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(manHispanic, nextPersonSpawn, manHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(manWhite, nextPersonSpawn, manWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(womanAsian, nextPersonSpawn, womanAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(womanBlack, nextPersonSpawn, womanBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(womanHispanic, nextPersonSpawn, womanHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(womanWhite, nextPersonSpawn, womanWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            }
            nextTrashSpawn=nextObjSpawn;
            randX = Random.Range(-1, 2);
            if (randX == 0)
            {
                nextTrashSpawn.x = 3;
            }
            else if (randX == 1)
            {
                nextTrashSpawn.x = 7;
            }
            else
            {
                nextTrashSpawn.x = randX;
            }
            Destroy(Instantiate(trashObj2, nextTrashSpawn, trashObj2.rotation).gameObject,65);
            nextObjSpawn.z+= 20;

            nextPigeonSpawn = nextObjSpawn;
             randX = Random.Range(-1, 2);
            if (randX == 0)
            {
                nextPigeonSpawn.x = 3;
            }
            else if (randX == 1)
            {
                nextPigeonSpawn.x = 7;
            }
            else
            {
                nextPigeonSpawn.x = randX;
            }
            Destroy(Instantiate(pigeonObj, nextPigeonSpawn, pigeonObj.rotation).gameObject,65);
            nextPigeonSpawn.z+=1;
            nextPigeonSpawn.x-=.5f;
            Destroy(Instantiate(pigeonObj, nextPigeonSpawn, pigeonObj.rotation).gameObject,65);
            nextPigeonSpawn.x+=1;
            Destroy(Instantiate(pigeonObj, nextPigeonSpawn, pigeonObj.rotation).gameObject,65);
            nextObjSpawn.z+=20;
 
 
 
 
 
 
 
 
 
 
 
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
                        //Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                    }
                } 
            randCoord = Random.Range(45, 70);
            nextPowerupSpawn.z += randCoord;
yield return new WaitForSeconds(.5f/TylerMovementScript.acceleration);
StartCoroutine(spawnTimesSquareObjs());
 }
}
IEnumerator  spawnTimesSquare(){
    if(currentScene=="Times Square"){
    Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
    nextTileSpawn.z += 60;
    yield return new WaitForSeconds(2);
    StartCoroutine(spawnTimesSquare());
    } else {
         subwayEnterance.transform.rotation = Quaternion.Euler(-89.98f, 0, 180);
        nextTileSpawn.z -= 20;
            subwayCoord = nextTileSpawn.z;
            nextObjSpawn.z = subwayCoord+50;
            Destroy(Instantiate(subwayEnterance, nextTileSpawn, subwayEnterance.rotation).gameObject, 45);
            nextTileSpawn.z += 40;
            Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
            nextTileSpawn.z += 60;
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


            yield return new WaitForSeconds(.25f);

            StartCoroutine(spawnTimesSquareBuildings());
        }
    }

private Vector3 spawnTree(float x, float y, char side){
float randX;
float randY;
if(side =='L'){
randX = Random.Range(x-20,x);
randY = Random.Range(y-20,y);
} else {
randX = Random.Range(x,x+20);
randY = Random.Range(y,y+20);
}
return new Vector3(randX,0,randY);
}
IEnumerator spawnCentralPark(){
    nextPowerupSpawn.y = 1.5f;
    if(currentScene == "Central Park"){
        randX = Random.Range(0,101);
    if(randX <30&&!spawnedLake){
        spawnedLake = true;
        nextLakeSpawn.x = 40;
        nextLakeSpawn.z = nextGrassSpawn.z+20;
        Destroy(Instantiate(lakeObj,nextLakeSpawn,lakeObj.rotation).gameObject, 50);

        nextGrassSpawn.x = -14;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
     Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    nextGrassSpawn.z+=20;
     Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.z+=20;
    nextGrassSpawn.x+=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    nextGrassSpawn.z+=20;
    }
    Destroy(Instantiate(sidewalkNoStreet, nextTileSpawn, sidewalkNoStreet.rotation).gameObject, 50);
    nextGrassSpawn.x = 20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
     nextGrassSpawn.x+=20;
     Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
     Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    nextGrassSpawn.z+=20;
     Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.z+=20;
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'R'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    nextGrassSpawn.z+=20;

    nextGrassSpawn.z-=60;
    nextGrassSpawn.x = -14;
    if(randX <45){
        nextCarriageSpawn = nextGrassSpawn;
        nextCarriageSpawn.x = -10;
        Destroy(Instantiate(carriageObj, nextCarriageSpawn, carriageObj.rotation).gameObject,50);
    }
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
     Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    nextGrassSpawn.z+=20;
     Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.z+=20;
    nextGrassSpawn.x+=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x-=20;
    Destroy(Instantiate(grassObj, nextGrassSpawn, grassObj.rotation).gameObject, 50);
    Destroy(Instantiate(treeObj,spawnTree(nextGrassSpawn.x, nextGrassSpawn.z,'L'),treeObj.rotation).gameObject,50);
    nextGrassSpawn.x+=20;
    nextGrassSpawn.z+=20;
    lastGrassSpawn= nextGrassSpawn.z;
    nextTileSpawn.z += 60;
    yield return new WaitForSeconds(2.5f);
    StartCoroutine(spawnCentralPark());
    } else {
        Destroy(Instantiate(sidewalkNoStreet, nextTileSpawn, sidewalkNoStreet.rotation).gameObject, 50);
        nextTileSpawn.z += 60;
        Destroy(Instantiate(sidewalkNoStreet, nextTileSpawn, sidewalkNoStreet.rotation).gameObject, 50);
        nextTileSpawn.z += 60;
        nextLeftBuildingSpawn.z = lastGrassSpawn;
        harlemSpawn = lastGrassSpawn;
        nextCarSpawn.z = harlemSpawn+20;
        StartCoroutine(spawnHarlem());
        StartCoroutine(spawnHarlemBuildings());
        StartCoroutine(spawnHarlemObjs());
    }
}
IEnumerator spawnCentralParkObjs(){
            yield return new WaitForSeconds(.65f/TylerMovementScript.acceleration);
            nextObjSpawn.y = 0;
            if(currentScene == "Central Park"&&nextObjSpawn.z < 7850){
            randX = Random.Range(-1, 2);
            if(randX ==0){
                 randX = Random.Range(-1, 1);
                 nextLampSpawn = nextObjSpawn;
                 nextLampSpawn.y = .3f;
                if(randX ==0){
                    randX = 7;
                }
                nextLampSpawn.x = randX;
                Destroy(Instantiate(lampObj, nextLampSpawn, lampObj.rotation).gameObject, 60);
                nextObjSpawn.z += Random.Range(15,25);
            } else if(randX ==-1){
                randX = Random.Range(-1, 2);
                if(randX== 0){
                    randX = 3;
                } else if(randX == 1){
                    randX = 7;
                }
                nextTrashSpawn = nextObjSpawn;
                nextTrashSpawn.x = randX;
                Destroy(Instantiate(trashObj, nextTrashSpawn, trainObj.rotation).gameObject, 60);
                nextObjSpawn.z += Random.Range(20,30);
            } else{
                nextObjSpawn.z+= Random.Range(8,18);
            }
            randX = Random.Range(-1, 2);
            nextPersonSpawn = nextObjSpawn;
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(manAsian, nextPersonSpawn, manAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(manBlack, nextPersonSpawn, manBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(manHispanic, nextPersonSpawn, manHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(womanAsian, nextPersonSpawn, womanAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(womanBlack, nextPersonSpawn, womanBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(womanHispanic, nextPersonSpawn, womanHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(womanWhite, nextPersonSpawn, womanWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            }
            nextHorseSpawn = nextObjSpawn;

            randX = Random.Range(-1,3);
            if(randX >=1){
            if(randX%2==0){
                randX = 10;
                horseObj.rotation =  Quaternion.Euler(0, -90, 0);
                nextHorseSpawn.x = randX;
            } else {
                randX = -3;
                horseObj.rotation =  Quaternion.Euler(0, 90, 0);
                nextHorseSpawn.x = randX;
            }
            Destroy(Instantiate(horseObj, nextHorseSpawn, horseObj.rotation).gameObject, 55);
            nextObjSpawn.z+= 30;
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
                        //Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                    }
                } 
            randCoord = Random.Range(35, 60);
            nextPowerupSpawn.z += randCoord;
yield return new WaitForSeconds(1.25f/TylerMovementScript.acceleration);
StartCoroutine(spawnCentralParkObjs());
            } else {
                StopCoroutine(spawnCentralParkObjs());
            }
}

IEnumerator spawnHarlem(){
    if(currentScene == "Harlem"){
    Destroy(Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation).gameObject, 50);
    nextTileSpawn.z += 60;
    yield return new WaitForSeconds(2);
    StartCoroutine(spawnHarlem());
}
}
IEnumerator spawnHarlemBuildings()    {
        nextLeftBuildingSpawn.y = 0;
        nextLeftBuildingSpawn.x = -8;
        if (currentScene=="Harlem"&&nextLeftBuildingSpawn.z<courtCoord)
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
} else{
    StartCoroutine(spawnCourt());
}
}
IEnumerator spawnHarlemObjs(){
if(currentScene=="Harlem" &&nextObjSpawn.z <courtCoord){
    nextPowerupSpawn.y = 1.5f;
    if(nextObjSpawn.z <harlemSpawn){
        nextObjSpawn.z = harlemSpawn +15;
    }
yield return new WaitForSeconds(1.9f/TylerMovementScript.acceleration);
            randX = Random.Range(-1, 2);
            if (randX == 1)
            {
                nextObjSpawn.x = -1;
                nextHydrantSpawn = nextObjSpawn;
                Destroy(Instantiate(hydrantObj, nextHydrantSpawn, hydrantObj.rotation).gameObject, 42);
                randCoord = Random.Range(10, 20);
                nextObjSpawn.z += randCoord;
            }
            nextPersonSpawn = nextObjSpawn;
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
            randX = Random.Range(0,2);
            if(randX == 0){
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(manAsian, nextPersonSpawn, manAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(manBlack, nextPersonSpawn, manBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(manHispanic, nextPersonSpawn, manHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(businessManWhite, nextPersonSpawn, businessManWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            } else {
            randX = Random.Range(1, 101);
            if (randX <=60)
            {
                Instantiate(womanAsian, nextPersonSpawn, womanAsian.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            else if(randX> 60 && randX <= 70 )
            {
                Instantiate(womanBlack, nextPersonSpawn, womanBlack.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            } else if(randX >70 && randX <=90) {
                Instantiate(womanHispanic, nextPersonSpawn, womanHispanic.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }else {
                Instantiate(womanWhite, nextPersonSpawn, womanWhite.rotation);
                randCoord = Random.Range(16, 24);
                nextObjSpawn.z += randCoord;
            }
            }
            
            nextStreetLightSpawn = nextObjSpawn;
            nextStreetLightSpawn.x = 8;
            Destroy(Instantiate(streetLightObj,nextStreetLightSpawn, streetLightObj.rotation).gameObject,55);
            nextObjSpawn.z+= Random.Range(15,25);
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
                        //Instantiate(invulnerabilityPowerupObj, nextPowerupSpawn, invulnerabilityPowerupObj.rotation);
                    }
                } 
            randCoord = Random.Range(35, 60);
            nextPowerupSpawn.z += randCoord;
StartCoroutine(spawnHarlemObjs());
}
}

IEnumerator spawnCourt(){
    courtCoord = nextTileSpawn.z-25;
    nextTileSpawn.z -=23;
    Instantiate(courtObj, nextTileSpawn, courtObj.rotation);
    yield return null;
}
}
