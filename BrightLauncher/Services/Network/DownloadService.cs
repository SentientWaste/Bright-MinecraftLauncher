using BrightLauncher.Class.Data;
using BrightLauncher.Class.Messages;
using CommunityToolkit.Mvvm.Messaging;
using MinecraftLaunch.Classes.Enums;
using MinecraftLaunch.Classes.Models.Download;
using MinecraftLaunch.Classes.Models.Install;
using MinecraftLaunch.Components.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.Services.Network
{
    public sealed class DownloadService
    {
        private readonly MirrorDownloadSource _source;

        public DownloadService(MirrorDownloadSource mirrorDownloadSource)
        {
            _source = mirrorDownloadSource;
        }

        public async IAsyncEnumerable<VersionManifestEntry> GetVersionListAsync()
        {
            var games = await VanlliaInstaller.EnumerableGameCoreAsync(_source);
            foreach (var game in games)
            {
                yield return game;
            }
        }

        public async Task InitModLoaders(VersionManifestEntry versionManifestEntry)
        {
            await Task.WhenAll(InitModLoader(LoaderType.Forge),
                InitModLoader(LoaderType.Fabric),
                InitModLoader(LoaderType.OptiFine));

            async Task InitModLoader(LoaderType loaderType)
            {
                IEnumerable<ModLoaderData> result = null!;
                await Task.Run(async () =>
                {
                    switch (loaderType)
                    {
                        case LoaderType.Forge:
                            var forges = await ForgeInstaller.EnumerableFromVersionAsync(versionManifestEntry.Id);
                            result = forges.Select(x => new ModLoaderData
                            {
                                Data = x,
                                Name =$"{x.ForgeVersion}",
                                Type = loaderType,
                            });
                            break;
                        case LoaderType.Fabric:
                            var fabrics = await FabricInstaller.EnumerableFromVersionAsync(versionManifestEntry.Id);
                            result = fabrics.Select(x => new ModLoaderData
                            {
                                Data = x,
                                Name = $"{x.BuildVersion}",
                                Type = loaderType,
                            });
                            break;
                        case LoaderType.OptiFine:
                            var optifines = await OptifineInstaller.EnumerableFromVersionAsync(versionManifestEntry.Id);
                            result = optifines.Select(x => new ModLoaderData
                            {
                                Data = x,
                                Name = $"{x.Type}_{x.Patch}",
                                Type = loaderType,
                            });
                            break;
                    }
                }).ContinueWith(x =>
                {
                    if (x.IsCompletedSuccessfully)
                    {
                        WeakReferenceMessenger.Default.Send(new ModLoaderMessage(result, loaderType));
                    }
                });
            }
        }
    }
}
