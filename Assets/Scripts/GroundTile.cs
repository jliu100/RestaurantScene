using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;   // want player cannot jump tall obstacle
    //[SerializeField] GameObject kitckenPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); // since there is only one object type of groundspawner, we can use this to find groundspawner
       
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);           // destroy the object after 2 secs after the player leave trigger

    }
   
  
    

    public void SpawnObstacle()

    {

        //Choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random<tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }
        //choose a random point to spawn obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);    // get number from 2 to 4 inclusive, cuz our obstacle objects are child 2-4 in GroundTile
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);     // add "transform" at the end to set its parent, destroy tile along with obstacles

    }
    public void SpawnKitechAsset()
    {
        //Transform spawnPoint = transform.GetChild(5).transform;
        //Instantiate(kitckenPrefab, spawnPoint.position, Quaternion.identity, transform);
        Debug.Log(11);
    }



    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for(int i =0; i<coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;                                                                    // coins spawn at some height
        return point;
    }
}
