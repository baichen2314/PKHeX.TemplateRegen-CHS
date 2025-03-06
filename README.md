# PKHeX.TemplateRegen
根据配置的settings.json文件，为PKHeX重新生成合法性二进制文件。
使用说明：

1.拉取PKHeX、PoGoEncTool和EventsGallery项目。它们可以被克隆到同一个父文件夹中，也可以分别克隆到不同的父文件夹中。

2.构建PoGoEncTool生成可运行的PoGoEncTool.WinForms.exe文件。

3.将PoGoEncTool\Resources\data.json文件复制放到PoGoEncTool.WinForms.exe同一目录下。

4.修改ProgramSettings.cs内的路径，构建出PKHeX.TemplateRegen.exe文件并运行，以生成json配置文件。

5.再次运行PKHeX.TemplateRegen.exe应用程序。

6.应用程序将重新生成.pkl文件，并将它们复制到PKHeX对应的合法性路径中。

7.更新完成，可以去构建最新的PKHeX了
