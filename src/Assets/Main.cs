﻿/******************************************************************************/
/*
  Project - Unity CJ Lib
            https://github.com/TheAllenChou/unity-cj-lib
  
  Author  - Ming-Lun "Allen" Chou
  Web     - http://AllenChou.net
  Twitter - @TheAllenChou
*/
/******************************************************************************/

using CjLib;
using UnityEngine;

public class Main : MonoBehaviour
{

  void Update()
  {
    DebugUtil.DrawSphere(Vector3.zero, 2.0f, Quaternion.AxisAngle(new Vector3(1.0f, 1.0f, 0.0f), Time.time), 32, 16, Color.white);
    DebugUtil.DrawCylinder(new Vector3(3.0f, 3.0f, 0.0f), new Vector3(-1.0f, -1.0f, 0.0f), 0.5f, 12, Color.white);
  }

}
