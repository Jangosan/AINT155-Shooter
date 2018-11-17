using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFiringController : MonoBehaviour {

   
    //TIMING----------------------------------------

    //Check to see if weapon is firing
    public bool isFiring = false;
    
    //Used to see if the wait before firing coroutine is running
    public bool waitIsRunning = false;



    //ADJUSTABLE WEAPON PARAMETERS------------------------------

    //the number of projectile in one shot
    public int projectileCount;

    //the maximum angle that can be added or subtracted to the direction of the spawned projectiles
    public float weaponSpread;

    //The projectile prefab
    public GameObject bulletPrefab;

    //The location that the bullet spawns at
    public Transform bulletSpawn;

    //The interval between each shot
    public float fireTime = 0.5f;

    //Is the weapon single shot or automatic?
    public bool singleShot;

    //AMMO---------------------------------------------------

    //The amount of ammo in a clip
    public int clipMax;

    //The initial amount of ammunition in the weapon
    public int initAmmo;

    //The maximum amount of ammunition this weapon can have
    public int ammoMax;

    //The current amount of ammunition in the clip
    public int currentClip;

    //The current amount of amnunition in reserve
    public int currentReserve;


    //ANIMATION VARIABLES----------------------------------------

    //array used to store sprites for firing animation
    public Sprite[] playerSprites;

    //stores the sprite renderer component of this game object, in this case the player sprite
    SpriteRenderer PlayerSpriteRenderer;

    //stores the sprite renderer component of the weapon
    SpriteRenderer WeaponSpriteRenderer;

   
    
    private void Start () {
       
        //get the sprite renderer component of the game object
        WeaponSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //get the sprite renderer component from the weapon, which is a child of the player game object
        GameObject player;
        player = transform.parent.gameObject;
        PlayerSpriteRenderer = player.GetComponent<SpriteRenderer>();


        //1
        loadClip(initAmmo);

        gameObject.SendMessage("setWeaponName", gameObject.name);
       
    }	

    //Handles loading of the clip and removing ammo from the reserve on reloads and inital load
    private void loadClip(int ammoAmount)
    {

        //if the total amount of ammo is less than the amount in one clip
        if (ammoAmount < clipMax)
        {
            currentClip = ammoAmount;
            currentReserve = 0;
        }
        //if the clip is greater than 0
        else if(currentClip > 0) {
            currentReserve = currentReserve + currentClip;
            currentClip = clipMax;
            currentReserve = ammoAmount - currentClip;
        }
        //1
        else
        {
            currentClip = clipMax;
            currentReserve = ammoAmount - currentClip;
        }

        updateUIAmmo();
    }


	private void Update () {

        if (Input.GetButton("Reload") && currentClip < clipMax)
        {
            //2
            loadClip(currentReserve + currentClip);
        }

        if (currentClip == 0)
        {
            return;
            
        }
        else
        {
            //makes sure the correct sprite is being used for the player and weapon
            if (PlayerSpriteRenderer.sprite == playerSprites[1])
            {
                WeaponSpriteRenderer.sprite = playerSprites[2];
                PlayerSpriteRenderer.sprite = playerSprites[0];
            }
       
            //Checks to see if the player can fire for single shot weapons, if they can, then isFiring is false
            if (singleShot && !waitIsRunning && !Input.GetButton("Fire1"))
            {
                setFiring();
            }



            //Handles swapping of sprites and firing for single and automatic shot weapons
            if (Input.GetButton("Fire1") && !waitIsRunning)
            {

                //if lmb is pressed and the gun is not already firing, the weapon is fired, also switches the sprite when the player fires the weapon
                if (!isFiring)
                {

                    //WeaponSpriteRenderer.sprite = playerSprites[3];
                    //PlayerSpriteRenderer.sprite = playerSprites[1];
                    fire();

                }
                else
                {
                    WeaponSpriteRenderer.sprite = playerSprites[2];
                    PlayerSpriteRenderer.sprite = playerSprites[0];

                }


            }
        }
	}

    private void fire()
    {
        
        isFiring = true;
        //if the game object has an audio source, it will play it when this method is executed
        if (GetComponent<AudioSource>() != null || GetComponentInChildren<ParticleSystem>() != null)
        {
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<AudioSource>().Play();
        }

        
            //creates the desired number of projectiles per shot within a maximum rotation determined by the weapon spread variable
            for (int i = 0; i < projectileCount; i++)
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
            StartCoroutine(waitBeforeFiring());
            currentClip--;
            updateUIAmmo();

        if (!singleShot)
        { 
            //invokes the setFiring method after the specified firing time
            Invoke("setFiring", fireTime);
        }
        

            
    }



    private void setFiring()
    {       
            isFiring = false;
    }

    //Controls the firing intervals for both single shot and automatic weapons
    IEnumerator waitBeforeFiring()
    {
        waitIsRunning = true;

        //waits for the duration of the firing time before running the rest of the coroutine
        yield return new WaitForSeconds(fireTime);
        
        //allows looped firing for automatic weapons
        if (!singleShot)
        {
            setFiring();
        }
       
        //prevents the player from holding down the mouse button to fire with single shot weapons
        else if (singleShot && !Input.GetButton("Fire1"))
        {
            setFiring();
        }            
        waitIsRunning = false;
    }

    //puts the currentClip and currentReserve into an array to be sent over to the updateAmmoCount method
    private void updateUIAmmo()
    {
        int[] ammoInfo = new int[2];

        ammoInfo[0] = currentClip;
        ammoInfo[1] = currentReserve;
        gameObject.SendMessage("updateAmmoCount", ammoInfo);
    }

    public void pickupRestoreAmmo(int ammoAmount)
    {
        if(currentReserve < ammoMax)
        {
            if (currentClip + currentReserve + ammoAmount > ammoMax)
            {
                currentReserve = ammoMax - clipMax;
                updateUIAmmo();
            }
            else if (currentClip < clipMax && currentReserve == 0)
            {
                currentReserve = ammoAmount;
                if (currentClip == 0)
                {
                    loadClip(currentClip + currentReserve);
                }
                updateUIAmmo(); 
            }
            else
            {
                currentReserve = currentReserve + ammoAmount;
                //loadClip(currentReserve + currentClip);
                updateUIAmmo();
            }
            
        }
        
    }

    public void returnAmmoInfo(GameObject sender)
    {
        int[] ammoInfo = new int[3];

        ammoInfo[0] = ammoMax;
        ammoInfo[1] = currentClip + currentReserve;
        ammoInfo[2] = clipMax;
        sender.SendMessage("setCurrentAmmo", ammoInfo, SendMessageOptions.DontRequireReceiver);
    }
}
