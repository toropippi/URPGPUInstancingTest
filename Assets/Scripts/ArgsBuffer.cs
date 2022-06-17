using UnityEngine;

//ref
//https://notargs.hateblo.jp/entry/lwrp_particle

namespace Sandbox
{
    public class ArgsBuffer
    {
        uint[] args = new uint[] { 0, 0, 0, 0, 0 };
        ComputeBuffer buffer;// = new ComputeBuffer(1, sizeof(uint) * 5, ComputeBufferType.IndirectArguments);

        public ComputeBuffer Buffer => buffer;

        public void SetData(Mesh mesh, int subMeshIndex, uint instanceCount)
        {
            buffer = new ComputeBuffer(1, sizeof(uint) * 5, ComputeBufferType.IndirectArguments);
            args[0] = mesh.GetIndexCount(subMeshIndex);
            args[1] = instanceCount;
            args[2] = mesh.GetIndexStart(subMeshIndex);
            args[3] = mesh.GetBaseVertex(subMeshIndex);

            buffer.SetData(args);
        }

    }
}