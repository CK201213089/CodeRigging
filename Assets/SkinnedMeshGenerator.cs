using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(SkinnedMeshRenderer))]

public class SkinnedMeshGenerator : MonoBehaviour {


    MeshFilter meshFilter;
    SkinnedMeshRenderer meshRenderer;
    public Material material;
    public Transform[] bones;
    public Transform rootBone;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        GenerateMesh();
    }
    void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> tris = new List<int>();
        //pelvis
        vertices.Add(new Vector3(-1, 0, 0));
        vertices.Add(new Vector3(0, 2, 0));
        vertices.Add(new Vector3(1, 0, 0));
        
        tris.Add(0);
        tris.Add(1);
        tris.Add(2);

        //spine
        vertices.Add(new Vector3(0, 2, 0));
        vertices.Add(new Vector3(-3, 6, 0));
        vertices.Add(new Vector3(3, 6, 0));
        
        tris.Add(3);
        tris.Add(4);
        tris.Add(5);

        //head
        vertices.Add(new Vector3(0, 6, 0));
        vertices.Add(new Vector3(-1, 8, 0));
        vertices.Add(new Vector3(1, 8, 0));
        
        tris.Add(6);
        tris.Add(7);
        tris.Add(8);
        //leftUpperArm
        vertices.Add(new Vector3(-3, 6, 0));
        vertices.Add(new Vector3(-3, 2, 0));
        vertices.Add(new Vector3(-5, 2, 0));

        tris.Add(9);
        tris.Add(10);
        tris.Add(11);
        //leftArm
        vertices.Add(new Vector3(-3, 2, 0));
        vertices.Add(new Vector3(-3, 0, 0));
        vertices.Add(new Vector3(-5, 2, 0));

        tris.Add(12);
        tris.Add(13);
        tris.Add(14);
        //rightUpperArm
        vertices.Add(new Vector3(3, 6, 0));
        vertices.Add(new Vector3(5, 2, 0));
        vertices.Add(new Vector3(3, 2, 0));

        tris.Add(15);
        tris.Add(16);
        tris.Add(17);
        //rightArm
        vertices.Add(new Vector3(3, 2, 0));
        vertices.Add(new Vector3(5, 2, 0));
        vertices.Add(new Vector3(3, 0, 0));

        tris.Add(18);
        tris.Add(19);
        tris.Add(20);
        //leftUpperLeg
        vertices.Add(new Vector3(-1, 0, 0));
        vertices.Add(new Vector3(-1, -5, 0));
        vertices.Add(new Vector3(-3, -5, 0));

        tris.Add(21);
        tris.Add(22);
        tris.Add(23);

        //rightUpperLeg
        vertices.Add(new Vector3(1, 0, 0));
        vertices.Add(new Vector3(3, -5, 0));
        vertices.Add(new Vector3(1, -5, 0));

        tris.Add(24);
        tris.Add(25);
        tris.Add(26);



        mesh.vertices = vertices.ToArray();
        mesh.triangles = tris.ToArray();

        List<Matrix4x4> bindposes = new List<Matrix4x4>();
        for (int i = 0; i < bones.Length; i++)
            bindposes.Add(bones[i].worldToLocalMatrix * transform.worldToLocalMatrix);
        mesh.bindposes = bindposes.ToArray();

        mesh.boneWeights = new BoneWeight[]
        {
            new BoneWeight() {boneIndex0=0,weight0=1f},
            new BoneWeight() {boneIndex0=0,weight0=1f},
            new BoneWeight() {boneIndex0=0,weight0=1f},

            new BoneWeight() {boneIndex0=1,weight0=1f},
            new BoneWeight() {boneIndex0=1,weight0=1f},
            new BoneWeight() {boneIndex0=1,weight0=1f},

            new BoneWeight() {boneIndex0=2,weight0=1f},
            new BoneWeight() {boneIndex0=2,weight0=1f},
            new BoneWeight() {boneIndex0=2,weight0=1f},

            new BoneWeight() {boneIndex0=3,weight0=1f},
            new BoneWeight() {boneIndex0=3,weight0=1f},
            new BoneWeight() {boneIndex0=3,weight0=1f},

            new BoneWeight() {boneIndex0=4,weight0=1f},
            new BoneWeight() {boneIndex0=4,weight0=1f},
            new BoneWeight() {boneIndex0=4,weight0=1f},

            new BoneWeight() {boneIndex0=5,weight0=1f},
            new BoneWeight() {boneIndex0=5,weight0=1f},
            new BoneWeight() {boneIndex0=5,weight0=1f},

            new BoneWeight() {boneIndex0=6,weight0=1f},
            new BoneWeight() {boneIndex0=6,weight0=1f},
            new BoneWeight() {boneIndex0=6,weight0=1f},

            new BoneWeight() {boneIndex0=7,weight0=1f},
            new BoneWeight() {boneIndex0=7,weight0=1f},
            new BoneWeight() {boneIndex0=7,weight0=1f},

            new BoneWeight() {boneIndex0=8,weight0=1f},
            new BoneWeight() {boneIndex0=8,weight0=1f},
            new BoneWeight() {boneIndex0=8,weight0=1f},

        };

        meshFilter.mesh = mesh;
        meshRenderer.sharedMesh = mesh;
        meshRenderer.bones = bones;
        meshRenderer.rootBone = rootBone;
        meshRenderer.material = material;
        meshRenderer.quality = SkinQuality.Bone2;
    }
}
