using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using PKHeX.TemplateRegen;

Console.WriteLine("Hello, World!");

// Attach Console to NLog's logger - Info
// Only log the message
var config = new NLog.Config.LoggingConfiguration();
var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
NLog.LogManager.Configuration = config;

if (RunUpdate(Assembly.GetEntryAssembly()!.Location))
    Console.WriteLine("完成!");

Console.ReadKey();
return;

bool RunUpdate(string localPath)
{
    var localDir = Path.GetDirectoryName(localPath) ?? string.Empty;

    const string jsonName = "settings.json";
    // Grab the settings from the executable's path
    // If the settings file does not exist, create it with default values
    // If the settings file exists, read it and use the values

    var settingsPath = Path.Combine(localDir, jsonName);
    if (!File.Exists(settingsPath))
    {
        LogUtil.Log($"未找到{jsonName}。正在创建默认文件。");
        WriteDefaultSettings(settingsPath);
        return false;
    }
    var text = File.ReadAllText(settingsPath, Encoding.UTF8);
    if (JsonConvert.DeserializeObject<ProgramSettings>(text) is not ProgramSettings settings)
    {
        LogUtil.Log($"{jsonName}无效。正在用默认文件覆盖。");
        WriteDefaultSettings(settingsPath);
        return false;
    }

    if (!Directory.Exists(settings.PathPKHeX))
    {
        LogUtil.Log("资源路径未找到");
        return false;
    }

    var mgdb = new MGDBPickler(settings.PathPKHeX, settings.PathRepoEvGal);
    mgdb.Update();

    var pget = new PGETPickler(settings.PathPKHeX, settings.PathRepoPGET);
    pget.Update();
    return true;
}

static void WriteDefaultSettings(string path)
{
    var result = new ProgramSettings();
    var json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    });
    File.WriteAllText(path, json, Encoding.UTF8);
}
