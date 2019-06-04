using System;
using System.IO;
using Live2D.Cubism.Framework.Json;
using UnityEngine;
using UnityEngine.UI;
using Live2D.Cubism.Core;


/// <summary>
/// Initialize model.
/// </summary>
public class InitModel : MonoBehaviour
{
    public CubismModel model;
    void Start()
    {

        //Load model.
        var path = Application.streamingAssetsPath + "/18-8-18_Live2d_MeidoChan.model3.json";
        var model3Json = CubismModel3Json.LoadAtPath(path, BuiltinLoadAssetAtPath);

        model = model3Json.ToModel();


        model.transform.localScale = new Vector3(1.3F, 1.3F, 1);
        model.transform.position = new Vector3(-0.2F, -0.5F, 0);


    }

    /// <summary>
    /// Load asset.
    /// </summary>
    /// <param name="assetType">Asset type.</param>
    /// <param name="absolutePath">Path to asset.</param>
    /// <returns>The asset on succes; <see langword="null"> otherwise.</returns>
    public static object BuiltinLoadAssetAtPath(Type assetType, string absolutePath)
    {
        if (assetType == typeof(byte[]))
        {
            return File.ReadAllBytes(absolutePath);
        }
        else if (assetType == typeof(string))
        {
            return File.ReadAllText(absolutePath);
        }
        else if (assetType == typeof(Texture2D))
        {
            var texture = new Texture2D(1, 1);
            texture.LoadImage(File.ReadAllBytes(absolutePath));

            return texture;
        }

        throw new NotSupportedException();
    }


}