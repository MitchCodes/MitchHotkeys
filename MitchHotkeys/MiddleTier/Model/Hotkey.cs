﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier.Factories;
using MitchHotkeys.MiddleTier.Services.Misc;

namespace MitchHotkeys.MiddleTier.Model
{

    public class Hotkey: IHotkeyEvents
    {
        private int _modifier;
        private int _key;
        private int _command;
        private string _extraData1;
        private string _extraData2;
        private string _extraData3;
        private int _id = -1;
        private Dictionary<int, string> _additionalExtraData;

        public Hotkey()
        {
            AdditionalExtraData = new Dictionary<int, string>();
        }
        public int Modifier
        {
            get { return _modifier; }
            set
            {
                if (_id != -1)
                {
                    _id = CalculateId();
                }
                _modifier = value;
            }
        }

        public int Key
        {
            get { return _key; }
            set
            {
                if (_id != -1)
                {
                    _id = CalculateId();
                }
                _key = value;
            }
        }

        public int Command
        {
            get { return _command; }
            set
            {
                if (_id != -1)
                {
                    _id = CalculateId();
                }
                _command = value;
            }
        }

        public string ExtraData1
        {
            get { return _extraData1; }
            set { _extraData1 = value; }
        }

        public string ExtraData2
        {
            get { return _extraData2; }
            set { _extraData2 = value; }
        }

        public string ExtraData3
        {
            get { return _extraData3; }
            set { _extraData3 = value; }
        }

        public Dictionary<int, string> AdditionalExtraData
        {
            get { return _additionalExtraData; }
            set { _additionalExtraData = value; }
        }

        private int CalculateId()
        {
            return int.Parse(Modifier.ToString() + Key.ToString() + Command.ToString());
        }

        public int ID
        {
            get
            {
                if (_id == -1)
                {
                    _id = CalculateId();
                }
                return _id;
            }
        }

        public int KeyCmbId { get; set; }

        public HotkeyTypeEnum CommandEnum
        {
            get { return (HotkeyTypeEnum) Command; }
        }

        public GlobalHotkeyService.KeyModifier ModifierEnum
        {
            get { return (GlobalHotkeyService.KeyModifier)Modifier; }
        }

        public Keys KeyEnum
        {
            get { return (Keys)Key; }
        }

        public string GetAdditionalData(HotkeyAdditionalDataType additionalDataType)
        {
            if (AdditionalExtraData != null && AdditionalExtraData.ContainsKey((int)additionalDataType))
            {
                return AdditionalExtraData[(int) additionalDataType];
            }
            return null;
        }

        public void SetAdditionalData(HotkeyAdditionalDataType additionalDataType, string value)
        {
            if (AdditionalExtraData == null)
            {
                AdditionalExtraData = new Dictionary<int, string>();
            }

            if (AdditionalExtraData.ContainsKey((int)additionalDataType))
            {
                AdditionalExtraData[(int)additionalDataType] = value;
            }
            else
            {
                AdditionalExtraData.Add((int) additionalDataType, value);
            }
        }

        public virtual void HotkeyTriggered()
        {
            throw new NotImplementedException();
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public enum HotkeyAdditionalDataType
    {
        DeviceThree = 0,
        AutoTuneAttack = 1,
        AutoTuneVibratoRate = 2,
        AutoTunePitchC = 3,
        AutoTunePitchCSharp = 4,
        AutoTunePitchD = 5,
        AutoTunePitchDSharp = 6,
        AutoTunePitchE = 7,
        AutoTunePitchF = 8,
        AutoTunePitchFSharp = 9,
        AutoTunePitchG = 10,
        AutoTunePitchGSharp = 11,
        AutoTunePitchA = 12,
        AutoTunePitchASharp = 13,
        AutoTunePitchB = 14,
        ExtraData4 = 15
    }
}
