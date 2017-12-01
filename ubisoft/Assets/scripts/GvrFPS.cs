// Copyright 2015 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
//using UnityEditor;
using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System;
//using System.Runtime.CompilerServices;

[RequireComponent(typeof(Text))]
public class GvrFPS : MonoBehaviour {
  private const string DISPLAY_TEXT_FORMAT = "{0} msf\n({1} FPS)";
  private const string MSF_FORMAT = "#.#";
  private const float MS_PER_SEC = 1000f;
//	private int drawcalls;
//	private GameObject[] gameObjects;
//	private List<Material> rendList = new List<Material>();

  private Text textField;
  private float fps = 60;

  public Camera cam;

  void Awake() {
    textField = GetComponent<Text>();
  }

  void Start() {
	//	gameObjects = FindObjectsOfType<GameObject> ();
    if (cam == null) {
       cam = Camera.main;
    }

    if (cam != null) {
      // Tie this to the camera, and do not keep the local orientation.
      transform.SetParent(cam.GetComponent<Transform>(), true);
    }
  }

  void LateUpdate() {
	/*	foreach (var currentObject in gameObjects) {
			try{
				var rend = currentObject.GetComponent<Renderer>();
				//if (!rendList.Contains(rend.material))
				if (rend.isVisible && rend)
				{
				//	rendList.Add(rend.material);
					drawcalls++;
				}
			}
			catch{
			}
		}*/
    float deltaTime = Time.unscaledDeltaTime;
    float interp = deltaTime / (0.5f + deltaTime);
    float currentFPS = 1.0f / deltaTime;
    fps = Mathf.Lerp(fps, currentFPS, interp);
    float msf = MS_PER_SEC / fps;

    textField.text = string.Format(DISPLAY_TEXT_FORMAT,
        msf.ToString(MSF_FORMAT), Mathf.RoundToInt(fps));
		
		//textField.text += "\n" + UnityStats.batches.ToString();
  }
}
/*
namespace UnityEditor
{
	public sealed class UnityStats
	{
		public static extern int batches
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int drawCalls
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int dynamicBatchedDrawCalls
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int staticBatchedDrawCalls
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int instancedBatchedDrawCalls
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int dynamicBatches
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int staticBatches
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int instancedBatches
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int setPassCalls
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int triangles
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int vertices
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int shadowCasters
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int renderTextureChanges
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float frameTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float renderTime
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float audioLevel
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float audioClippingAmount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float audioDSPLoad
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern float audioStreamLoad
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int renderTextureCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int renderTextureBytes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int usedTextureMemorySize
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int usedTextureCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern string screenRes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int screenBytes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int vboTotal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int vboTotalBytes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int vboUploads
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int vboUploadBytes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int ibUploads
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int ibUploadBytes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int visibleSkinnedMeshes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern int visibleAnimations
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetNetworkStats(int i);
	}
}*/