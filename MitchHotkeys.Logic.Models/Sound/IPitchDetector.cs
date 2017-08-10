namespace MitchHotkeys.Logic.Models.Sound
{
    public interface IPitchDetector
    {
        float DetectPitch(float[] buffer, int frames);
    }
}
