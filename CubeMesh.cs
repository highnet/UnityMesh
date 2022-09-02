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

        for (int i = 0; i <= 23; i++)
        {
            if (i <= 3)
            {
                normals[i] = Vector3.back;
            }
            else if (i <= 7)
            {
                normals[i] = Vector3.right;
            } else if (i <= 11)
            {
                normals[i] = Vector3.forward;
            }
            else if (i <= 15)
            {
                normals[i] = Vector3.left;
            } else if (i <= 19)
            {
                normals[i] = Vector3.up;
            } else if (i <= 23)
            {
                normals[i] = Vector3.down;
            }
        }

        return normals;
    }

    private int[] GenerateTriangles()
    {

        int[] triangles =
        {
            0, 2, 1, 1, 2, 3, 4, 6, 5, 5, 6, 7, 8, 10, 9, 9, 10, 11, 12, 14, 13, 13, 14, 15, 16, 18, 17, 17, 18, 19, 20,
            22, 21, 21, 22, 23
        };

        return triangles;
    }

    private Vector3[] GenerateVertices()
    {
        Vector3[] vertices = new Vector3[24];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(_width, 0, 0);
        vertices[2] = new Vector3(0, _height, 0);
        vertices[3] = new Vector3(_width, _height, 0);
        vertices[4] = new Vector3(0, 0, _breadth);
        vertices[5] = new Vector3(0, 0, 0);
        vertices[6] = new Vector3(0, _height, _breadth);
        vertices[7] = new Vector3(0, _height, 0);
        vertices[8] = new Vector3(_width, 0, _breadth);
        vertices[9] = new Vector3(0, 0, _breadth);
        vertices[10] = new Vector3(_width, _height, _breadth);
        vertices[11] = new Vector3(0, _height, _breadth);
        vertices[12] = new Vector3(_width, 0, 0);
        vertices[13] = new Vector3(_width, 0, _breadth);
        vertices[14] = new Vector3(_width, _height, 0);
        vertices[15] = new Vector3(_width, _height, _breadth);
        vertices[16] = new Vector3(0, _height, _breadth);
        vertices[17] = new Vector3(0, _height, 0);
        vertices[18] = new Vector3(_width, _height, _breadth);
        vertices[19] = new Vector3(_width, _height, 0);
        vertices[20] = new Vector3(_width, 0, _breadth);
        vertices[21] = new Vector3(_width, 0, 0);
        vertices[22] = new Vector3(0, 0, _breadth);
        vertices[23] = new Vector3(0, 0, 0);
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
