using UnityEngine;
[RequireComponent (typeof(PlayerMotor))]//подключить скрипт PlayMode
public class PlauerController : MonoBehaviour {

	[SerializeField]//можно редактировать переменную в Unity
	private float speed = 5f;//скорость игрока
	[SerializeField]
	private float lookSpeed = 3f;

	private PlayerMotor motor;

	void Start (){
		motor = GetComponent<PlayerMotor> ();
	}

	void Update(){
		float xMov = Input.GetAxisRaw ("Horizontal");//движение по x
		float zMov = Input.GetAxisRaw ("Vertical");//движение по z

		Vector3 movHor = transform.right * xMov;
		Vector3 movVer = transform.forward * zMov;

		Vector3 velociti = (movHor + movVer).normalized * speed;//объединения движения

		motor.Move (velociti);//применяем к объекту

		float yRot = Input.GetAxisRaw ("Mouse X");//отслеживаем движение мыши
		Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSpeed;

		motor.Rotate (rotation);//применяем к объекту

		float xRot = Input.GetAxisRaw ("Mouse Y");//отслеживаем движение мыши
		Vector3 camRotation = new Vector3 (xRot, 0f, 0f) * lookSpeed;

		motor.RotateCam (camRotation);//применяем к объекту
	}
}
