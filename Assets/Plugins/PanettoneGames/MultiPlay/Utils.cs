using UnityEngine;

namespace PanettoneGames.MultiPlay
{
    public class Utils
    {
        #region Extensions

        public static int GetCurrentClientIndex()
        {
            int clientIndex = 0;
            int dirDepth = Application.dataPath.Split('/').Length;
            string appFolderName = Application.dataPath.Split('/')[dirDepth - 2];
            bool isClient;

            isClient = appFolderName.EndsWith("___Client");
            if (isClient)
                int.TryParse(appFolderName.Substring(
                appFolderName.IndexOf('[') + 1, 1), out clientIndex);

            return clientIndex;
        }

        #endregion
    }
}