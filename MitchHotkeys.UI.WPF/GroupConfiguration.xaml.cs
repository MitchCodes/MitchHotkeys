using MitchHotkeys.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MitchHotkeys.UI.WPF.ViewModels;

namespace MitchHotkeys.UI.WPF {
    /// <summary>
    /// Interaction logic for GroupConfiguration.xaml
    /// </summary>
    public partial class GroupConfiguration : Window {
        public GroupConfiguration(BindingList<Hotkey> keys) {
            InitializeComponent();

            List<Hotkey> hotkeys = keys.ToList();
            List<HotkeyViewModel> hotkeysVm = new List<HotkeyViewModel>();
            foreach (Hotkey hk in hotkeys) {
                hotkeysVm.Add(AutoMapper.Mapper.Map<Hotkey, HotkeyViewModel>(hk));
            }
        }
    }
}
