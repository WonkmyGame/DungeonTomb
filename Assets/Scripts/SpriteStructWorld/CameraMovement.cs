using DG.Tweening;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Transform oldTarget;

    private float speed = 0.7f;

	private Vector2 velSpeed;

	//private float defaultZoom = 4f;
	public float defaultZoom = 60f;


	private float zoomSpeed = 1f;

	private float velZoom;

	private Vector2 startPos;

	private Transform roomT;

    public float offset;

    public float Y_offset;

	public bool needYLimit = false;
	public bool needXLimit = false;


	public static CameraMovement Instance
	{
		get;
		set;
	}

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    private void Start()
    {
        oldTarget = target;
        offset = 3f;
    }

    public void ResetTarget()
    {
        Target = oldTarget;
        defaultZoom = 5;
        offset = 3f;
    }

    public void SetTarget(Transform trans)
    {
        Target = trans;
        defaultZoom = 3;
        offset = 0.1f;
    }

    private void Awake()
	{
		Instance = this;
		startPos = base.transform.position;
	}

	

	private void FixedUpdate()
	{
		if (this.Target == null)
		{
			return;
		}
		float num = this.Target.GetComponent<Rigidbody2D>().velocity.magnitude;
        Vector2 b = this.Target.GetComponent<Rigidbody2D>().velocity / 1.75f;//+0.7    -0.72
        Vector2 vector = new Vector2(this.Target.transform.position.x + offset, this.Target.transform.position.y+Y_offset) + b;
		if (roomT != null)
		{
			Vector2 vector2 = roomT.position;
			float num2 = 10f;
			if (vector.x > vector2.x + num2)
			{
				vector = new Vector2(vector2.x + num2, vector.y);
			}
			else if (vector.x < vector2.x - num2)
			{
				vector = new Vector2(vector2.x - num2, vector.y);
			}
			if (vector.y > vector2.y + num2)
			{
				vector = new Vector2(vector.x, vector2.y + num2);
			}
			else if (vector.y < vector2.y - num2)
			{
				vector = new Vector2(vector.x, vector2.y - num2);
			}
		}
		base.transform.position = Vector2.SmoothDamp(base.transform.position, vector, ref velSpeed, speed);
		if (num > 11f)
		{
			num = 11f;
		}
		float target = defaultZoom - num;
		Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, target, ref velZoom, zoomSpeed);
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -10f);
		offset = PlayerManager.instance.GetPlayerDir() == 1 ? 3 : -3;
		if(needXLimit)
        {
			if (transform.position.x <= -18)
			{
				transform.position = new Vector3(-18, transform.position.y, -10);
			}
		}			
		
		if(needYLimit)
        {
			if (transform.position.y < 1f)
			{
				transform.position = new Vector3(transform.position.x, 1f, -10);
			}
		}
	}
}
