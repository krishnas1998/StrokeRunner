using UnityEngine;
using System.Collections;

public class CigaretteSpawn : MonoBehaviour 
{
	public GameObject Obstacle;                                 //The column game object.
	public GameObject emptyObject;
	public int columnPoolSize = 5;                                  //How many columns to keep on standby.
	public float spawnRate = 3f;                                    //How quickly columns spawn.
	private float columnMin = -2.86f;                                   //Minimum y value of the column position.
	private float columnMax = 2.82f;                                  //Maximum y value of the column position.

	private GameObject[] columns;                                   //Collection of pooled columns.
	private int currentColumn = 0;                                  //Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 25f;
	private float spawnZPosition =0f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		columns = new GameObject[columnPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < columnPoolSize; i++)
		{
			//...and create the individual columns.
			columns[i] = (GameObject)Instantiate(Obstacle, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(columnMin, columnMax);

			//...then set the current column to that position.
			columns[currentColumn].transform.position = new Vector3(spawnXPosition, spawnYPosition, spawnZPosition);
			columns [currentColumn].transform.SetParent (emptyObject.transform);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}