using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//подключить Rigidbody
public class PlayerMotor : MonoBehaviour {

	private Rigidbody rb;
	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 rotationCamera = Vector3.zero;

	void Start(){
		rb = GetComponent <Rigidbody> ();
	}

	public void Move (Vector3 _velocity){
		velocity = _velocity;
	}

	public void Rotate (Vector3 _rotation){
		rotation = _rotation;
	}

	public void RotateCam (Vector3 _rotationCam){
		rotationCamera = _rotationCam;
	}


	void FixedUpdate (){
		PerformMove ();
		PerformRotation ();
	}

	void PerformMove (){
		if (velocity != Vector3.zero)
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);//если с толкнулся с объектом движение прекротилось
	}

	void PerformRotation (){
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));//поворот мышью в право/лево
		if (cam != null)
			cam.transform.Rotate (-rotationCamera);
	}
}
