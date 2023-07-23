using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour
{
    public static ObjectPuller current;


    private int pullOfObjects100 = 100;
    private int pullOfObjects10 = 10;
    private int pullOfObjects15 = 15;
    private int pullOfObjects60 = 60;
    private int pullOfObjects3 = 3;
    private bool willGrow;


    [SerializeField]
    private GameObject Tiles;
    [SerializeField]
    private GameObject GatherTiles;

    [SerializeField]
    private GameObject playerFlagshipShot;
    [SerializeField]
    private GameObject playerCruiserShot;
    [SerializeField]
    private GameObject playerDestrShot;
    [SerializeField]
    private GameObject enemyFlagshipShot;
    [SerializeField]
    private GameObject enemyCruiserShot;
    [SerializeField]
    private GameObject enemyDestrShot;

    [SerializeField]
    private GameObject playerFlagship;
    [SerializeField]
    private GameObject playerCruiser;
    [SerializeField]
    private GameObject playerDestr;
    [SerializeField]
    private GameObject enemyFlagship;
    [SerializeField]
    private GameObject enemyCruiser;
    [SerializeField]
    private GameObject enemyDestr;

    [SerializeField]
    private GameObject HPBurst;
    [SerializeField]
    private GameObject ShotBurst;
    [SerializeField]
    private GameObject EnergyBurst;
    [SerializeField]
    private GameObject ShieldBurst;

    [SerializeField]
    private GameObject flagshipBurst;
    [SerializeField]
    private GameObject cruisBurst;
    [SerializeField]
    private GameObject destrBurst;
    [SerializeField]
    private GameObject bulletBurst;
    [SerializeField]
    private GameObject shieldFlaghipBurst;
    [SerializeField]
    private GameObject shieldDestrBurst;
    [SerializeField]
    private GameObject shieldCruisBurst;


    //[SerializeField]
    //private GameObject HPGather;
    //[SerializeField]
    //private GameObject ShotGather;
    //[SerializeField]
    //private GameObject EnergyGather;
    //[SerializeField]
    //private GameObject ShieldGather;
    //[SerializeField]
    //private GameObject AimGather;

    [SerializeField]
    private GameObject Asteroid;
    

    private List<GameObject> TilesList;
    private List<GameObject> GatherTilesList;

    private List<GameObject> playerFlagshipShotList;
    private List<GameObject> playerCruiserShotList;
    private List<GameObject> playerDestrShotList;
    private List<GameObject> enemyFlagshipShotList;
    private List<GameObject> enemyCruiserShotList;
    private List<GameObject> enemyDestrShotList;

    private List<GameObject> playerFlagshipList;
    private List<GameObject> playerCruiserList;
    private List<GameObject> playerDestrList;
    private List<GameObject> enemyFlagshipList;
    private List<GameObject> enemyCruiserList;
    private List<GameObject> enemyDestrList;

    private List<GameObject> HPBurstList;
    private List<GameObject> ShotBurstList;
    private List<GameObject> EnergyBurstList;
    private List<GameObject> ShieldBurstList;

    private List<GameObject> flagshipBurstList;
    private List<GameObject> cruisBurstList;
    private List<GameObject> destrBurstList;
    private List<GameObject> bulletBurstList;
    private List<GameObject> shieldFlaghipBurstList;
    private List<GameObject> shieldDestrBurstList;
    private List<GameObject> shieldCruisBurstList;


    //private List<GameObject> HPGatherList;
    //private List<GameObject> ShotGatherList;
    //private List<GameObject> EnergyGatherList;
    //private List<GameObject> ShieldGatherList;
    //private List<GameObject> AimGatherList;

    private List<GameObject> AsteroidsList;


    private void Awake()
    {
        willGrow = true;
        current = this;
    }

    private void OnEnable()
    {
        TilesList = new List<GameObject>();
        GatherTilesList = new List<GameObject>();

        
        playerFlagshipShotList = new List<GameObject>();
        playerCruiserShotList = new List<GameObject>();
        playerDestrShotList = new List<GameObject>();
        enemyFlagshipShotList = new List<GameObject>();
        enemyCruiserShotList = new List<GameObject>();
        enemyDestrShotList = new List<GameObject>();
        
        playerFlagshipList = new List<GameObject>();
        playerCruiserList = new List<GameObject>();
        playerDestrList = new List<GameObject>();
        enemyFlagshipList = new List<GameObject>();
        enemyCruiserList = new List<GameObject>();
        enemyDestrList = new List<GameObject>();


        HPBurstList = new List<GameObject>();
        ShotBurstList = new List<GameObject>();
        EnergyBurstList = new List<GameObject>();
        ShieldBurstList = new List<GameObject>();

        flagshipBurstList = new List<GameObject>();
        cruisBurstList = new List<GameObject>();
        destrBurstList = new List<GameObject>();
        bulletBurstList = new List<GameObject>();
        shieldFlaghipBurstList = new List<GameObject>();
        shieldDestrBurstList = new List<GameObject>();
        shieldCruisBurstList = new List<GameObject>();


        //HPGatherList = new List<GameObject>();
        //ShotGatherList = new List<GameObject>();
        //EnergyGatherList = new List<GameObject>();
        //ShieldGatherList = new List<GameObject>();
        //AimGatherList = new List<GameObject>();

        AsteroidsList = new List<GameObject>();


        for (int i = 0; i < pullOfObjects100; i++)
        {
            GameObject obj1 = Instantiate(Tiles);
            obj1.SetActive(false);
            TilesList.Add(obj1);

        }
        for (int i = 0; i < pullOfObjects60; i++)
        {
            GameObject obj1 = Instantiate(GatherTiles);
            obj1.SetActive(false);
            GatherTilesList.Add(obj1);
        }

        for (int i = 0; i < pullOfObjects10; i++)
        {
            GameObject obj2 = Instantiate(playerFlagship);
            obj2.SetActive(false);
            playerFlagshipList.Add(obj2);

            GameObject obj3 = Instantiate(playerCruiser);
            obj3.SetActive(false);
            playerCruiserList.Add(obj3);

            GameObject obj4= Instantiate(playerDestr);
            obj4.SetActive(false);
            playerDestrList.Add(obj4);


            GameObject obj1 = Instantiate(enemyFlagship);
            obj1.SetActive(false);
            enemyFlagshipList.Add(obj1);

            GameObject obj5 = Instantiate(enemyCruiser);
            obj5.SetActive(false);
            enemyCruiserList.Add(obj5);

            GameObject obj6 = Instantiate(enemyDestr);
            obj6.SetActive(false);
            enemyDestrList.Add(obj6);

            
        }

        for (int i = 0; i < pullOfObjects15; i++)
        {
            GameObject obj1 = Instantiate(HPBurst);
            obj1.SetActive(false);
            HPBurstList.Add(obj1);

            GameObject obj2 = Instantiate(ShotBurst);
            obj2.SetActive(false);
            ShotBurstList.Add(obj2);

            GameObject obj = Instantiate(ShieldBurst);
            obj.SetActive(false);
            ShieldBurstList.Add(obj);

            GameObject obj0 = Instantiate(EnergyBurst);
            obj0.SetActive(false);
            EnergyBurstList.Add(obj0);

            GameObject obj3 = Instantiate(bulletBurst);
            obj3.SetActive(false);
            bulletBurstList.Add(obj3);


            GameObject obj7 = Instantiate(playerFlagshipShot);
            obj7.SetActive(false);
            playerFlagshipShotList.Add(obj7);

            GameObject obj8 = Instantiate(playerCruiserShot);
            obj8.SetActive(false);
            playerCruiserShotList.Add(obj8);

            GameObject obj4 = Instantiate(playerDestrShot);
            obj4.SetActive(false);
            playerDestrShotList.Add(obj4);


            GameObject obj9 = Instantiate(enemyFlagshipShot);
            obj9.SetActive(false);
            enemyFlagshipShotList.Add(obj9);

            GameObject obj5 = Instantiate(enemyCruiserShot);
            obj5.SetActive(false);
            enemyCruiserShotList.Add(obj5);

            GameObject obj6 = Instantiate(enemyDestrShot);
            obj6.SetActive(false);
            enemyDestrShotList.Add(obj6); 
            
            //GameObject obj10 = Instantiate(HPGather);
            //obj10.SetActive(false);
            //HPGatherList.Add(obj10);

            //GameObject obj11 = Instantiate(ShotGather);
            //obj11.SetActive(false);
            //ShotGatherList.Add(obj11);

            //GameObject obj12 = Instantiate(EnergyGather);
            //obj12.SetActive(false);
            //EnergyGatherList.Add(obj12);


            //GameObject obj13 = Instantiate(ShieldGather);
            //obj13.SetActive(false);
            //ShieldGatherList.Add(obj13);

            //GameObject obj14 = Instantiate(AimGather);
            //obj14.SetActive(false);
            //AimGatherList.Add(obj14);

            GameObject obj15 = Instantiate(Asteroid);
            obj15.SetActive(false);
            AsteroidsList.Add(obj15);
            

        }
        for (int i = 0; i < pullOfObjects3; i++)
        {
            GameObject obj1 = Instantiate(flagshipBurst);
            obj1.SetActive(false);
            flagshipBurstList.Add(obj1);

            GameObject obj2 = Instantiate(cruisBurst);
            obj2.SetActive(false);
            cruisBurstList.Add(obj2);

            GameObject obj = Instantiate(destrBurst);
            obj.SetActive(false);
            destrBurstList.Add(obj);


            GameObject obj3 = Instantiate(shieldFlaghipBurst);
            obj3.SetActive(false);
            shieldFlaghipBurstList.Add(obj3);

            GameObject obj4 = Instantiate(shieldCruisBurst);
            obj4.SetActive(false);
            shieldCruisBurstList.Add(obj4);

            GameObject obj5 = Instantiate(shieldDestrBurst);
            obj5.SetActive(false);
            shieldDestrBurstList.Add(obj5);
        }


    }

    public List<GameObject> GetTilePullList()
    {
        return TilesList;
    }
    public List<GameObject> GetGatherTilePullList()
    {
        return GatherTilesList;
    }
    public List<GameObject> GetPlayerShotPullList(int indexOfShip)
    {
        if (indexOfShip == 0) return playerDestrShotList;
        else if (indexOfShip == 1) return playerCruiserShotList;
        else return playerFlagshipShotList;
    }

    //0-destr. 1-cruiser, 2-flagship
    public List<GameObject> GetEnemyShotPullList(int indexOfShip)
    {
        if (indexOfShip == 0) return enemyDestrShotList;
        else if (indexOfShip == 1) return enemyCruiserShotList;
        else return enemyFlagshipShotList;
    }

    //0-destr. 1-cruiser, 2-flagship
    public List<GameObject> GetPlayerShipPullList(int indexOfShip)
    {
        if (indexOfShip == 0) return playerDestrList;
        else if (indexOfShip == 1) return playerCruiserList;
        else return playerFlagshipList;
    }
    //0-destr. 1-cruiser, 2-flagship
    public List<GameObject> GetEnemyShipPullList(int indexOfShip)
    {
        if (indexOfShip == 0) return enemyDestrList;
        else if (indexOfShip == 1) return enemyCruiserList;
        else return enemyFlagshipList;
    }

    //0-destr. 1-cruiser, 2-flagship
    public List<GameObject> GetShipBurstList(int indexOfShip)
    {
        if (indexOfShip == 0) return destrBurstList;
        else if (indexOfShip == 1) return cruisBurstList;
        else return flagshipBurstList;
    }
    //public List<GameObject> GetCruisBurstList()
    //{
    //    return cruisBurstList;
    //}
    //public List<GameObject> GetDestrBurstList()
    //{
    //    return destrBurstList;
    //}
    public List<GameObject> GetBulletBurstList()
    {
        return bulletBurstList;
    }
    public List<GameObject> GetShieldBurstList(int indexOfShip)
    {
        if (indexOfShip == 0) return shieldDestrBurstList;
        else if (indexOfShip == 1) return shieldCruisBurstList;
        else return shieldFlaghipBurstList;
    }


    public List<GameObject> GetBurstList(int index)
    {
        if (index==0) return ShotBurstList;
        else if (index == 1) return EnergyBurstList;
        else if (index == 2) return ShieldBurstList;
        else return HPBurstList;
    }
    //public List<GameObject> GetGatherList(int index)
    //{
    //    if (index == 0) return ShotGatherList;
    //    else if (index == 1) return EnergyGatherList;
    //    else if (index == 2) return ShieldGatherList;
    //    else if (index == 3) return HPGatherList;
    //    else return AimGatherList;
    //}

    public List<GameObject> GetAsteroidsList()
    {
        return AsteroidsList;
    }

    


    //universal method to set active proper game object from the list of GOs, it just needs to get correct List of game objects
    public GameObject GetGameObjectFromPull(List<GameObject> GOLists)
    {
        for (int i = 0; i < GOLists.Count; i++)
        {
            if (!GOLists[i].activeInHierarchy) return GOLists[i];
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(GOLists[0]);
            obj.SetActive(false);
            GOLists.Add(obj);
            return obj;
        }
        return null;
    }
}
