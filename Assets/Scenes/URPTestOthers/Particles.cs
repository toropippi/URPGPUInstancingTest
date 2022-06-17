using UnityEngine;

namespace Sandbox
{

    public struct Particle
    {
        public Vector3 position;

        public static Particle Create()
        {
            return new Particle
            {
                position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 9.0f), Random.Range(-5.0f, 5.0f))
            };
        }
    }


    public class Particles : MonoBehaviour
    {
        [SerializeField] Mesh mesh;
        [SerializeField] Material material;

        ComputeBuffer particleBuffer;
        Bounds bounds;
        const int instanceCount = 400;
        ArgsBuffer argsBuffer;
        void Start()
        {
            bounds = new Bounds(Vector3.zero, Vector3.one * 1000);
            argsBuffer = new ArgsBuffer();
            argsBuffer.SetData(mesh, 0, instanceCount);

            particleBuffer = new ComputeBuffer(instanceCount, 12);

            var particles = new Particle[instanceCount];

            for (var i = 0; i < instanceCount; ++i)
            {
                particles[i] = Particle.Create();
            }

            particleBuffer.SetData(particles);

            material.SetBuffer("_Particles", particleBuffer);            
        }

        private void Update()
        {
            Graphics.DrawMeshInstancedIndirect(mesh, 0, material, bounds, argsBuffer.Buffer);
        }

        void OnDestroy()
        {
            particleBuffer.Release();
        }
    }
}

