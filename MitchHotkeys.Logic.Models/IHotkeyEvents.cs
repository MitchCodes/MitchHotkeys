namespace MitchHotkeys.Logic.Models
{
    public interface IHotkeyEvents
    {
        void HotkeyTriggered();
        void Load();
        void Dispose();
    }
}
