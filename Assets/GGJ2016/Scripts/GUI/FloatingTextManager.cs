using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FloatingTextManager : MonoBehaviour {
    public FloatingText floatingTextPrefab;

    /// <summary>
    /// Dictionary containing the floating texts that are currently stationary.
    /// This texts will be modified instead of creating new ones created when any of the Add() funcions is called
    /// </summary>
    public Dictionary<Transform, FloatingText> stationaryTexts;

    void Start()
    {
        stationaryTexts = new Dictionary<Transform, FloatingText>();
    }

    /// <summary>
    /// Create a new FloatingText at the specified screenPosition
    /// </summary>
    /// <param name="text"></param>
    /// <param name="screenPosition"></param>
    /// <returns></returns>
    public FloatingText Display(string text, Vector2 screenPosition) {
        FloatingText newFloatingText = Instantiate(floatingTextPrefab);
        newFloatingText.text.text = text;
        newFloatingText.transform.SetParent(transform);
        newFloatingText.transform.localPosition = screenPosition;
        newFloatingText.Fade();
        return newFloatingText;
    }

    /// <summary>
    /// Adds the value to the floating text that corresponds to targetTransform in the stationaryTexts dictionary.
    /// If none is found, a new floating text is created
    /// </summary>
    /// <param name="targetTransform"></param>
    /// <param name="value"></param>
    /// <param name="color"></param>
    /// <returns>The floatingText object that was changed or created. Useful to chain calls</returns>
    public FloatingText Add(Transform targetTransform, float value) {
        // Find or create the FloatingText
        FloatingText targetText = null;
        if (stationaryTexts.ContainsKey(targetTransform)) {
            targetText = stationaryTexts[targetTransform];
            targetText.Add(value);
        }
        else
        {
            targetText = Display(value.ToString(), Camera.main.WorldToScreenPoint(targetTransform.position));
            stationaryTexts.Add(targetTransform, targetText);
        }
        return targetText;        
    }

    public void Deregister(FloatingText floatingText)
    {
        if (stationaryTexts.ContainsValue(floatingText))
        {
            var item = stationaryTexts.First(kvp => kvp.Value == floatingText);
            stationaryTexts.Remove(item.Key);
        }
    }

    #region Singleton
    /* Singleton implementation */
    private static FloatingTextManager _instance;
    private FloatingTextManager() { }

    public static FloatingTextManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No FloatingTextManager instance is present, but its being accessed");
            }

            return _instance;
        }
    }

	public static bool HasInstance { get { return _instance != null; } }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}
