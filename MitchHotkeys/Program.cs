using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using MitchHotkeys.UI.WPF.Mapper;

namespace MitchHotkeys
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Mapper.Initialize(MapperConfig);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void MapperConfig(IMapperConfigurationExpression obj) {
            UI.WPF.Mapper.MapperConfig.Configure(obj);
        }
    }
}
