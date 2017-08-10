using System;
using System.Collections.Generic;
using MitchHotkeys.Logic.Models;
using System.Windows.Interop;

namespace MitchHotkeys.Logic.Services.Misc
{
    public class GlobalHotkeyAlternative
    {
        private IntPtr _mainFormHandle;
        private Dictionary<int, Hotkey> _currentlyRegisteredHotkeys;
        private bool _disposed = false;
        private bool CreatedHotkeyTriggerHandler { get; set; }
        public const int WmHotKey = 0x0312;

        private Dictionary<int, Hotkey> CurrentlyRegisteredHotkeys
        {
            get { return _currentlyRegisteredHotkeys; }
            set { _currentlyRegisteredHotkeys = value; }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vlc);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static GlobalHotkeyAlternative instance;

        private GlobalHotkeyAlternative()
        {
            CurrentlyRegisteredHotkeys = new Dictionary<int, Hotkey>();
            CreatedHotkeyTriggerHandler = false;
        }

        public static GlobalHotkeyAlternative Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalHotkeyAlternative();
                }
                return instance;
            }
        }

        public IntPtr MainFormHandle
        {
            get { return _mainFormHandle; }
            set { _mainFormHandle = value; }
        }

        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public bool RegisterHotKey(Hotkey hotkey)
        {

            hotkey.KeyCmbId = hotkey.Key + ((int)hotkey.Modifier * 0x10000);

            bool result = RegisterHotKey(IntPtr.Zero, hotkey.KeyCmbId, (UInt32)hotkey.Modifier, (UInt32)hotkey.Key);

            if (result)
            {
                if (!CreatedHotkeyTriggerHandler)
                {
                    ComponentDispatcher.ThreadFilterMessage += new ThreadMessageEventHandler(ComponentDispatcherThreadFilterMessage);
                    CreatedHotkeyTriggerHandler = true;
                }
                CurrentlyRegisteredHotkeys.Add(hotkey.ID, hotkey);
            }

            return result;
        }

        public void UnregisterAllHotkeys()
        {
            foreach (Hotkey currentHotkey in CurrentlyRegisteredHotkeys.Values)
            {
                UnregisterHotKey(currentHotkey, false);
            }
            CurrentlyRegisteredHotkeys = new Dictionary<int, Hotkey>();
        }

        public void UnregisterHotKey(Hotkey hotkey, bool removeFromDict = true)
        {
            UnregisterHotKey(MainFormHandle, hotkey.ID);
            if (removeFromDict)
            {
                CurrentlyRegisteredHotkeys.Remove(hotkey.ID);
            }
        }

        public void UnregisterHotKey(int Id, bool removeFromDict = true)
        {
            Hotkey outHotkey;
            if (CurrentlyRegisteredHotkeys.TryGetValue(Id, out outHotkey))
            {
                UnregisterHotKey(outHotkey, removeFromDict);
            }
        }

        // ******************************************************************
        private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            if (!handled)
            {
                if (msg.message == WmHotKey)
                {
                    Hotkey hotkey;

                    foreach (Hotkey currentHotkey in GlobalHotkeyAlternative.Instance.CurrentlyRegisteredHotkeys.Values)
                    {
                        if (currentHotkey.KeyCmbId == (int)msg.wParam)
                        {
                            MainLogic.Instance.TriggerHotkey(currentHotkey.Key, currentHotkey.Modifier, currentHotkey.ID);
                            handled = true;
                        }
                    }
                }
            }
        }

        // ******************************************************************
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // ******************************************************************
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be _disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be _disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    UnregisterAllHotkeys();
                }

                // Note disposing has been done.
                _disposed = true;
            }
        }

    }
}
