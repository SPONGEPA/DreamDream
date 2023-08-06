using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace Script
{
    public class GameOverEvent : MonoBehaviour
    {
        public delegate void GameOverAction(GameObject winner);

        public static event GameOverAction GameOverEvents;

        public static async void GameOver(GameObject winner)
        {
            //GameObject.Find("sanBar").SetActive(false);
            //GameObject.Find("favorBar").SetActive(false);
            
            /*GameObject winnerPrefab = Resources.Load<GameObject>("Winner");
            AssetDatabase.OpenAsset(winnerPrefab);
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            PrefabUtility.SaveAsPrefabAsset(winner, prefabStage.prefabAssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.CloseCacheServerConnection();
            Debug.Log("VAR1111111111111");*/
            //if (GameOverEvents != null)
            //{
                //GameOverEvents(winner);
            await Task.Delay(3000); 
            //Debug.Log("WWWWWWWWWW");
            SceneManager.LoadScene("CheckoutScene");
            //}
        }
    }
}