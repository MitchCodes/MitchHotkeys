using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.UI.WPF.ViewModels;

namespace MitchHotkeys.UI.WPF.Mapper {
    public static class MapperConfig {
        public static void Configure(IMapperConfigurationExpression config) {
            config.CreateMap<Hotkey, HotkeyViewModel>();
        }
    }
}
