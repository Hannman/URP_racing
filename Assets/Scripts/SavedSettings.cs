public static class SavedSettings
{
    public static bool fpsCounter { get; set; }
    public static int Quality { get; set; }
    public static float carSoundLevel { get; set; }
    public static float musicLevel { get; set; }
    public static float effectsLevel { get; set; }
    public static float menuMusicLevel { get; set; }
    public static float startTime { get; }
    public static int starCount { get; set; }
    public static int ringTime { get; }

    static SavedSettings()
    {
        //Default settings
        fpsCounter = false;
        Quality = 4;
        carSoundLevel = 0.8f;
        musicLevel = 0.8f;
        effectsLevel = 0.95f;
        menuMusicLevel = 0.8f;
        startTime = 30f;
        starCount = 0;
        ringTime = 15; //Время, добавляемое розовым кольцом
    }

}
