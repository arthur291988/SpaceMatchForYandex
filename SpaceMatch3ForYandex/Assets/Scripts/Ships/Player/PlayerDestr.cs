using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestr : PlayerShip
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

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

    //public override void makeShot()
    //{
    //    ObjectPulledList = ObjectPuller.current.GetPlayerFlagshipShotPullList();
    //    ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
    //    bulletTransform = ObjectPulled.transform;
    //    bulletTransform.position = shipPosition;
    //    PlayerShot shot = ObjectPulled.GetComponent<PlayerShot>();
    //    if (!shot.isActiveAndEnabled) shot.enabled = true;
    //    shot._harm = shotPower;


    //    Ship shipToAttack = EnemyFleetManager.instance.enemyFleet.Count == 1 ? EnemyFleetManager.instance.enemyFleet[0] :
    //            EnemyFleetManager.instance.enemyFleet[Random.Range(0, EnemyFleetManager.instance.enemyFleet.Count)];


    //    attackDirection = shipToAttack.shipPosition;

    //    attackDirection -= shipPosition;
    //    if (aimingCount == 0) attackDirection = RotateAttackVector(attackDirection, Random.Range(-accuracy, accuracy)); //if ship has aiming its vector is not disordered by accuracy

    //    bulletTransform.rotation = Quaternion.FromToRotation(bulletRotateBase, attackDirection);
    //    ObjectPulled.SetActive(true);

    //    ObjectPulled.GetComponent<Rigidbody2D>().AddForce(attackDirection.normalized * shotImpulse, ForceMode2D.Impulse);

    //    base.makeShot();
    //}

    //public override void makeBurst()
    //{
    //    ObjectPulledList = ObjectPuller.current.GetDestrBurstList();
    //    base.makeBurst();
    //}


    //public override void addToFleetManager()
    //{
    //    PlayerFleetManager.instance.playerFleet.Add(this);
    //}
    //public override void removeFromFleetManager()
    //{
    //    PlayerFleetManager.instance.assignNextShipToEnergyIfThisDestroyed(this);
    //    PlayerFleetManager.instance.assignNextShipToHPIfThisDestroyed(this);
    //    PlayerFleetManager.instance.assignNextShipToShotIfThisDestroyed(this);
    //    PlayerFleetManager.instance.assignNextShipToShieldIfThisDestroyed(this);
    //    PlayerFleetManager.instance.playerFleet.Remove(this);

    //}

}
