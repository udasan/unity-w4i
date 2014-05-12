using UnityEngine;
using System.Collections;

public class WayPointAgentSample : MonoBehaviour
{
	public string tweenName;
	public string pathName;
	public bool moveToPath = true;
	public float speed = 1.0f;
	public iTween.EaseType easeType = iTween.EaseType.linear;

	void Start ()
	{
		iTween.MoveTo(this.gameObject, iTween.Hash(
			"name", tweenName,
			"path", WayPointPath.Get(pathName).path,
			"movetopath", moveToPath,
			"speed", speed,
			"easetype", easeType));
	}
}
