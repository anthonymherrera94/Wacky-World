namespace SaveSystem
{
    [System.Serializable]
    public class GameData
    {
        private string nameOfSave = "Save";
        private int currentLevel = 1;
        private int maxLevel = 3;

        public string Name { get { return nameOfSave; } }
        public int SceneIndex { get { return currentLevel; } }
        public GameData(string name)
        {
            nameOfSave = name;
        }

        public void AdvanceLevel()
        {
            currentLevel++;//To Be determent how are scene selected
        }
    }
}
