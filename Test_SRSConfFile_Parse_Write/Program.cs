using System;
using System.Security;
using SRSConfFile;
using SRSConfFile.SRSConfClass;

namespace Test_SRSConfFile_Parse_Write
{
    class Program
    {
        static void Main(string[] args)
        {
            /*打包发布成单一的可执行文件 手工在项目目录里运行：dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true  
            win-x64是目标平台，比如可以osx-x64,linux-x64等
            PublishSingleFile true发布成单一文件，PublishTrimmed true ,压缩   可防破解*/
            SrsConfigParse.LoadSrsConfObject("conf/full.conf"); //加载配置文件
            SrsConfigParse.Parse(); //分析配置文件 
            SrsConfigParse.Trim(); //配置去重
            SrsSystemConfClass srs = new SrsSystemConfClass(); //创建SRS配置实例
            SrsConfigParse.Render(SrsConfigParse.RootSection, srs); //写入SRS配置实例
            Console.WriteLine(SrsConfigBuild.Build(srs, "")); //重建配置文件，可输出文件
   
            Console.WriteLine("end!");
        }
    }
}