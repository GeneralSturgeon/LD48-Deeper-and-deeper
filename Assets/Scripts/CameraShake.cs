using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public static CameraShake instance;

	public Transform camTransform;

	private float shakeDuration = 0f;
	private float shakeAmount = 0.7f;
	private float decreaseFactor = 1.0f;
	Vector3 originalPos;
	private bool isShaking = false;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	void Start()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (isShaking)
		{
			if (shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakeDuration = 0f;
				camTransform.localPosition = originalPos;
				isShaking = false;
			}
		}

	}

	public void Shake(float duration, float amount, float decrease)
	{
		if (!isShaking)
		{
			originalPos = camTransform.localPosition;
		}
		shakeAmount = amount;
		decreaseFactor = decrease;
		shakeDuration = duration;
		isShaking = true;
	}
}
