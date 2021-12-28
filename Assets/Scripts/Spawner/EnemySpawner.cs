using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject Player;
	public GameObject EnemyPrefab;
	public float YPos;
	public float MinScale;
	public float MaxScale;
	public float BaseSpawnDelay;
	public float EnemyBaseVelocity;

	// Private / Hidden variables.
	private bool Spawning;

	public static EnemySpawner Instance;

	private void Awake()
	{
		if(Instance != this)
		{
			Destroy(Instance);
		}
		
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		BaseSpawnDelay -= Time.deltaTime / 150;
		EnemyBaseVelocity -= Time.deltaTime / 150;
		if(BaseSpawnDelay <= 1.05f)
		{
			BaseSpawnDelay = 1.05f;
		}

		if(!Spawning) StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy()
	{
		Spawning = true;
		yield return new WaitForSeconds(BaseSpawnDelay);
		float EnemyScale = Random.Range(MinScale, MaxScale);
		GameObject Enemy = Instantiate(EnemyPrefab, new Vector3((Player.transform.position.x + Random.Range(-EnemyScale, EnemyScale) + Random.Range(-1, 1)), YPos, 0), Quaternion.identity);
		Enemy.transform.localScale = new Vector3(EnemyScale, 1, 1);
		Enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -Mathf.Abs(EnemyBaseVelocity), 0);
		ScoreCounter.Instance.ModifyScore(1, false);
		ScoreCounter.Instance.UpdateUI();
		Spawning = false;
	}
}
