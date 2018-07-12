using UnityEngine;
using System.Collections;

public class Done_WeaponControllerBoss : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

    private IEnumerator BoosShoot(float a_Delay) {

        yield return new WaitForSeconds(a_Delay);
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

    }
}
