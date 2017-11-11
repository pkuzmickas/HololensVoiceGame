// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class HeadsetAdjustment : MonoBehaviour, IInputClickHandler, ISpeechHandler
    {
        public string NextSceneName;
        public Canvas theCanvas;
        public GameObject gameObjWithCanvas;

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            GotoNextScene();
        }

        public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
        {
            GotoNextScene();
        }

        private void GotoNextScene()
        {
            // Deactivate Canvas.
            if (theCanvas != null)
            {
                theCanvas.enabled = false;
            }
            // Show Loading Bar

            
            InputManager.Instance.RemoveGlobalListener(gameObject);

            if (!string.IsNullOrEmpty(NextSceneName))
            {
                SceneManager.LoadScene(NextSceneName);
            }
            else
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex + 1);
            }
        }
    }
}
