namespace PKHeX.TemplateRegen;

using System.Text.Json.Serialization;

[JsonSerializable(typeof(ProgramSettings))]
public sealed partial class ProgramSettingsContext : JsonSerializerContext;

public class ProgramSettings
{
    public string RepoFolder { get; set; } = @"C:\Users\kapho\source\repos";// 目前来看没啥用
    public string RepoPKHeXLegality { get; set; } = @"PKHeX\PKHeX.Core\Resources\legality"; // 从Github上拉取的PKHeX相对路径

    public string RepoNameEvGal { get; set; } = @"EventsGallery"; // 从Github上拉取的EventsGallery相对路径
    public string RepoNamePGET { get; set; } = @"PoGoEncTool"; // 从Github上拉取的PoGoEncTool相对路径

	/*
	示范：
	public string RepoFolder { get; set; } = @"D:\GitHub\Resources";
    public string RepoPKHeXLegality { get; set; } = @"D:\GitHub\PKHeX\PKHeX.Core\Resources\legality";
    public string RepoNameEvGal { get; set; } = @"D:\GitHub\EventsGallery";
    public string RepoNamePGET { get; set; } = @"D:\GitHub\PoGoEncTool"; 
	*/
    // Logic to get full paths
    public string PathPKHeX => GetRepoPath(RepoPKHeXLegality);

    public string PathRepoEvGal => GetRepoPath(RepoNameEvGal);
    public string PathRepoPGET => GetRepoPath(RepoNamePGET);

    private string GetRepoPath(string repoName)
    {
        // if path is absolute, return it
        if (Path.IsPathRooted(repoName))
            return repoName;
        // if path is relative, combine it with the repo folder
        return Path.Combine(RepoFolder, repoName);
    }
}
