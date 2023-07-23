using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : Shot
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ship>(out Ship ship))
        {
            base.OnCollisionEnter2D(collision);
            ship.reduceHP(_harm);
            disactivateShot(true);
        }

        if (collision.gameObject.TryGetComponent<PlayerShot>(out PlayerShot shot))
        {
            base.OnCollisionEnter2D(collision);
            disactivateShot(true);
        }

        //_trailRenderer.Clear();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Shield>(out Shield shield))
        {
            float harmBeforeCollision = _harm;
            reduceHarm(shield.shieldEnergy);
            shield.reduceShield(harmBeforeCollision);
            if (_harm <= 0)
            {
                contactPointOfCollider = collision.ClosestPoint(transform.position);
                disactivateShot(true);
            }

        }
        if (collision.gameObject.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            float harmBeforeCollision = _harm;
            reduceHarm(asteroid.getHP());
            asteroid.reduceHP(harmBeforeCollision);
            if (_harm <= 0)
            {
                contactPointOfCollider = collision.ClosestPoint(transform.position);
                disactivateShot(true);
            }
        }
        //_trailRenderer.Clear();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
