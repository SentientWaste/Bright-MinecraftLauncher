using BrightLauncher.Class.Data;
using MinecraftLaunch.Classes.Enums;
using System.Collections.Generic;

namespace BrightLauncher.Class.Messages
{
    public sealed record ModLoaderMessage(IEnumerable<ModLoaderData> LoaderDatas, LoaderType LoaderType);
}
