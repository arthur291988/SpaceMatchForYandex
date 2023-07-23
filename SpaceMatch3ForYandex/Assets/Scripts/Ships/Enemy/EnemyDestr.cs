using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestr : EnemyShip
{

    public override void StartSettings()
    {
        base.StartSettings();

        accuracy = 0.2f; //0.2f
        shotImpulse = 17; //15
        shotPower = 0.5f; //0.7
        shieldEnergyMax = 2; //3
        HPMax = 3.5f; //5
        HP = HPMax;
        energyMax = 5; //7
        energy = energyMax;
        minShotTime = 0.2f; //0.5
        maxShotTime = 0.7f; //1.5
        shotEnergyMax = 2;

        updateLifeLine();
        updateEnergyLine();
        updateShieldLine();
        updateShotLine();
    }


    

    //public override void makeBurst()
    //{
    //    ObjectPulledList = ObjectPuller.current.GetDestrBurstList();
    //    base.makeBurst();
    //}

    //public override void addToFleetManager()
    //{
    //    EnemyFleetManager.instance.enemyFleet.Add(this);
    //}
    //public override void removeFromFleetManager()
    //{
    //    EnemyFleetManager.instance.assignNextShipToEnergyIfThisDestroyed(this);
    //    EnemyFleetManager.instance.assignNextShipToHPIfThisDestroyed(this);
    //    EnemyFleetManager.instance.assignNextShipToShotIfThisDestroyed(this);
    //    EnemyFleetManager.instance.assignNextShipToShieldIfThisDestroyed(this);
    //    EnemyFleetManager.instance.enemyFleet.Remove(this);

    //}
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
