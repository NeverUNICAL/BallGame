using UnityEngine;

public class CameraMover : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothSpeed;
	[SerializeField] private Vector3 _offset;

	private Vector3 _velocity;

	private void Start()
	{
		_velocity = Vector3.zero;
	}

	void FixedUpdate ()
	{
		Vector3 desiredPosition = new Vector3(_target.position.x, _target.position.z) + _offset;
		Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref _velocity, _smoothSpeed);
		transform.position = smoothedPosition;
	}

}
