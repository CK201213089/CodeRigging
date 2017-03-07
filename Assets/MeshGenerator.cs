using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour {

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

	void Start () {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        GenerateMesh();
	}
	void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] verts = new Vector3[8];
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(1, 0, 0);
        verts[2] = new Vector3(0, 0, 1);
        verts[3] = new Vector3(1, 0, 1);

        verts[4] = new Vector3(0, 1, 0);
        verts[5] = new Vector3(1, 1, 0);
        verts[6] = new Vector3(0, 1, 1);
        verts[7] = new Vector3(1, 1, 1);

        mesh.vertices = verts;
        List<int> tris = new List<int>();
        tris.Add(0);
        tris.Add(1);
        tris.Add(2);

        tris.Add(2);
        tris.Add(1);
        tris.Add(3);

        tris.Add(0);
        tris.Add(4);
        tris.Add(1);

        tris.Add(1);
        tris.Add(4);
        tris.Add(5);

        tris.Add(2);
        tris.Add(6);
        tris.Add(0);

        tris.Add(0);
        tris.Add(6);
        tris.Add(4);

        tris.Add(4);
        tris.Add(6);
        tris.Add(5);

        tris.Add(7);
        tris.Add(5);
        tris.Add(6);

        tris.Add(1);
        tris.Add(5);
        tris.Add(3);

        tris.Add(3);
        tris.Add(5);
        tris.Add(7);

        tris.Add(2);
        tris.Add(3);
        tris.Add(6);

        tris.Add(3);
        tris.Add(7);
        tris.Add(6);

        Vector2[] uvs = new Vector2[verts.Length];

        uvs[0]=new Vector2(0.0f, 0.0f);
        uvs[1]=new Vector2(1.0f, 0.0f);
        uvs[2]=new Vector2(0.0f, 1.0f);
        uvs[3] = new Vector2(1.0f, 1.0f);

        uvs[4] = new Vector2(0.0f, 0.0f);
        uvs[5] = new Vector2(1.0f, 0.0f);
        uvs[6] = new Vector2(0.0f, 1.0f);
        uvs[7] = new Vector2(1.0f, 1.0f);

        mesh.uv = uvs;
        mesh.colors=new Color[]{
            Color.red,
            Color.blue,
            Color.green,
            Color.magenta,
            Color.red,
            Color.blue,
            Color.green,
            Color.magenta
        };


        mesh.triangles = tris.ToArray();

        meshFilter.mesh = mesh;

        
    }

	void Update () {
		
	}
}
