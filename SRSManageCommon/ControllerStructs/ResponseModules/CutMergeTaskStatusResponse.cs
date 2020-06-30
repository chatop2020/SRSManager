using System;
using System.Collections.Generic;
using SRSManageCommon.ManageStructs;

namespace SRSManageCommon.ControllerStructs.ResponseModules
{
    [Serializable]
    public class CutMergeTaskStatusResponse
    {
      
        private string? _taskId;
        private string? _callbakUrl;
        private DateTime _createTime;
        private TaskStatus? _taskStatus;
        private string? _uri;
        private long? _fileSize;
        private long? _duration;
        private double? _timeConsuming;
        /// <summary>
        /// Create=0%
        /// Packageing=45%
        /// Cutting=15%
        /// Mergeing=40%
        /// </summary>
        private double? _processPercentage=0f;

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

        public double? ProcessPercentage
        {
            get => _processPercentage;
            set => _processPercentage = value;
        }

        public string? Uri
        {
            get => _uri;
            set => _uri = value;
        }

        public long? FileSize
        {
            get => _fileSize;
            set => _fileSize = value;
        }

        public long? Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public double? TimeConsuming
        {
            get => _timeConsuming;
            set => _timeConsuming = value;
        }
    }
}