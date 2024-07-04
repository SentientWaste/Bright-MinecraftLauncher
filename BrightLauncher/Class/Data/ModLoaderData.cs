using MinecraftLaunch.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.Class.Data
{
    public sealed record ModLoaderData
    {
        public object Data {  get; set; }
        public LoaderType Type {  get; set; }
    }
}
