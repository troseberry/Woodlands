using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTreeCuts : MonoBehaviour 
{
	public bool rotatedCube;

	private float cutInc = 1f/9f;

	Vector3[] newVertices;
	Vector2[] newUV;
	int[] newTriangles;

	Mesh mesh;

	Vector3 vertLeftBottomFront = new Vector3(-0.5f, -0.5f, 0.5f);
	Vector3 vertRightBottomFront = new Vector3(0.5f, -0.5f, 0.5f);

	Vector3 vertLeftBottomBack = new Vector3(-0.5f, -0.5f, -0.5f);
	Vector3 vertRightBottomBack = new Vector3(0.5f, -0.5f, -0.5f);


	Vector3 vertLeftTopFront = new Vector3(-0.5f, 0.5f, 0.5f);
	Vector3 vertRightTopFront = new Vector3(0.5f, 0.5f, 0.5f);

	Vector3 vertLeftTopBack = new Vector3(-0.5f, 0.5f, -0.5f);
	Vector3 vertRightTopBack = new Vector3(0.5f, 0.5f, -0.5f);
	
	void Start()
	{
		mesh = GetComponent<MeshFilter>().mesh;
	}

	void Redraw () 
	{
		//Vertices
		newVertices = new Vector3[]
		{
			//Front Face
			vertLeftTopFront,	 //left top front, 0
			vertRightTopFront,   //right top front, 1
			vertLeftBottomFront,             //left bottom front, 2
			vertRightBottomFront,		     //right bottom front, 3

			//Back Face
			vertRightTopBack,	  //right top back, 4
			vertLeftTopBack,  //left top back, 5
			vertRightBottomBack,  //right bottom back, 6
			vertLeftBottomBack, //left bottom back, 7

			//Left Face
			vertLeftTopBack,  //left top back, 8
			vertLeftTopFront,   //left top front, 9
			vertLeftBottomBack, //left bottom back, 10
			vertLeftBottomFront,  //left bottom front, 11

			//Right Face
			vertRightTopFront,    //right top front, 12
			vertRightTopBack,   //right top back, 13
			vertRightBottomFront,   //right bottom front, 14
			vertRightBottomBack,  //right bottom back, 15

			//Top Face
			vertLeftTopBack,  //left top back, 16
			vertRightTopBack,   //right top back, 17
			vertLeftTopFront,   //left top front, 18
			vertRightTopFront,    //right top front, 19

			//Bottom Face
			vertLeftBottomFront,  //left bottom front, 20
			vertRightBottomFront,   //right bottom front, 21
			vertLeftBottomBack, //left bottom back, 22
			vertRightBottomBack   //right bottom back, 23
		};

		//Triangles
		newTriangles = new int[]
		{
			//Front Face
			0, 2, 3, //first triangle
			3, 1, 0, //second triangle

			//Back Face
			4, 6, 7, //first triangle
			7, 5, 4,  //second triangle

			//Left Face
			8, 10, 11, //first triangle
			11, 9, 8,  //second triangle

			//Right Face
			12, 14, 15, //first triangle
			15, 13, 12,  //second triangle

			//Top Face
			16, 18, 19, //first triangle
			19, 17, 16,  //second triangle

			//Bottom Face
			20, 22, 23, //first triangle
			23, 21, 20  //second triangle
		};

		//UVs
		newUV = new Vector2[]
		{
			//0, 0 is bottom left. 1,1 is top right

			//Front Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0),

			//Back Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0),

			//Left Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0),

			//Right Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0),

			//Top Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0),

			//Bottom Face
			new Vector2(0, 0.5f),	
			new Vector2(0, 0),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 0)
		};

		mesh.Clear();
		mesh.vertices = newVertices;
		mesh.triangles = newTriangles;
		mesh.uv = newUV;
		mesh.RecalculateNormals();
	}
	

	//front = 3, back = 2, right = 1, left = 0
	public void CutFace(int side)
	{
		if (!rotatedCube)
		{
			if (side == 0)
			{
				vertLeftBottomFront = new Vector3(vertLeftBottomFront.x + cutInc, vertLeftBottomFront.y, vertLeftBottomFront.z);
				vertLeftBottomBack = new Vector3(vertLeftBottomBack.x + cutInc, vertLeftBottomBack.y, vertLeftBottomBack.z);
			}
			else if (side == 1)
			{
				vertRightBottomFront = new Vector3(vertRightBottomFront.x - cutInc, vertRightBottomFront.y, vertRightBottomFront.z);
				vertRightBottomBack = new Vector3(vertRightBottomBack.x - cutInc, vertRightBottomBack.y, vertRightBottomBack.z);
			}
			else if (side == 2)
			{
				vertLeftBottomBack = new Vector3(vertLeftBottomBack.x, vertLeftBottomBack.y, vertLeftBottomBack.z + cutInc);
				vertRightBottomBack = new Vector3(vertRightBottomBack.x, vertRightBottomBack.y, vertRightBottomBack.z + cutInc);
			}
			else if (side == 3)
			{
				vertLeftBottomFront = new Vector3(vertLeftBottomFront.x, vertLeftBottomFront.y, vertLeftBottomFront.z - cutInc);
				vertRightBottomFront = new Vector3(vertRightBottomFront.x, vertRightBottomFront.y, vertRightBottomFront.z - cutInc);
			}
		}
		else
		{
			if (side == 0)
			{
				vertLeftTopFront = new Vector3(vertLeftTopFront.x + cutInc, vertLeftTopFront.y, vertLeftTopFront.z);
				vertLeftTopBack = new Vector3(vertLeftTopBack.x + cutInc, vertLeftTopBack.y, vertLeftTopBack.z);
			}
			else if (side == 1)
			{
				vertRightTopFront = new Vector3(vertRightTopFront.x - cutInc, vertRightTopFront.y, vertRightTopFront.z);
				vertRightTopBack = new Vector3(vertRightTopBack.x - cutInc, vertRightTopBack.y, vertRightTopBack.z);
			}
			else if (side == 2)
			{
				vertLeftTopBack = new Vector3(vertLeftTopBack.x, vertLeftTopBack.y, vertLeftTopBack.z + cutInc);
				vertRightTopBack = new Vector3(vertRightTopBack.x, vertRightTopBack.y, vertRightTopBack.z + cutInc);
			}
			else if (side == 3)
			{
				vertLeftTopFront = new Vector3(vertLeftTopFront.x, vertLeftTopFront.y, vertLeftTopFront.z - cutInc);
				vertRightTopFront = new Vector3(vertRightTopFront.x, vertRightTopFront.y, vertRightTopFront.z - cutInc);
			}
		}
		Redraw();
	}

	public void ResetToDefault()
	{
		vertLeftBottomFront = new Vector3(-0.5f, -0.5f, 0.5f);
		vertRightBottomFront = new Vector3(0.5f, -0.5f, 0.5f);

		vertLeftBottomBack = new Vector3(-0.5f, -0.5f, -0.5f);
		vertRightBottomBack = new Vector3(0.5f, -0.5f, -0.5f);

		vertLeftTopFront = new Vector3(-0.5f, 0.5f, 0.5f);
		vertRightTopFront = new Vector3(0.5f, 0.5f, 0.5f);

		vertLeftTopBack = new Vector3(-0.5f, 0.5f, -0.5f);
		vertRightTopBack = new Vector3(0.5f, 0.5f, -0.5f);

		Redraw();
	}
}
