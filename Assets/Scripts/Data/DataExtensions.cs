using UnityEngine;

namespace Data
{
    public static class DataExtensions
    {
        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static Vector3Data AsVectorData(this Vector3 v3) =>
            new(v3.x, v3.y, v3.z);

        public static Vector3 AsUnityVector(this Vector3Data vData) =>
            new(vData.X, vData.Y, vData.Z);
    }
}