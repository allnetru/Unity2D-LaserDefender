using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig waveConfig;
    [SerializeField] private float moveSpeed = 2f;

    private List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Count) {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
