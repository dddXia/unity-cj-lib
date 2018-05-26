﻿/******************************************************************************/
/*
  Project - Unity CJ Lib
            https://github.com/TheAllenChou/unity-cj-lib
  
  Author  - Ming-Lun "Allen" Chou
  Web     - http://AllenChou.net
  Twitter - @TheAllenChou
*/
/******************************************************************************/

using UnityEngine;

namespace CjLib
{
  public class SimplexNoise
  {
    private static bool s_simplexInit = false;
    private static ComputeShader s_simplex;
    private static int s_simplex1KernelId;
    private static int s_simplex2KernelId;
    private static int s_simplex3KernelId;
    private static void InitSimplex()
    {
      NoiseCommon.InitCsId();

      if (s_simplexInit)
        return;

      s_simplex = (ComputeShader) Resources.Load("SimplexNoiseCs");
      s_simplex1KernelId = s_simplex.FindKernel("Simplex1");
      s_simplex2KernelId = s_simplex.FindKernel("Simplex2");
      s_simplex3KernelId = s_simplex.FindKernel("Simplex3");
    }

    private static void GetSimplex1(out ComputeShader shader, out int kernelId)
    {
      InitSimplex();
      shader = s_simplex;
      kernelId = s_simplex1KernelId;
    }

    private static void GetSimplex2(out ComputeShader shader, out int kernelId)
    {
      InitSimplex();
      shader = s_simplex;
      kernelId = s_simplex2KernelId;
    }

    private static void GetSimplex3(out ComputeShader shader, out int kernelId)
    {
      InitSimplex();
      shader = s_simplex;
      kernelId = s_simplex3KernelId;
    }

    public static void Compute(float[] output, float scale, float offset, int numOctaves, float octaveOffsetFactor, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetSimplex1(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), 1, 1 };
      float[] aScale = new float[] { scale };
      float[] aOffset = new float[] { offset };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float), aScale, aOffset, numOctaves, octaveOffsetFactor);
    }

    public static void Compute(float[,] output, float[] scale, float[] offset, int numOctaves, float octaveOffsetFactor, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetSimplex2(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), output.GetLength(1), 1 };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float), scale, offset, numOctaves, octaveOffsetFactor);
    }

    public static void Compute(float[,,] output, float[] scale, float[] offset, int numOctaves, float octaveOffsetFactor, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetSimplex3(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), output.GetLength(1), output.GetLength(2) };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float), scale, offset, numOctaves, octaveOffsetFactor);
    }
  }
}
