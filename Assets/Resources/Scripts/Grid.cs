using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Grid : MonoBehaviour 
{
	public Vector3 StartingPosition = new Vector3();
	public enum GridType {XbyY}
	public GridType gridType;
	public enum Orientation {TopLeft}
	public Orientation orientation;
	public int XCoords;
	public int YCoords;
	public int XSpacing;
	public int YSpacing;

	public bool createGrid = false;
	public bool clearGrid = false;
	public GameObject SlotPrefabs;

	public List<GameObject>slots = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		ClearGrid ();
		CreateGrid ();
	}
	void ClearGrid ()
	{
		if(clearGrid)
		{
			clearGrid = false;
			for(int i=0;i<slots.Count;i++)
			{
				DestroyImmediate(slots[i]);
			}
			slots.Clear();
		}
	}
	void CreateGrid ()
	{
		if(createGrid)
		{
			createGrid = false;
			int index=0;
			for(int y=0;y<YCoords;y++)
			{
				for(int x=0;x<XCoords;x++)
				{
					GameObject go = Instantiate(SlotPrefabs,Vector3.zero,Quaternion.identity)as GameObject;
					go.name = "Slots"+index.ToString();
					switch(orientation)
					{
					case Orientation.TopLeft:

						go.transform.position = new Vector3(
							StartingPosition.x+x*XSpacing,
							StartingPosition.y,
							StartingPosition.z-y*YSpacing
							);
						break;
					}
					go.transform.parent = gameObject.transform;
					index++;
					slots.Add (go);
				}
			}

		}
	}
}
