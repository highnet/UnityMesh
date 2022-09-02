using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMesh : MonoBehaviour
{

    [SerializeField] private float _width;
    [SerializeField] private float _height;
    [SerializeField] private float _breadth;
    [SerializeField] private Material _material;

    private MeshFilter _meshFilter;
    private Renderer _renderer;
    private Mesh _mesh;


    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        UpdateMaterial();

        ResetMesh();

        Vector3[] vertices = GenerateVertices();
        _mesh.vertices = vertices;

        int[] tri = GenerateTriangles();
        _mesh.triangles = tri;

        Vector3[] normals = GenerateNormals();
        _mesh.normals = normals;

        Vector2[] uv = GenerateUV();
        _mesh.uv = uv;

      //  _mesh.RecalculateNormals();
    }

    private Vector2[] GenerateUV()
    {
        Vector2[] uv = new Vector2[8];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1f, 0);
        uv[2] = new Vector2(0, 1f);
        uv[3] = new Vector2(1f, 1f);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(1, 0);
        uv[6] = new Vector2(0, 1);
        uv[7] = new Vector2(1, 1);

        return uv;
    }

    private Vector3[] GenerateNormals()
    {
        Vector3[] normals = new Vector3[8];

        normals[0] = new Vector3(-0.577350258f, -0.577350258f, 0.577350258f);
        normals[1] = new Vector3(0.577350258f, -0.577350258f, 0.577350258f);
        normals[2] = new Vector3(0.577350258f, 0.577350258f, 0.577350258f);
        normals[3] = new Vector3(-0.577350258f, 0.577350258f, 0.577350258f);
        normals[4] = new Vector3(-0.577350258f, -0.577350258f, -0.577350258f);
        normals[5] = new Vector3(0.577350258f, -0.577350258f, -0.577350258f);
        normals[6] = new Vector3(0.577350258f, 0.577350258f, -0.577350258f);
        normals[7] = new Vector3(-0.577350258f, 0.577350258f, -0.577350258f);

        return normals;
    }

    private int[] GenerateTriangles()
    {
        int[] triangles = new int[99];

        // f0
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        //f1
        triangles[6] = 2;
        triangles[7] = 6;
        triangles[8] = 3;

        triangles[9] = 3;
        triangles[10] = 6;
        triangles[11] = 7;

        //f2
        triangles[12] = 5;
        triangles[13] = 7;
        triangles[14] = 4;

        triangles[15] = 4;
        triangles[16] = 7;
        triangles[17] = 6;

        //f3
        triangles[18] = 1;
        triangles[19] = 5;
        triangles[20] = 0;

        triangles[21] = 0;
        triangles[22] = 5;
        triangles[23] = 4;

        //f4
        triangles[24] = 1;
        triangles[25] = 3;
        triangles[26] = 5;

        triangles[27] = 5;
        triangles[28] = 3;
        triangles[29] = 7;

        //f5
        triangles[30] = 4;
        triangles[31] = 6;
        triangles[32] = 0;

        triangles[33] = 0;
        triangles[34] = 6;
        triangles[35] = 2;

        return triangles;
    }

    private Vector3[] GenerateVertices()
    {
        Vector3[] vertices = new Vector3[8];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(_width, 0, 0);
        vertices[2] = new Vector3(0, _height, 0);
        vertices[3] = new Vector3(_width, _height, 0);
      
        vertices[4] = new Vector3(0, 0, _breadth);
        vertices[5] = new Vector3(_width, 0, _breadth);
        vertices[6] = new Vector3(0, _height, _breadth);
        vertices[7] = new Vector3(_width, _height, _breadth);


        return vertices;
    }

    private void ResetMesh()
    {
        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;
    }

    private void UpdateMaterial()
    {
        _renderer.material = _material;
    }
}
