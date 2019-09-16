﻿using ifsc.tcc.Portal.Domain.CommonModule;
using ifsc.tcc.Portal.Domain.TermPaperModule;

namespace ifsc.tcc.Portal.Domain.GroupModule
{
    public class GroupFile : Entity
    {
        public string FileName { get; private set; }
        public string FileData { get; private set; }
        public int GroupID { get; private set; }
        public int TermPaperID { get; private set; }

        public virtual Group Group { get; private set; }
        public virtual TermPaper TermPaper { get; private set; }

        private GroupFile()
        { }

        public GroupFile(
            string fileName,
            string fileData,
            Group group,
            TermPaper termPaper)
        {
            FileName = fileName;
            FileData = fileData;
            Group = group;
            TermPaper = termPaper;
        }
    }
}
