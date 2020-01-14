using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[Header("References")]
	public GameObject PickupPrefab;

	[Header("Difficulty")]
	public float SpawnDelay = 10f;
	public float PickupLifetime = 2f;

	private float _time = 0f;


    void Start()
    {
		ResetTimer();
	}

    void Update()
    {
		_time += Time.deltaTime;

		if (_time > SpawnDelay)
		{
			_time = 0f;
			GameObject spawned = Instantiate(PickupPrefab, Random.insideUnitCircle * Player.instance.Ball.GetInitialRadius(), Quaternion.identity);
			Pickup spawnedPickup = spawned.GetComponent<Pickup>();
			spawnedPickup.transform.localScale = Player.instance.Ball.transform.localScale;
			spawnedPickup.Lifetime = PickupLifetime;
			spawnedPickup.SpawnerRef = this;
		}
    }

	public void ResetTimer()
	{
		_time = SpawnDelay;
	}
}
