using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;

    public bool singleShot;

    private bool isFiring = false;

    //array used to store sprites for firing animation
    public Sprite[] playerSprites;

    //the number of projectile in one shot
    public int projectileCount;

    //the maximum angle that can be added or subtracted to the direction of the spawned projectiles
    public float weaponSpread;

    //stores the sprite renderer component of this game object, in this case the player sprite
    SpriteRenderer PlayerSpriteRenderer;

    //stores the sprite renderer component of the weapon
    SpriteRenderer WeaponSpriteRenderer;





    private void setFiring()
    {
        isFiring = false;
    }




    private void Start()
    {
        //get the sprite renderer component of the game object
        PlayerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //get the sprite renderer component from the weapon, which is a child of the player game object
        GameObject weapon;
        weapon = transform.Find("Weapon").gameObject;
        WeaponSpriteRenderer = weapon.GetComponent<SpriteRenderer>();
    }





    private void fire()
    {
        isFiring = true;

        //creates the desired number of projectiles per shot within a maximum rotation determined by the weapon spread variable
        for(int i = 0; i < projectileCount; i++)
        {
            float rotationAdjust;
            Quaternion angleAdjust;
            
            

            //to evenly spread the projectiles, half are rotated less than 0 degrees and half are rotated more than 0 degrees
            if (i < (projectileCount - (projectileCount * 0.5)))
            {
                rotationAdjust = -Random.Range(0, weaponSpread);
                angleAdjust = Quaternion.Euler(0, 0, rotationAdjust);
            }
            else
            {
                rotationAdjust = Random.Range(0, weaponSpread);
                angleAdjust = Quaternion.Euler(0, 0, rotationAdjust);
            }

            angleAdjust = bulletSpawn.rotation * angleAdjust;
            Instantiate(bulletPrefab, bulletSpawn.position, angleAdjust);
        }
        





        //if the game object has an audio source, it will play it when this method is executed
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        if (singleShot == false)
        {
            //invokes the setFiring method after the specified firing time
            Invoke("setFiring", fireTime);
        }
        
       




    }


	void Update () {

        //makes sure the correct sprite is being used for the player and weapon
        if (PlayerSpriteRenderer.sprite == playerSprites[1])
        {
            WeaponSpriteRenderer.sprite = playerSprites[2];
            PlayerSpriteRenderer.sprite = playerSprites[0];
        }

        //if lmb is pressed and the gun is not already firing, the weapon is fired, also switches the sprite when the player fires the weapon
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                WeaponSpriteRenderer.sprite = playerSprites[3];
                PlayerSpriteRenderer.sprite = playerSprites[1];
                fire();
            }
            else
            {
                WeaponSpriteRenderer.sprite = playerSprites[2];
                PlayerSpriteRenderer.sprite = playerSprites[0];
            }
        }
        else if (Input.GetMouseButton(0) != true) {
            setFiring();
        }


        
	}
}
