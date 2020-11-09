using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoldersManager.Domain;

namespace FoldersManager.Domain.Repositories
{
    public class Ropisitiory
    {
        private FoldersStructureDatabaseEntities pContext;

        public Ropisitiory()
        {
            pContext = new FoldersStructureDatabaseEntities();
        }

        public Folder GetFolderById(int Id)
        {
            return pContext.Folders
                .Where(f => f.Id == Id)
                .Include(g => g.Folders1)
                .FirstOrDefault();
        }
    }
}