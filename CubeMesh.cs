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

    }

    private Vector2[] GenerateUV()
    {
        Vector2[] uv = new Vector2[24];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(1, 0);
        uv[6] = new Vector2(0, 1);
        uv[7] = new Vector2(1, 1);

        uv[8] = new Vector2(0, 0);
        uv[9] = new Vector2(1, 0);
        uv[10] = new Vector2(0, 1);
        uv[11] = new Vector2(1, 1);

        uv[12] = new Vector2(0, 0);
        uv[13] = new Vector2(1, 0);
        uv[14] = new Vector2(0, 1);
        uv[15] = new Vector2(1, 1);

        uv[16] = new Vector2(0, 0);
        uv[17] = new Vector2(1, 0);
        uv[18] = new Vector2(0, 1);
        uv[19] = new Vector2(1, 1);

        uv[20] = new Vector2(0, 0);
        uv[21] = new Vector2(1, 0);
        uv[22] = new Vector2(0, 1);
        uv[23] = new Vector2(1, 1);

        return uv;
    }

    private Vector3[] GenerateNormals()
    {
        Vector3[] normals = new Vector3[24];

        normals[0] = Vector3.back;
        normals[1] = Vector3.back;
        normals[2] = Vector3.back;
        normals[3] = Vector3.back;

        normals[4] = Vector3.right;
        normals[5] = Vector3.right;
        normals[6] = Vector3.right;
        normals[7] = Vector3.right;

        normals[8] = Vector3.forward;
        normals[9] = Vector3.forward;
        normals[10] = Vector3.forward;
        normals[11] = Vector3.forward;

        normals[12] = Vector3.left;
        normals[13] = Vector3.left;
        normals[14] = Vector3.left;
        normals[15] = Vector3.left;

        normals[16] = Vector3.up;
        normals[17] = Vector3.up;
        normals[18] = Vector3.up;
        normals[19] = Vector3.up;

        normals[20] = Vector3.down;
        normals[21] = Vector3.down;
        normals[22] = Vector3.down;
        normals[23] = Vector3.down;

        return normals;
    }

    private int[] GenerateTriangles()
    {
        int[] triangles = new int[36];

        // f0
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        //f1
        triangles[6] = 4;
        triangles[7] = 6;
        triangles[8] = 5;

        triangles[9] = 5;
        triangles[10] = 6;
        triangles[11] = 7;

        //f2
        triangles[12] = 8;
        triangles[13] = 10;
        triangles[14] = 9;

        triangles[15] = 9;
        triangles[16] = 10;
        triangles[17] = 11;

        //f3
        triangles[18] = 12;
        triangles[19] = 14;
        triangles[20] = 13;

        triangles[21] = 13;
        triangles[22] = 14;
        triangles[23] = 15;

        //f4
        triangles[24] = 16;
        triangles[25] = 18;
        triangles[26] = 17;

        triangles[27] = 17;
        triangles[28] = 18;
        triangles[29] = 19;

        //f5
        triangles[30] = 20;
        triangles[31] = 22;
        triangles[32] = 21;

        triangles[33] = 21;
        triangles[34] = 22;
        triangles[35] = 23;

        return triangles;
    }

    private Vector3[] GenerateVertices()
    {
        Vector3[] vertices = new Vector3[24];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[5] = new Vector3(0, 0, 0);
        vertices[23] = new Vector3(0, 0, 0);

        vertices[1] = new Vector3(_width, 0, 0);
        vertices[12] = new Vector3(_width, 0, 0);
        vertices[21] = new Vector3(_width, 0, 0);

        vertices[2] = new Vector3(0, _height, 0);
        vertices[7] = new Vector3(0, _height, 0);
        vertices[17] = new Vector3(0, _height, 0);

        vertices[3] = new Vector3(_width, _height, 0);
        vertices[14] = new Vector3(_width, _height, 0);
        vertices[19] = new Vector3(_width, _height, 0);

        vertices[4] = new Vector3(0, 0, _breadth);
        vertices[9] = new Vector3(0, 0, _breadth);
        vertices[22] = new Vector3(0, 0, _breadth);

        vertices[6] = new Vector3(0, _height, _breadth);
        vertices[11] = new Vector3(0, _height, _breadth);
        vertices[16] = new Vector3(0, _height, _breadth);

        vertices[8] = new Vector3(_width, 0, _breadth);
        vertices[13] = new Vector3(_width, 0, _breadth);
        vertices[20] = new Vector3(_width, 0, _breadth);

        vertices[10] = new Vector3(_width, _height, _breadth);
        vertices[15] = new Vector3(_width, _height, _breadth);
        vertices[18] = new Vector3(_width, _height, _breadth);

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
