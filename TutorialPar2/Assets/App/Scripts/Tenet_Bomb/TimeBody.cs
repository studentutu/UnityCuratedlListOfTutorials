using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {
	
	Dictionary<string, int> DictionaryOfStrings = new Dictionary<string, int>();

	bool isRewinding = false;

	public float recordTime = 5f;

	List<PointInTime> pointsInTime;

	Rigidbody rb;

	private System.Action<int> doSomething; // void anymethod(.....)
	private System.Func<bool,string, int> getSomething;  // int

	public static event System.Action OnUpdaetEvent;
	
	// Use this for initialization
	void Start () {
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();

		doSomething = (index) => { };
		getSomething = (anybool, anystring) =>
		{
			return anybool ? 1 : 0;
		};
		
		DictionaryOfStrings.Add("Roman", 25);
//		DictionaryOfStrings.Add("Roman", 25);
		if (DictionaryOfStrings.ContainsKey("Roman"))
		{
			Debug.Log("Yes, " + DictionaryOfStrings["Roman"]);
		}

		DictionaryOfStrings.Remove("Roman");

		var getfromDelegate = getSomething.Invoke(true, "");
		CallMyself(0);
		var GetFT = GetFromTuples();
		
		// anyST == Changred
	}

	private System.Tuple<int, string> GetFromTuples()
	{
		
		return new System.Tuple<int, string>(1, "Changed");
	}


	/// <summary>
	/// any
	/// </summary>
	/// <param name="initial"></param>
	private int CallMyself(int initial)
	{
		if (initial>10)
		{
			return initial;
		}
		Debug.Log(initial);
		return CallMyself(initial + 1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.F1))
			StopRewind();
		
		OnUpdaetEvent?.Invoke();
	}

	void FixedUpdate ()
	{
		if (isRewinding)
			Rewind();
		
		else
			Record();

	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		} else
		{
			StopRewind();
			doSomething?.Invoke(4);
		}
		
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind ()
	{
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind ()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}
}
