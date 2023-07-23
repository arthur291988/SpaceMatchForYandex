using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    public override bool canShot()
    {
        if (shotEnergy >= shotPower && shotPower <= energy && PlayerFleetManager.instance.playerFleet.Count > 0) return true;
        else return false;
    }

    public override void makeShot()
    {
        actionsAreOn = true;
        StartCoroutine(makeShotCoroutine());
    }

    private IEnumerator makeShotCoroutine() {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minShotTime, maxShotTime));

        consumeEnergy(shotPower);
        shotEnergy -= shotPower;
        ObjectPulledList = ObjectPuller.current.GetEnemyShotPullList(indexOfShip);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        bulletTransform = ObjectPulled.transform;
        bulletTransform.position = shipPosition;
        EnemyShot shot = ObjectPulled.GetComponent<EnemyShot>();
        if (!shot.isActiveAndEnabled) shot.enabled = true;
        shot._harm = shotPower;

        if (PlayerFleetManager.instance.playerFleet.Count > 0)
        {
            Ship shipToAttack = PlayerFleetManager.instance.playerFleet.Count == 1 ? PlayerFleetManager.instance.playerFleet[0] :
                    PlayerFleetManager.instance.playerFleet[Random.Range(0, PlayerFleetManager.instance.playerFleet.Count)];

            attackDirection = shipToAttack.shipPosition;
        }
        else attackDirection = Vector2.down;

        attackDirection -= shipPosition;
        if (aimingCount == 0) attackDirection = RotateAttackVector(attackDirection, Random.Range(-accuracy, accuracy)); //if ship has aiming its vector is not disordered by accuracy
        bulletTransform.rotation = Quaternion.FromToRotation(bulletRotateBase, attackDirection);
        ObjectPulled.SetActive(true);

        Rigidbody2D rb = ObjectPulled.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(attackDirection.normalized * shotImpulse, ForceMode2D.Impulse);

        base.makeShot();
    }

    //public override void makeBurst()
    //{
    //    ObjectPulledList = ObjectPuller.current.GetShipBurstList(indexOfShip);
    //    base.makeBurst();
    //}

    public override void addToFleetManager()
    {
        EnemyFleetManager.instance.enemyFleet.Add(this);
    }
    public override void removeFromFleetManager()
    {
        EnemyFleetManager.instance.assignNextShipToEnergyIfThisDestroyed(this);
        EnemyFleetManager.instance.assignNextShipToHPIfThisDestroyed(this);
        EnemyFleetManager.instance.assignNextShipToShotIfThisDestroyed(this);
        EnemyFleetManager.instance.assignNextShipToShieldIfThisDestroyed(this);
        EnemyFleetManager.instance.enemyFleet.Remove(this);

    }
    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
