namespace PKHeX.TemplateRegen;

using System.Text.Json.Serialization;

[JsonSerializable(typeof(ProgramSettings))]
public sealed partial class ProgramSettingsContext : JsonSerializerContext;

public class ProgramSettings
{
    public string RepoFolder { get; set; } = @"D:\文档\GitHub\Resources";
    public string RepoPKHeXLegality { get; set; } = @"D:\文档\GitHub\PKHeX\PKHeX.Core\Resources\legality"; // where the legality files are stored

    public string RepoNameEvGal { get; set; } = @"D:\文档\GitHub\EventsGallery"; // relative if using RepoFolder
    public string RepoNamePGET { get; set; } = @"D:\文档\GitHub\PoGoEncTool"; // relative if using RepoFolder

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
