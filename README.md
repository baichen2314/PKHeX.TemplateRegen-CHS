# PKHeX.TemplateRegen
根据配置的settings.json文件，为PKHeX重新生成合法性二进制文件。

使用说明：

1.克隆PKHeX、PoGoEncTool和EventsGallery仓库。它们可以被克隆到同一个父文件夹中，也可以分别克隆到不同的父文件夹中。
2.运行可执行文件一次，以生成json配置文件。
3.编辑json文件，使其指向您的仓库文件夹。如果它们位于同一个父文件夹中，您可以使用相对路径，并仅更改RepoFolder属性。
4.运行该应用程序。
5.应用程序将重新生成.pkl文件，并将它们复制到PKHeX对应的合法性路径中。
