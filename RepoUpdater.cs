using LibGit2Sharp;

namespace PKHeX.TemplateRegen;

public static class RepoUpdater
{
    public static bool UpdateRepo(string repo, string path, string branch)
    {
        try
        {
            if (!Repository.IsValid(path))
                throw new OperationCanceledException($"无效的{repo}路径。");

            LogUtil.Log($"正在更新repo：{repo}");
            using var localRepo = new Repository(path);
            var remote = localRepo.Network.Remotes["origin"];
            var fetchOptions = new FetchOptions();

            const string msg = "正在获取最新更改...";
            LogUtil.Log(msg);
            Commands.Fetch(localRepo, remote.Name, remote.FetchRefSpecs.Select(x => x.Specification), fetchOptions, msg);
            var branches = localRepo.Branches;
            var remoteBranch = branches[$"origin/{branch}"] ?? throw new OperationCanceledException($"""远程分支"{branch}"未找到。""");

            LogUtil.Log($"将本地分支重置为远程分支：{branch}");
            Commands.Checkout(localRepo, branches[branch]);
            localRepo.Reset(ResetMode.Hard, remoteBranch.Tip);
        }
        catch (Exception ex)
        {
            LogUtil.Log($"错误: {ex.Message}");
            return false;
        }

        LogUtil.Log($"已更新 repo: {repo}");
        return true;
    }
}
