using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;

namespace BulletSharp
{
	public class TriangleMesh : TriangleIndexVertexArray
	{
		internal TriangleMesh(IntPtr native)
			: base(native)
		{
		}

		public TriangleMesh(bool use32BitIndices = true, bool use4ComponentVertices = true)
			: base(btTriangleMesh_new(use32BitIndices, use4ComponentVertices))
		{
		}

		public void AddIndex(int index)
		{
			btTriangleMesh_addIndex(_native, index);
		}

       public void AddTriangleRef(ref Vector3 vertex0, ref Vector3 vertex1, ref Vector3 vertex2,
           bool removeDuplicateVertices = false)
       {
           btTriangleMesh_addTriangle(_native, ref vertex0, ref vertex1, ref vertex2,
               removeDuplicateVertices);
       }

		public void AddTriangle(Vector3 vertex0, Vector3 vertex1, Vector3 vertex2,
			bool removeDuplicateVertices = false)
		{
			btTriangleMesh_addTriangle(_native, ref vertex0, ref vertex1, ref vertex2,
				removeDuplicateVertices);
		}

		public void AddTriangleIndices(int index1, int index2, int index3)
		{
			btTriangleMesh_addTriangleIndices(_native, index1, index2, index3);
		}

        public int FindOrAddVertexRef(Vector3 vertex, bool removeDuplicateVertices)
        {
            return btTriangleMesh_findOrAddVertex(_native, ref vertex, removeDuplicateVertices);
        }

		public int FindOrAddVertex(Vector3 vertex, bool removeDuplicateVertices)
		{
			return btTriangleMesh_findOrAddVertex(_native, ref vertex, removeDuplicateVertices);
		}

		public int NumTriangles
		{
			get { return btTriangleMesh_getNumTriangles(_native); }
		}

		public bool Use32BitIndices
		{
			get { return btTriangleMesh_getUse32bitIndices(_native); }
		}

		public bool Use4ComponentVertices
		{
			get { return btTriangleMesh_getUse4componentVertices(_native); }
		}

		public float WeldingThreshold
		{
			get { return btTriangleMesh_getWeldingThreshold(_native); }
			set { btTriangleMesh_setWeldingThreshold(_native, value); }
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btTriangleMesh_new(bool use32bitIndices, bool use4componentVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addIndex(IntPtr obj, int index);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addTriangle(IntPtr obj, [In] ref Vector3 vertex0, [In] ref Vector3 vertex1, [In] ref Vector3 vertex2, bool removeDuplicateVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_addTriangleIndices(IntPtr obj, int index1, int index2, int index3);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btTriangleMesh_findOrAddVertex(IntPtr obj, [In] ref Vector3 vertex, bool removeDuplicateVertices);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btTriangleMesh_getNumTriangles(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btTriangleMesh_getUse32bitIndices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		static extern bool btTriangleMesh_getUse4componentVertices(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern float btTriangleMesh_getWeldingThreshold(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btTriangleMesh_setWeldingThreshold(IntPtr obj, float value);
	}
}
