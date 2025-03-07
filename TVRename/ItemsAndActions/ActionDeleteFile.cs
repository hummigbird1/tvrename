// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at https://github.com/TV-Rename/tvrename
// 
// Copyright (c) TV Rename. This code is released under GPLv3 https://github.com/TV-Rename/tvrename/blob/master/LICENSE.md
// 

using System;
using Alphaleonis.Win32.Filesystem;
using JetBrains.Annotations;

namespace TVRename
{
    public class ActionDeleteFile : ActionDelete
    {
        private readonly FileInfo toRemove;

        public ActionDeleteFile(FileInfo remove, ProcessedEpisode? ep, TVSettings.TidySettings? tidyup)
        {
            Tidyup = tidyup;
            PercentDone = 0;
            Episode = ep;
            toRemove = remove;
        }
        public ActionDeleteFile(FileInfo remove, MovieConfiguration mov, TVSettings.TidySettings? tidyup)
        {
            Tidyup = tidyup;
            PercentDone = 0;
            Movie = mov;
            toRemove = remove;
        }
        public override string ProgressText => toRemove.Name;
        public override string Produces => toRemove.FullName;
        [NotNull]
        public override IgnoreItem Ignore => new IgnoreItem(toRemove.FullName);
        public override string TargetFolder => toRemove.DirectoryName;

        public override ActionOutcome Go(TVRenameStats stats)
        {
            try
            {
                if (toRemove.Exists)
                {
                    DeleteOrRecycleFile(toRemove);
                    if (Tidyup != null && Tidyup.DeleteEmpty)
                    {
                        LOGGER.Info($"Testing {toRemove.Directory.FullName } to see whether it should be tidied up");
                        DoTidyup(toRemove.Directory);
                    }
                }
            }
            catch (Exception e)
            {
                return new ActionOutcome(e);
            }
            return ActionOutcome.Success();
        }
       
        public override bool SameAs(Item o)
        {
            return o is ActionDeleteFile cmr && FileHelper.Same(toRemove , cmr.toRemove);
        }

        public override int CompareTo(object o)
        {
            if (!(o is ActionDeleteFile cmr) || toRemove.Directory is null || cmr.toRemove.Directory is null )
            {
                return -1;
            }

            return string.Compare(toRemove.FullName , cmr.toRemove.FullName , StringComparison.Ordinal);
        }

        public bool SameSource([NotNull] ActionDeleteFile o) => FileHelper.Same(toRemove , o.toRemove);
    }
}
