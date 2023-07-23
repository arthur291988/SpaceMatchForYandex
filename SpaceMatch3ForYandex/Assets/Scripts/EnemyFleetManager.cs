using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleetManager : MonoBehaviour
{
    [NonSerialized]
    public List<Ship> enemyFleet;
    [NonSerialized]
    public Ship nextShipToEnergy;
    [NonSerialized]
    public Ship nextShipToShot;
    [NonSerialized]
    public Ship nextShipToHP;
    [NonSerialized]
    public Ship nextShipToShield;

    // Start is called before the first frame update

    public static EnemyFleetManager instance;
    private float HPAddValue;
    private float ShieldAddValue;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {

        enemyFleet = new List<Ship>();
    }

    //void Start()
    //{
    //}

    public void startSettings() {
        nextShipToEnergy = enemyFleet[0];
        nextShipToShot = enemyFleet[0];
        nextShipToHP = enemyFleet[0];
        nextShipToShield = enemyFleet[0];
        HPAddValue = 0.2f;
        ShieldAddValue = 0.3f; //uses energy
    }

    public void assignNextShipToEnergy () {
        if (enemyFleet.Count > 1)
        {
            int x = enemyFleet.IndexOf(nextShipToEnergy) + 1;
            if (x < enemyFleet.Count) nextShipToEnergy = enemyFleet[x];
            else nextShipToEnergy = enemyFleet[0];
        }
        else if (enemyFleet.Count>0) nextShipToEnergy = enemyFleet[0];
    }

    public void assignNextShipToEnergyIfThisDestroyed(Ship ship) {
        if (ship == nextShipToEnergy) {
            if (enemyFleet.Count > 1)
            {
                int x = enemyFleet.IndexOf(ship);
                if (x < enemyFleet.Count - 1) nextShipToEnergy = enemyFleet[x + 1];
                else nextShipToEnergy = enemyFleet[0];
            }
        }
    }

    public void assignNextShipToHP()
    {
        if (enemyFleet.Count > 1)
        {
            int x = enemyFleet.IndexOf(nextShipToHP) + 1;
            if (x < enemyFleet.Count) nextShipToHP = enemyFleet[x];
            else nextShipToHP = enemyFleet[0];
        }
        else if (enemyFleet.Count > 0) nextShipToHP = enemyFleet[0];
    }

    public void assignNextShipToHPIfThisDestroyed(Ship ship)
    {
        if (ship == nextShipToHP)
        {
            if (enemyFleet.Count > 1)
            {
                int x = enemyFleet.IndexOf(ship);
                if (x < enemyFleet.Count - 1) nextShipToHP = enemyFleet[x + 1];
                else nextShipToHP = enemyFleet[0];
            }
        }
    }

    public void assignNextShipToShot()
    {
        if (enemyFleet.Count > 1)
        {
            int x = enemyFleet.IndexOf(nextShipToShot) + 1;
            if (x < enemyFleet.Count) nextShipToShot = enemyFleet[x];
            else nextShipToShot = enemyFleet[0];
        }
        else if (enemyFleet.Count > 0) nextShipToShot = enemyFleet[0];
    }

    public void assignNextShipToShotIfThisDestroyed(Ship ship)
    {
        if (ship == nextShipToShot)
        {
            if (enemyFleet.Count > 1)
            {
                int x = enemyFleet.IndexOf(ship);
                if (x < enemyFleet.Count - 1) nextShipToShot = enemyFleet[x + 1];
                else nextShipToShot = enemyFleet[0];
            }
        }
    }

    public void assignNextShipToShield()
    {
        if (enemyFleet.Count > 1)
        {
            int x = enemyFleet.IndexOf(nextShipToShot) + 1;
            if (x < enemyFleet.Count) nextShipToShield = enemyFleet[x];
            else nextShipToShield = enemyFleet[0];
        }
        else if (enemyFleet.Count > 0) nextShipToShield = enemyFleet[0];
    }

    public void assignNextShipToShieldIfThisDestroyed(Ship ship)
    {
        if (ship == nextShipToShield)
        {
            if (enemyFleet.Count > 1)
            {
                int x = enemyFleet.IndexOf(ship);
                if (x < enemyFleet.Count - 1) nextShipToShield = enemyFleet[x + 1];
                else nextShipToShield = enemyFleet[0];
            }
        }
    }

    public void distributeResources(int index, int value, int comboValue)
    {
        if (index == 0)
        {
            for (int i = 0; i < value; i++)
            {
                nextShipToShot.increaseShotPower();
                assignNextShipToShot();
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < value; i++)
            {
                nextShipToEnergy.increaseEnergy();
                assignNextShipToEnergy();
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < value; i++)
            {
                if (nextShipToShield.shield.activeInHierarchy) nextShipToShield.healShield();
                else nextShipToShield.cumulateShiled();

                assignNextShipToShield();
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < value; i++)
            {
                nextShipToHP.healHP();
                assignNextShipToHP();
            }
        }
        //aiming add accures randomely
        else if (index == 4)
        {
            if (enemyFleet.Count > 0)
            {
                for (int i = 0; i < value; i++)
                {
                    enemyFleet[UnityEngine.Random.Range(0, enemyFleet.Count)].increaseAimingCount();
                }
            }
        }
        if (comboValue > 3) processComno(index, comboValue);

    }

    public void processComno(int index, int comboValue)
    {
        if (comboValue == 4)
        {
            distributeResources(UnityEngine.Random.Range(0, 5), 2, 0); //0 is default, 2 meanse two additional random resource
        }

        //0 - shot, 1 - energy, 2 - shield, 3 - HP 
        if (comboValue == 5)
        {
            if (index == 0)
            {
                distributeResources(4, 3, 0); //4 is aim, 3 - value, 0 is default no combo call, 
                distributeResources(1, 3, 0); //1 is energy, 3 - value, 0 is default no combo call, 
                distributeResources(0, 2, 0); //0 is shot, 2 - value, 0 is default no combo call, 
            }
            if (index == 1)
            {
                distributeResources(2, 3, 0);
                distributeResources(4, 1, 0);
                distributeResources(0, 2, 0);
            }
            if (index == 2)
            {
                distributeResources(1, 3, 0);
                distributeResources(3, 3, 0);
                distributeResources(4, 1, 0);
            }
            if (index == 3)
            {
                distributeResources(1, 3, 0);
                distributeResources(2, 3, 0);
                distributeResources(4, 1, 0);
            }
        }
        if (comboValue == 6)
        {
            if (index == 0)
            {
                distributeResources(4, 5, 0);
                distributeResources(1, 4, 0);
                distributeResources(0, 2, 0);
                distributeResources(3, 2, 0);
            }
            if (index == 1)
            {
                distributeResources(2, 4, 0);
                distributeResources(0, 3, 0);
                distributeResources(1, 2, 0);
                distributeResources(3, 2, 0);
                distributeResources(4, 2, 0);
            }
            if (index == 2)
            {
                distributeResources(3, 5, 0);
                distributeResources(1, 3, 0);
                distributeResources(4, 2, 0);
                distributeResources(0, 2, 0);
            }
            if (index == 3)
            {
                distributeResources(1, 3, 0);
                distributeResources(2, 3, 0);
                distributeResources(0, 2, 0);
                distributeResources(4, 2, 0);
            }
        }
        if (comboValue == 7)
        {
            if (index == 0)
            {
                distributeResources(4, 7, 0);
                distributeResources(1, 6, 0);
                distributeResources(0, 3, 0);
                distributeResources(3, 3, 0);
            }
            if (index == 1)
            {
                distributeResources(2, 6, 0);
                distributeResources(0, 5, 0);
                distributeResources(1, 3, 0);
                distributeResources(3, 2, 0);
                distributeResources(4, 3, 0);
            }
            if (index == 2)
            {
                distributeResources(3, 7, 0);
                distributeResources(1, 5, 0);
                distributeResources(4, 3, 0);
                distributeResources(0, 3, 0);
            }
            if (index == 3)
            {
                distributeResources(1, 5, 0);
                distributeResources(2, 5, 0);
                distributeResources(0, 4, 0);
                distributeResources(4, 3, 0);
            }
        }
    }

    public void checkActionsOfFleet()
    {
        foreach (Ship ship in enemyFleet) ship.checkActions();
    }


    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
