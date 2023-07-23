using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCruiser : EnemyShip
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}


    public override void StartSettings()
    {
        base.StartSettings();

        accuracy = 0.17f; //0.2f
        shotImpulse = 15; //15
        shotPower = 0.7f; //0.7
        shieldEnergyMax = 3.5f; //3
        HPMax = 5.5f; //5
        HP = HPMax;
        energyMax = 7; //7
        energy = energyMax;
        minShotTime = 0.3f; //0.5
        maxShotTime = 0.85f; //1.5
        shotEnergyMax = 3;

        updateLifeLine();
        updateEnergyLine();
        updateShieldLine();
        updateShotLine();
    }


    //public override void makeShot()
    //{
    //    ObjectPulledList = ObjectPuller.current.GetEnemyShotPullList();
    //    ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
    //    bulletTransform = ObjectPulled.transform;
    //    bulletTransform.position = shipPosition;
    //    EnemyShot shot = ObjectPulled.GetComponent<EnemyShot>();
    //    if (!shot.isActiveAndEnabled) shot.enabled = true;
    //    shot._harm = shotPower;

    //    Ship shipToAttack = PlayerFleetManager.instance.playerFleet.Count == 1 ? PlayerFleetManager.instance.playerFleet[0] :
    //            PlayerFleetManager.instance.playerFleet[Random.Range(0, PlayerFleetManager.instance.playerFleet.Count)];

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
    //    ObjectPulledList = ObjectPuller.current.GetCruisBurstList();
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