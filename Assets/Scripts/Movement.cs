using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private Transform _waypointsParrent;

    private Transform[] _waypoints;
    private int _targetWaypointIndex = 0;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParrent.childCount];

        for (int i = 0; i < _waypointsParrent.childCount; i++)
            _waypoints[i] = _waypointsParrent.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 _targetWaypoint = _waypoints[_targetWaypointIndex].position;
        transform.forward = _targetWaypoint - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint, _speed * Time.deltaTime);

        if (transform.position == _targetWaypoint)
            SetNextTargetWaypoint();
    }

    private Vector3 SetNextTargetWaypoint()
    {
        _targetWaypointIndex = (_targetWaypointIndex + 1) % _waypoints.Length;
        Vector3 nextTargetWaypoint = _waypoints[_targetWaypointIndex].position;

        return nextTargetWaypoint;
    }
}