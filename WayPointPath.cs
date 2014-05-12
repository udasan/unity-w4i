using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointPath : MonoBehaviour
{
	public static Dictionary<string, WayPointPath> paths = new Dictionary<string, WayPointPath>();

	public static WayPointPath Get (string pathName)
	{
		WayPointPath wayPointPath;
		paths.TryGetValue(pathName, out wayPointPath);
		return wayPointPath;
	}

	public string pathName;
	public WayPoint head;

	public Color pathColor = Color.cyan;

	public WayPoint[] wayPoints {
		get {
			List<WayPoint> nodes = new List<WayPoint>();
			WayPoint node = head;
			while (node) {
				nodes.Add(node);
				node = node.next;
			}
			return nodes.ToArray();
		}
	}

	public Vector3[] path {
		get {
			return System.Array.ConvertAll(wayPoints, x => x.transform.position);
		}
	}

	void OnEnable ()
	{
		if (!paths.ContainsKey(pathName)) {
			paths.Add(pathName, this);
		}
	}
	
	void OnDisable ()
	{
		paths.Remove(pathName);
	}

	public void OnDrawGizmosSelected ()
	{
		if (head && head.next) { // path.Length >= 2
			iTween.DrawPath(path, pathColor);
		}
	}
}
