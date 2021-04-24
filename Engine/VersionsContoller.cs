using ServerCreation.ViewModels;
using ServerCreation.Views;

namespace ServerCreation.Engine
{
    public static class VersionsContoller
    {
        public static async void VersionsManager(string verion, string filename)
        {
            switch (verion)
            {
                #region Vanilla
                case "1.16.5-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/35139deedbd5182953cf1caa23835da59ca3d7cd/server.jar", filename);
                    break;

                case "1.15.2-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar", filename);
                    break;

                case "1.14.4-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar", filename);
                    break;

                case "1.13.2-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar", filename);
                    break;

                case "1.12.2-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.12.2/server/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar", filename);
                    break;

                case "1.11.2-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.11.2/server/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar", filename);
                    break;

                case "1.10.2-Vanilla":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.11.2/server/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar", filename);
                    break;

                case "1.9.4":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.9.4/server/edbb7b1758af33d365bf835eb9d13de005b1e274/server.jar", filename);
                    break;

                case "1.8.8":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.8.8/server/5fafba3f58c40dc51b5c3ca72a98f62dfdae1db7/server.jar", filename);
                    break;

                case "1.7.10":
                    await FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.7.10/server/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar", filename);
                    break;
                #endregion
                #region Bukkit
                case "1.16.5-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.16.5.jar", filename);
                    break;

                case "1.15.2-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.15.2.jar", filename);
                    break;

                case "1.14.4-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.14.4-R0.1-SNAPSHOT.jar", filename);
                    break;

                case "1.13.2-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.13.2.jar", filename);
                    break;

                case "1.12.2-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.12.2.jar", filename);
                    break;

                case "1.11.2-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.11.2.jar", filename);
                    break;

                case "1.10.2-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.10.2-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.9.4-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.9.4-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.8.8-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.8.8-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.7.10-Bukkit":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.7.10-R0.1-20140808.005431-8.jar", filename);
                    break;
                #endregion
                #region Spigot
                case "1.16.5-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.16.5.jar", filename);
                    break;
                case "1.15.2-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.15.2.jar", filename);
                    break;

                case "1.14.4-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.14.4.jar", filename);
                    break;

                case "1.13.2-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar", filename);
                    break;

                case "1.12.2-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar", filename);    
                    break;

                case "1.11.2-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.11.2.jar", filename);
                    break;

                case "1.10.2-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.9.4-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.8.8-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar", filename);
                    break;
                case "1.7.10-Spigot":
                    await FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.7.10-SNAPSHOT-b1657.jar", filename);
                    break;
                #endregion
                #region Paper
                case "1.16.5-Paper":
                    await FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.16.5/builds/592/downloads/paper-1.16.5-592.jar", filename);
                    break;
                #endregion
                //case "":
                //    break;
                //case "":
                //    break;
                default:
                    UCLogsViewModel.TextLogs.Value += "\nВыбранного сочетания версия + ядро не существует";
                    break;
            }
        }
    }
}
