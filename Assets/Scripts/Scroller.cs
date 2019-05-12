using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{

	public bool CanScroll;

	private Renderer _renderer;
	public float _speed = 0.0125f; //current scrolling speed
	private float _desiredSpeed; //desired scrolling speed
	private float _desiredSpeed2; //half speed
	private float _pos; //total texture offset
	private float _lastChange; //just for demonstration

	protected void Awake()
	{
		_renderer = GetComponent<Renderer>();
		CanScroll = true;

		_desiredSpeed = _speed;
		_lastChange = 0; //just for demonstration
	}

	protected void Update()
	{
		if (!CanScroll) return;
		/*
		//just for demonstration: change desired speed
		if (Time.time > _lastChange + 2) {
			_desiredSpeed = Random.Range(-1f, 0f);
			_lastChange = Time.time;
			Debug.Log ("Set Speed To " + _desiredSpeed);
		}
		*/

		//this is where the magic happens: easing by hand!
		//Play with the value 0.01f to speed up or slow down the easing. 
		//_speed += (_desiredSpeed - _speed) * 0.01f;

		//add current speed to the position

		_pos += _speed * Time.deltaTime;

		//for me it works without Mathf.Repeat
		//float y = Mathf.Repeat(_pos, 1);
		Vector2 offset = new Vector2(_pos, 0);
		_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
