using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerShip : Ship
{
    public override bool canShot()
    {
        if (shotEnergy >= shotPower && shotPower <= energy && EnemyFleetManager.instance.enemyFleet.Count>0) return true;
        else return false;
    }

    public override void makeShot()
    {
        actionsAreOn = true;
        StartCoroutine(makeShotCoroutine());
    }



    private IEnumerator makeShotCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minShotTime, maxShotTime));

        consumeEnergy(shotPower);
        shotEnergy -= shotPower;
        ObjectPulledList = ObjectPuller.current.GetPlayerShotPullList(indexOfShip);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        bulletTransform = ObjectPulled.transform;
        bulletTransform.position = shipPosition;
        PlayerShot shot = ObjectPulled.GetComponent<PlayerShot>();
        if (!shot.isActiveAndEnabled) shot.enabled = true;
        shot._harm = shotPower;

        if (EnemyFleetManager.instance.enemyFleet.Count > 0)
        {
            Ship shipToAttack = EnemyFleetManager.instance.enemyFleet.Count == 1 ? EnemyFleetManager.instance.enemyFleet[0] :
                    EnemyFleetManager.instance.enemyFleet[Random.Range(0, EnemyFleetManager.instance.enemyFleet.Count)];
            attackDirection = shipToAttack.shipPosition;
        }
        else attackDirection = Vector2.up;

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
    //    base.makeBurst();
    //}

    public override void addToFleetManager()
    {
        PlayerFleetManager.instance.playerFleet.Add(this);
    }
    public override void removeFromFleetManager()
    {
        PlayerFleetManager.instance.assignNextShipToEnergyIfThisDestroyed(this);
        PlayerFleetManager.instance.assignNextShipToHPIfThisDestroyed(this);
        PlayerFleetManager.instance.assignNextShipToShotIfThisDestroyed(this);
        PlayerFleetManager.instance.assignNextShipToShieldIfThisDestroyed(this);
        PlayerFleetManager.instance.playerFleet.Remove(this);

    }
}
