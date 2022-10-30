using ServerCreation.ViewModels;
using ServerCreation.Views;

namespace ServerCreation.Engine
{
    public static class VersionsContoller
    {
        public static void VersionsManager(string verion, string build, string filename)
        {
            FileDowloader.DowloadServer($"https://papermc.io/api/v2/projects/paper/versions/{verion}/builds/{build}/downloads/paper-{verion}-{build}.jar", filename);
        }

        public static void VersionsManager(string verion, string filename)
        {

            switch (verion)
            {
                #region Vanilla
                case "1.16.5-Vanilla": 
                    FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/35139deedbd5182953cf1caa23835da59ca3d7cd/server.jar", filename);
                    break;

                case "1.15.2-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar", filename);
                    break;

                case "1.14.4-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar", filename);
                    break;

                case "1.13.2-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar", filename);
                    break;

                case "1.12.2-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.12.2/server/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar", filename);
                    break;

                case "1.11.2-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.11.2/server/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar", filename);
                    break;

                case "1.10.2-Vanilla":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.11.2/server/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar", filename);
                    break;

                case "1.9.4":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.9.4/server/edbb7b1758af33d365bf835eb9d13de005b1e274/server.jar", filename);
                    break;

                case "1.8.8":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.8.8/server/5fafba3f58c40dc51b5c3ca72a98f62dfdae1db7/server.jar", filename);
                    break;

                case "1.7.10":
                     FileDowloader.DowloadServer("https://launcher.mojang.com/mc/game/1.7.10/server/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar", filename);
                    break;
                #endregion
                #region Bukkit
                case "1.16.5-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.16.5.jar", filename);
                    break;

                case "1.15.2-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.15.2.jar", filename);
                    break;

                case "1.14.4-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.14.4-R0.1-SNAPSHOT.jar", filename);
                    break;

                case "1.13.2-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.13.2.jar", filename);
                    break;

                case "1.12.2-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.12.2.jar", filename);
                    break;

                case "1.11.2-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.11.2.jar", filename);
                    break;

                case "1.10.2-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.10.2-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.9.4-Bukkit":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.9.4-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.8.8-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.8.8-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.7.10-Bukkit":
                     FileDowloader.DowloadServer("https://cdn.getbukkit.org/craftbukkit/craftbukkit-1.7.10-R0.1-20140808.005431-8.jar", filename);
                    break;
                #endregion
                #region Spigot
                case "1.16.5-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.16.5.jar", filename);
                    break;
                case "1.15.2-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.15.2.jar", filename);
                    break;

                case "1.14.4-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.14.4.jar", filename);
                    break;

                case "1.13.2-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar", filename);
                    break;

                case "1.12.2-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar", filename);    
                    break;

                case "1.11.2-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.11.2.jar", filename);
                    break;

                case "1.10.2-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.9.4-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar", filename);
                    break;

                case "1.8.8-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar", filename);
                    break;
                case "1.7.10-Spigot":
                    FileDowloader.DowloadServer("https://cdn.getbukkit.org/spigot/spigot-1.7.10-SNAPSHOT-b1657.jar", filename);
                    break;
                #endregion
                #region Paper
                case "1.16.5-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.16.5/builds/592/downloads/paper-1.16.5-592.jar", filename);
                    break;

                case "1.15.2-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.15.2/builds/391/downloads/paper-1.15.2-391.jar", filename);
                    break;

                case "1.14.4-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.14.4/builds/243/downloads/paper-1.14.4-243.jar", filename);
                    break;

                case "1.13.2-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.13.2/builds/655/downloads/paper-1.13.2-655.jar", filename);
                    break;

                case "1.12.2-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.12.2/builds/1618/downloads/paper-1.12.2-1618.jar", filename);
                    break;

                case "1.11.2-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.11.2/builds/1104/downloads/paper-1.11.2-1104.jar", filename);
                    break;

                case "1.10.2-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.10.2/builds/916/downloads/paper-1.10.2-916.jar", filename);
                    break;

                case "1.9.4-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.9.4/builds/773/downloads/paper-1.9.4-773.jar", filename);
                    break;

                case "1.8.8-Paper":
                    FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.8.8/builds/443/downloads/paper-1.8.8-443.jar", filename);
                    break;
                #endregion
                default:
                    UCLogsViewModel.TextLogs.Value += "\nВыбранного сочетания версия + ядро не существует";
                    break;
            }
        }
    }
}
