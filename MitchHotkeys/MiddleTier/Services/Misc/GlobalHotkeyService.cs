﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Net.Mime;
using System.Runtime.InteropServices;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.Misc
{
    public class GlobalHotkeyService
    {
        private IntPtr _mainFormHandle;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static GlobalHotkeyService instance;

        private GlobalHotkeyService()
        {
        }

        public static GlobalHotkeyService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalHotkeyService();
                }
                return instance;
            }
        }

        public IntPtr MainFormHandle
        {
            get { return _mainFormHandle; }
            set { _mainFormHandle = value; }
        }

        public void RegisterHotKey(Hotkey hotkey)
        {
            RegisterHotKey(MainFormHandle, hotkey.ID, hotkey.Modifier, hotkey.Key);
        }

        public void UnregisterHotKey(Hotkey hotkey)
        {
            UnregisterHotKey(MainFormHandle, hotkey.ID);
        }

        public void UnregisterHotKey(int hotkeyId)
        {
            UnregisterHotKey(MainFormHandle, hotkeyId);
        }

    }
}
