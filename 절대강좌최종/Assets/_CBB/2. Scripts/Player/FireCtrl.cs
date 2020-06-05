using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}


public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }

    public WeaponType currWeapon = WeaponType.RIFLE;

    public GameObject bullet;

    private ParticleSystem muzzleFlash;

    private AudioSource _audio;

    public Transform firePos;

    public PlayerSfx playerSfx;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();

        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);

        muzzleFlash.Play();

        FireSfx();
    }

    void FireSfx()
    {
        var _sfx = playerSfx.fire[(int)currWeapon];

        _audio.PlayOneShot(_sfx, 1.0f);
    }
}
