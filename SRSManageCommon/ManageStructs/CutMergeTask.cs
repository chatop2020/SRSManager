using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]

    public enum TaskStatus
    {
        Create,
        Packaging,
        Cutting,
        Mergeing,
        Closed,
    }
    [Serializable]
    public class CutMergeTask
    {
        private List<CutMergeStruct>? _cutMergeFileList;
        private string? _taskId;
        private string? _callbakUrl;
        private DateTime _createTime;
        private TaskStatus? _taskStatus;
        
        public List<CutMergeStruct>? CutMergeFileList
        {
            get => _cutMergeFileList;
            set => _cutMergeFileList = value;
        }

        public string? TaskId
        {
            get => _taskId;
            set => _taskId = value;
        }

        public string? CallbakUrl
        {
            get => _callbakUrl;
            set => _callbakUrl = value;
        }

        public DateTime CreateTime
        {
            get => _createTime;
            set => _createTime = value;
        }

        public TaskStatus? TaskStatus
        {
            get => _taskStatus;
            set => _taskStatus = value;
        }
    }
}