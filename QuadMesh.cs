using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMesh : MonoBehaviour
{
    
   [SerializeField] private float _width;
   [SerializeField] private float _height;
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

    private Vector3[] GenerateVertices()
    {
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(_width, 0, 0);
        vertices[2] = new Vector3(0, _height, 0);
        vertices[3] = new Vector3(_width, _height, 0);

        return vertices;
    }

    void Update()
    {
        ResetMesh();
        UpdateMaterial();

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
        Vector2[] uv = new Vector2[4];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        return uv;
    }

    private Vector3[] GenerateNormals()
    {
        Vector3[] normals = new Vector3[4];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        return normals;
    }

    private void UpdateMaterial()
    {
        _renderer.material = _material;
    }

    private void ResetMesh()
    {
        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;
    }

    private int[] GenerateTriangles()
    {
        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

        return triangles;
    }
}
