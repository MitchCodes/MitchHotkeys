using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.DataTier;
using MitchHotkeys.MiddleTier.Services.Misc;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier
{
    public class MainLogic
    {
        private static MainLogic instance;
        private DataService ds = null;
        private BindingList<Hotkey> _hotkeys = new BindingList<Hotkey>();
        private IntPtr _mainFormHandle;
        private BindingList<HotkeyGroup> _hotkeyGroups;
        private HotkeyGroup _currentGroup;


        public IntPtr MainFormHandle
        {
            get { return _mainFormHandle; }
            set { _mainFormHandle = value; }
        }

        public BindingList<Hotkey> Hotkeys
        {
            get { return _hotkeys; }
            set { _hotkeys = value; }
        }

        public BindingList<HotkeyGroup> HotkeyGroups
        {
            get { return _hotkeyGroups; }
            set { _hotkeyGroups = value; }
        }

        public HotkeyGroup CurrentGroup
        {
            get { return _currentGroup; }
            set { _currentGroup = value; }
        }

        private MainLogic()
        {
        }

        public static MainLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainLogic();
                }
                return instance;
            }
        }

        public void TriggerHotkey(int key, int modifier, int id)
        {
            Hotkey triggeredHotkey = Hotkeys.FirstOrDefault(m => m.Key == key && m.Modifier == modifier && m.ID == id);
            if (triggeredHotkey == null)
            {
                throw new Exception("The triggered hotkey was null! Is there a loose hotkey still registered?");
            }
            triggeredHotkey.HotkeyTriggered();
        }

        public void LoadHotKey(Hotkey currentHotkey)
        {
            try { currentHotkey.Load(); }
            catch (Exception ex)
            {
                // ignored
            }
            GlobalHotkeyService.Instance.RegisterHotKey(currentHotkey);
        }

        public void UnloadHotKey(Hotkey currentHotkey)
        {
            try { currentHotkey.Dispose(); }
            catch (Exception)
            {
                // ignored
            }
            GlobalHotkeyService.Instance.UnregisterHotKey(currentHotkey);
        }

        public void UnloadAllCurrentHotkeys()
        {
            for (var i = Hotkeys.Count - 1; i >= 0; i--)
            {
                Hotkey currentHotkey = Hotkeys[i];
                UnloadHotKey(currentHotkey);
            }
        }

        public void UpdateHotkeys()
        {
            DataService ds = new DataService();
            ds.DeleteAllHotkeys(CurrentGroup);
            foreach (Hotkey currentHotkey in Hotkeys)
            {
                ds.InsertHotkey(currentHotkey, CurrentGroup);
            }
        }

        public void UpdateHotkeyGroups()
        {
            DataService ds = new DataService();
            ds.DeleteAllHotkeyGroups();
            foreach (HotkeyGroup currentHotkeyGroup in HotkeyGroups)
            {
                ds.InsertHotkeyGroup(currentHotkeyGroup);
            }
        }

        public void DoStartup()
        {
            ds = new DataService();
            HotkeyGroups = ds.GetHotkeyGroups();
            GlobalHotkeyService.Instance.MainFormHandle = MainFormHandle;
        }

        public void GetHotkeysForGroup(HotkeyGroup group)
        {
            Hotkeys = ds.GetHotkeys(group);
            foreach (Hotkey currentHotkey in Hotkeys)
            {
                LoadHotKey(currentHotkey);
            }
        }

        public void DoCleanup()
        {
            ds.CloseConnection();

            UnloadAllCurrentHotkeys();
        }
        
    }
}
