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
        GenerateMeshEx();
    }
    class MeshInfo
    {
        public List<Vector3> v=new List<Vector3>();
        public List<int> tris=new List<int>();
        public List<BoneWeight> boneWeight = new List<BoneWeight>();
    }
    void AddBox(ref MeshInfo meshInfo, int boneIndex, Vector3 centerPos, float scaleX = 1, float scaleY = 1, float scaleZ = 1)
    {
        int index = meshInfo.v.Count;
        meshInfo.v.Add(new Vector3(-scaleX, -scaleY, -scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(-scaleX, -scaleY, scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(scaleX, -scaleY, scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(scaleX, -scaleY, -scaleZ) + centerPos);

        meshInfo.v.Add(new Vector3(-scaleX, scaleY, -scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(-scaleX, scaleY, scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(scaleX, scaleY, scaleZ) + centerPos);
        meshInfo.v.Add(new Vector3(scaleX, scaleY, -scaleZ) + centerPos);
        //아래
        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(2 + index);
        meshInfo.tris.Add(1 + index);

        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(3 + index);
        meshInfo.tris.Add(2 + index);
        //왼
        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(1 + index);
        meshInfo.tris.Add(5 + index);

        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(5 + index);
        meshInfo.tris.Add(4 + index);

        //앞

        meshInfo.tris.Add(1 + index);
        meshInfo.tris.Add(6 + index);
        meshInfo.tris.Add(5 + index);

        meshInfo.tris.Add(1 + index);
        meshInfo.tris.Add(2 + index);
        meshInfo.tris.Add(6 + index);

        //오

        meshInfo.tris.Add(3 + index);
        meshInfo.tris.Add(7 + index);
        meshInfo.tris.Add(6 + index);

        meshInfo.tris.Add(3 + index);
        meshInfo.tris.Add(6 + index);
        meshInfo.tris.Add(2 + index);

        //뒤

        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(7 + index);
        meshInfo.tris.Add(3 + index);

        meshInfo.tris.Add(0 + index);
        meshInfo.tris.Add(4 + index);
        meshInfo.tris.Add(7 + index);


        //뚜껑
        meshInfo.tris.Add(4 + index);
        meshInfo.tris.Add(5 + index);
        meshInfo.tris.Add(6 + index);

        meshInfo.tris.Add(4 + index);
        meshInfo.tris.Add(6 + index);
        meshInfo.tris.Add(7 + index);

        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
        meshInfo.boneWeight.Add(new BoneWeight() { boneIndex0 = boneIndex, weight0 = 1f });
    }
    void GenerateMeshEx()
    {
        Mesh mesh = new Mesh();
        MeshInfo meshInfo = new MeshInfo();
        List<Matrix4x4> bindposes = new List<Matrix4x4>();

        for (int i = 0; i < bones.Length; i++)
        {
         //   AddBox(ref meshInfo, i, bones[i].position, 1, 1, 1);
            bindposes.Add(bones[i].worldToLocalMatrix * transform.worldToLocalMatrix);
        }
        
        AddBox(ref meshInfo, 0, bones[0].position + Vector3.up, 1, 1, 1);//PELVIS
        AddBox(ref meshInfo, 1, bones[1].position+Vector3.up*2, 2, 2, 1);//SPINE
        AddBox(ref meshInfo, 2, bones[2].position+Vector3.up*1, 1, 1, 1);//HEAD
        AddBox(ref meshInfo, 3, bones[3].position + Vector3.up * -2, 1, 2, 1);//LEFTUPPER
        AddBox(ref meshInfo, 4, bones[4].position + Vector3.up * -1, 1, 1, 1);//LEFTARM
        AddBox(ref meshInfo, 5, bones[5].position + Vector3.up * -2, 1, 2, 1);//RIGHTUPPER
        AddBox(ref meshInfo, 6, bones[6].position + Vector3.up * -1, 1, 1, 1);//RIGHTARM
        AddBox(ref meshInfo, 7, bones[7].position + Vector3.up * -2, 1, 2, 1);//LEFTUPPERLEG
        AddBox(ref meshInfo, 8, bones[8].position + Vector3.up * -2, 1, 2, 1);//LEFTLEG
        AddBox(ref meshInfo, 9, bones[9].position + Vector3.up * -2, 1, 2, 1);//RIGHTUPPERLEG
        AddBox(ref meshInfo, 10, bones[10].position + Vector3.up * -2, 1, 2, 1);//RIGHTLEG


        mesh.vertices = meshInfo.v.ToArray();
        mesh.triangles = meshInfo.tris.ToArray();
        mesh.boneWeights = meshInfo.boneWeight.ToArray();
        mesh.bindposes = bindposes.ToArray();
        meshFilter.mesh = mesh;
        meshRenderer.sharedMesh = mesh;
        meshRenderer.bones = bones;
        meshRenderer.rootBone = rootBone;
        meshRenderer.material = material;
        meshRenderer.quality = SkinQuality.Bone2;
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
