using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using MitchHotkeys.Data;
using MitchHotkeys.Logic.Factories;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Misc;

namespace MitchHotkeys.Logic
{
    public class MainLogic
    {
        private static MainLogic instance;
        private DataService ds = null;
        private BindingList<Hotkey> _hotkeys = new BindingList<Hotkey>();
        private IntPtr _mainFormHandle;
        private BindingList<HotkeyGroup> _hotkeyGroups;
        private HotkeyGroup _currentGroup;
        private HotkeyInputCallbacks _inputCallbacks = new HotkeyInputCallbacks();


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

        public HotkeyInputCallbacks InputCallbacks {
            get { return _inputCallbacks; }
            set { _inputCallbacks = value; }
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

        public void GetHotkeysForGroup(HotkeyGroup group) {
            ds.OpenConnection();

            // doing this in the mean-time. this is no way to program. too lazy to fix factory being in the logic tier making the data reading rely on it
            SQLiteDataReader dataReader = ds.GetHotkeys(group);
            Hotkeys = new BindingList<Hotkey>();
            if (dataReader != null) {
                while (dataReader.Read()) {
                    int hotkeyCommand = int.Parse(dataReader["command"].ToString());
                    Hotkey newHotkey = HotkeyTypeFactory.GetHotkeyType(hotkeyCommand);
                    newHotkey.Modifier = int.Parse(dataReader["modifier"].ToString());
                    newHotkey.Key = int.Parse(dataReader["key"].ToString());
                    newHotkey.Command = hotkeyCommand;
                    newHotkey.ExtraData1 = dataReader["extraData1"].ToString();
                    newHotkey.ExtraData2 = dataReader["extraData2"].ToString();
                    newHotkey.ExtraData3 = dataReader["extraData3"].ToString();

                    Hotkeys.Add(newHotkey);
                }
            }

            ds.CloseConnection();
            ds.OpenConnection();

            SQLiteDataReader addtDataReader = ds.GetHotkeysAdditionalData(group);
            if (addtDataReader != null) {
                while (addtDataReader.Read()) {
                    int currentModifier = int.Parse(addtDataReader["modifier"].ToString());
                    int currentKey = int.Parse(addtDataReader["key"].ToString());
                    int currentCommand = int.Parse(addtDataReader["command"].ToString());

                    Hotkey addedHotkey = Hotkeys.FirstOrDefault(hk => hk.Modifier == currentModifier && hk.Key == currentKey && hk.Command == currentCommand);
                    if (addedHotkey != null) {
                        string currentDataKey = addtDataReader["keyName"].ToString();
                        string currentDataValue = addtDataReader["dataValue"].ToString();
                        addedHotkey.AdditionalExtraData.Add(int.Parse(currentDataKey), currentDataValue);
                    }
                }
            }

            ds.CloseConnection();

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
