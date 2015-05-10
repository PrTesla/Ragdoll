﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class StartButton : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
	{
		transform.DOMoveX(1000, 1).SetEase(Ease.InBack);
		FindObjectsOfType<ButtonScript>()[0].transform.DOMoveY(800, 1.4f).SetEase(Ease.InBack).OnStepComplete(goToNextLevel);
		FindObjectsOfType<ButtonScript>()[1].transform.DOMoveY(800, 1.2f).SetEase(Ease.InBack);
		FindObjectsOfType<ButtonScript>()[2].transform.DOMoveY(800, 1.0f).SetEase(Ease.InBack);
		GameObject.FindWithTag("Player").transform.DOMoveY(-10, 1.0f).SetEase(Ease.InBack);
    }

	void goToNextLevel()
	{
		foreach( PivotScript ps in FindObjectsOfType<PivotScript>() )
			Destroy( ps.gameObject );
		foreach( BindToLamb ps in FindObjectsOfType<BindToLamb>() )
			Destroy( ps.gameObject );
		foreach( PivotTrigger pt in FindObjectsOfType<PivotTrigger>() )
			Destroy( pt );
		foreach( LambsManager ps in FindObjectsOfType<LambsManager>() )
			Destroy( ps );

		player.transform.position = startPos;
		player.GetComponent<Rigidbody2D>().isKinematic = false;
		Application.LoadLevel(1);		
	}
}
