using Swed32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace riothook.game.viewmatrix
{
    public class readmtx
    {
        public static Matrix4x4 mtx;

        public static void _readmtx(Swed mem, IntPtr client)
        {
            var vmtx = new Matrix4x4();
            var mtxArray = mem.ReadMatrix(client + offsets.offsets.entviewmatrix);

            vmtx.M11 = mtxArray[0];
            vmtx.M12 = mtxArray[1];
            vmtx.M13 = mtxArray[2];
            vmtx.M14 = mtxArray[3];
            vmtx.M21 = mtxArray[4];
            vmtx.M22 = mtxArray[5];
            vmtx.M23 = mtxArray[6];
            vmtx.M24 = mtxArray[7];
            vmtx.M31 = mtxArray[8];
            vmtx.M32 = mtxArray[9];
            vmtx.M33 = mtxArray[10];
            vmtx.M34 = mtxArray[11];
            vmtx.M41 = mtxArray[12];
            vmtx.M42 = mtxArray[13];
            vmtx.M43 = mtxArray[14];
            vmtx.M44 = mtxArray[15];

            float[] mtxArrayConverted = new float[16];
            mtxArrayConverted[0] = vmtx.M11;
            mtxArrayConverted[1] = vmtx.M12;
            mtxArrayConverted[2] = vmtx.M13;
            mtxArrayConverted[3] = vmtx.M14;
            mtxArrayConverted[4] = vmtx.M21;
            mtxArrayConverted[5] = vmtx.M22;
            mtxArrayConverted[6] = vmtx.M23;
            mtxArrayConverted[7] = vmtx.M24;
            mtxArrayConverted[8] = vmtx.M31;
            mtxArrayConverted[9] = vmtx.M32;
            mtxArrayConverted[10] = vmtx.M33;
            mtxArrayConverted[11] = vmtx.M34;
            mtxArrayConverted[12] = vmtx.M41;
            mtxArrayConverted[13] = vmtx.M42;
            mtxArrayConverted[14] = vmtx.M43;
            mtxArrayConverted[15] = vmtx.M44;

            mtx = vmtx;
        }
    }
}