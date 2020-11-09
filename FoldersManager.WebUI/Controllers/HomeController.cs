using FoldersManager.Domain.Repositories;
using FoldersManager.Domain;
using FoldersManager.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FoldersManager.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private Ropisitiory pRepository;

        public const string ROOT = "root";
        public const int ROOT_FOLDER_ID = 0;
        public const int FIRST_FOLDER_D = 1;

        public HomeController()
        {
            pRepository = new Ropisitiory();
        }

        public ActionResult Index(string path, int id = ROOT_FOLDER_ID)
        {
            int folderId = (id == ROOT_FOLDER_ID) ? FIRST_FOLDER_D : id;

            Folder folder = pRepository.GetFolderById(folderId);

            FolderViewModel viewModel;

            if (id == ROOT_FOLDER_ID)
            {
                viewModel = GetRootViewModel(folder);
            }
            else
            {
                viewModel = FolderViewModel.FoldersPath(folder, path);
            }

            return View(viewModel);
        }

        private FolderViewModel GetRootViewModel(Folder rootFolder)
        {
            FolderViewModel rootFolderViewModel = FolderViewModel.FoldersPath(rootFolder, string.Empty);
            rootFolderViewModel.Path = rootFolderViewModel.Name;

            FolderViewModel rootViewModel = new FolderViewModel
            {
                Id = ROOT_FOLDER_ID,
                Name = ROOT,
                Folders = new List<FolderViewModel>()
                {
                    rootFolderViewModel
                }
            };

            return rootViewModel;
        }
    }
}