using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour
{
	public WayPoint next;

	void OnDrawGizmosSelected ()
	{
		WayPointPath wayPointPath = null;
		Transform target = this.transform.parent;
		while (target && !(wayPointPath = target.GetComponent<WayPointPath>())) { target = target.parent; }

		if (wayPointPath && (System.Array.IndexOf(wayPointPath.wayPoints, this) >= 0)) {
			wayPointPath.OnDrawGizmosSelected();
		}
	}
}
