using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SrsManageCommon;
using SRSManageCommon.ManageStructs;
using SrsManageCommon.SrsManageCommon;
using TaskStatus = SRSManageCommon.ManageStructs.TaskStatus;

namespace SrsApis.SrsManager
{
    public static class CutMergeService
    {
        public static BlockingCollection<CutMergeTask> CutMergeTaskList = new BlockingCollection<CutMergeTask>(10);

        static CutMergeService()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var value in CutMergeTaskList.GetConsumingEnumerable())
                {
                    var taskReturn = CutMerge(value);
                    if (taskReturn != null)
                    {
                        taskReturn.Uri = ":"+Common.SystemConfig.HttpPort+
                                         taskReturn.FilePath!.Replace(Common.WorkPath + "CutMergeFile", "");
                        var postDate = JsonHelper.ToJson(taskReturn);
                        var ret = NetHelperNew.HttpPostRequest(taskReturn.Task.CallbakUrl!, null!, postDate);
                    }
                }
            });
        }

        /// <summary>
        /// 将mp4转为ts格式封装，这里可能需要捕获异常，超时30分钟
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private static CutMergeTask packageToTsStreamFile(CutMergeTask task)
        {
            task.TaskStatus = TaskStatus.Packaging;
            string tsPath = Common.WorkPath + "CutMergeDir/" + task.TaskId + "/ts";
            if (!Directory.Exists(tsPath))
            {
                Directory.CreateDirectory(tsPath);
            }

            for (int i = 0; i <= task.CutMergeFileList!.Count - 1; i++)
            {
                string videoFileNameWithOutExt = Path.GetFileNameWithoutExtension(task.CutMergeFileList[i]!.FilePath!);
                string videoTsFileName = videoFileNameWithOutExt + ".ts";
                string videoTsFilePath = tsPath + "/" + videoTsFileName;
                string ffmpegCmd =Common.FFmpegBinPath + " -i " + task.CutMergeFileList[i]!.FilePath! +
                                   " -vcodec copy -acodec copy -vbsf h264_mp4toannexb " + videoTsFilePath + " -y";
                var retRun = LinuxShell.Run(ffmpegCmd, 1000 * 60 * 30, out string std, out string err);

                if (retRun && (!string.IsNullOrEmpty(std) || !string.IsNullOrEmpty(err)) &&
                    File.Exists(videoTsFilePath))
                {
                    long find = -1;
                    if (!string.IsNullOrEmpty(std))
                    {
                        var str =Common.GetValue(std, "video:", "audio:");
                        if (!string.IsNullOrEmpty(str))
                        {
                            str = str.ToLower();
                            str = str.Replace("kb", "");
                            long.TryParse(str, out find);
                        }
                    }
                    else if (!string.IsNullOrEmpty(err))
                    {
                        var str = Common.GetValue(err, "video:", "audio:");
                        str = str.ToLower();
                        str = str.Replace("kb", "");
                        long.TryParse(str, out find);
                    }


                    if (find > 0)
                    {
                        task.CutMergeFileList[i].FilePath = videoTsFilePath;
                        LogWriter.WriteLog("合并请求转换TS任务成功(packageToTsStreamFile)...",
                            task.TaskId! + "->" + videoTsFilePath);
                    }
                    else
                    {
                        LogWriter.WriteLog("合并请求转换TS任务失败(packageToTsStreamFile)...",
                            task.TaskId! + "->" + videoTsFilePath + " ***\r\n" + err, ConsoleColor.Yellow);
                    }
                }

                Thread.Sleep(20);
            }

            return task;
        }

        /// <summary>
        /// 生成合并文件，并合并ts文件，同时输出mp4文件， -movflags faststart 标记是可让mp4在web上快速加载播放，超时30分钟
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private static string mergeProcess(CutMergeTask task)
        {
            task.TaskStatus = TaskStatus.Mergeing;
            string mergePath = Common.WorkPath + "CutMergeDir/" + task.TaskId;
            string outPutPath = Common.WorkPath + "CutMergeFile/" +
                                DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (!Directory.Exists(outPutPath))
            {
                Directory.CreateDirectory(outPutPath);
            }
            List<string> mergeStringList = new List<string>();
            for (int i = 0; i <= task.CutMergeFileList!.Count - 1; i++)
            {
                mergeStringList.Add("file '" + task.CutMergeFileList[i].FilePath + "'");
            }

            File.WriteAllLines(mergePath + "files.txt", mergeStringList);
            string newFilePath = outPutPath+ "/" + task.TaskId + "_"+DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")+".mp4";
            string ffmpegCmd = Common.FFmpegBinPath + " -threads "+Common.FFmpegThreadCount.ToString()+" -f concat -safe 0 -i " + mergePath +
                               "files.txt" + " -c copy  -movflags faststart " + newFilePath;
            var retRun = LinuxShell.Run(ffmpegCmd, 1000 * 60 * 30, out string std, out string err);
            if (retRun && (!string.IsNullOrEmpty(std) || !string.IsNullOrEmpty(err)) &&
                File.Exists(newFilePath))
            {
                long find = -1;
                if (!string.IsNullOrEmpty(std))
                {
                    var str = Common.GetValue(std, "video:", "audio:");
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str.ToLower();
                        str = str.Replace("kb", "");
                        long.TryParse(str, out find);
                    }
                }
                else if (!string.IsNullOrEmpty(err))
                {
                    var str = Common.GetValue(err, "video:", "audio:");
                    str = str.ToLower();
                    str = str.Replace("kb", "");
                    long.TryParse(str, out find);
                }

                if (find > 0)
                {
                    LogWriter.WriteLog("合并请求任务成功(mergeProcess)...", task.TaskId! + "->" + newFilePath);
                    return newFilePath;
                }
            }

            LogWriter.WriteLog("合并请求任务失败(mergeProcess失败)...", task.TaskId! + "\r\n" + err, ConsoleColor.Yellow);
            return null!;
        }

        /// <summary>
        /// 对需要裁剪的视频进行裁剪，超时30分钟
        /// </summary>
        /// <param name="cms"></param>
        /// <returns></returns>
        private static CutMergeStruct cutProcess(CutMergeStruct cms)
        {
            string tsPath = Path.GetDirectoryName(cms.FilePath!)!;
            string fileName = Path.GetFileName(cms.FilePath!)!;
            string newTsName = tsPath + "/cut_" + fileName;


            string ffmpegCmd = Common.FFmpegBinPath + " -i " + cms.FilePath +
                               " -vcodec copy -acodec copy -ss " + cms.CutStartPos + " -to " + cms.CutEndPos + " " +
                               newTsName + " -y";
            var retRun = LinuxShell.Run(ffmpegCmd, 1000 * 60 * 30, out string std, out string err);
            if (retRun && (!string.IsNullOrEmpty(std) || !string.IsNullOrEmpty(err)) &&
                File.Exists(newTsName))
            {
                long find = -1;
                if (!string.IsNullOrEmpty(std))
                {
                    var str = Common.GetValue(std, "video:", "audio:");
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str.ToLower();
                        str = str.Replace("kb", "");
                        long.TryParse(str, out find);
                    }
                }
                else if (!string.IsNullOrEmpty(err))
                {
                    var str = Common.GetValue(err, "video:", "audio:");
                    str = str.ToLower();
                    str = str.Replace("kb", "");
                    long.TryParse(str, out find);
                }

                if (find > 0)
                {
                    LogWriter.WriteLog("合并请求任务裁剪成功(cutProcess)...", newTsName);
                    cms.FilePath = newTsName;
                }
                else
                {
                    LogWriter.WriteLog("合并请求任务裁剪失败(cutProcess)...", ffmpegCmd + "\r\n" + err, ConsoleColor.Yellow);
                }
            }

            return cms;
        }

        /// <summary>
        /// 对文件进行操作
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static CutMergeTaskResponse CutMerge(CutMergeTask task)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            LogWriter.WriteLog("合并请求任务开始(CutMerge)...", task.TaskId!);
            string taskPath = "";
            if (task != null && task.CutMergeFileList != null && task.CutMergeFileList.Count > 0)
            {
                taskPath = Common.WorkPath + "CutMergeDir/" + task.TaskId;
                if (!Directory.Exists(taskPath))
                {
                    Directory.CreateDirectory(taskPath);
                }

                try
                {
                    task = packageToTsStreamFile(task); //转ts文件
                    task.TaskStatus = TaskStatus.Cutting;
                    for (int i = 0; i <= task.CutMergeFileList!.Count - 1; i++)
                    {
                        if (task.CutMergeFileList[i].CutStartPos != null && task.CutMergeFileList[i].CutEndPos != null)
                        {
                            //做剪切
                            task.CutMergeFileList[i] = cutProcess(task.CutMergeFileList[i]);
                            Thread.Sleep(20);
                        }
                    }

                    string filePath = mergeProcess(task);
                    task.TaskStatus = TaskStatus.Closed;
                    stopwatch.Stop(); //  停止监视
                    TimeSpan timespan = stopwatch.Elapsed;
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        long duration = -1;
                        FFmpegGetDuration.GetDuration(Common.FFmpegBinPath, filePath, out duration);
                        return new CutMergeTaskResponse
                        {
                            FilePath = filePath,
                            FileSize = new FileInfo(filePath).Length,
                            Duration = duration,
                            Status = CutMergeRequestStatus.Succeed,
                            Task = task,
                            TimeConsuming = timespan.TotalMilliseconds,
                        };
                    }

                    return new CutMergeTaskResponse
                    {
                        FilePath = "",
                        Status = CutMergeRequestStatus.Failed,
                        FileSize = -1,
                        Duration = -1,
                        Task = task,
                        TimeConsuming = timespan.TotalMilliseconds,
                    };
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog("裁剪合并视频文件时出现异常...", ex.Message + "\r\n" + ex.StackTrace, ConsoleColor.Yellow);
                    return null!;
                }
                finally
                {
                    if (!string.IsNullOrEmpty(taskPath) && Directory.Exists(taskPath)) //清理战场
                    {
                        Directory.Delete(taskPath, true);
                    }

                    if (File.Exists(Common.WorkPath + "CutMergeDir/" + task!.TaskId + "files.txt")
                    ) //清理战场
                    {
                        File.Delete(Common.WorkPath + "CutMergeDir/" + task!.TaskId + "files.txt");
                    }
                }
            }


            return null!;
        }
    }
}