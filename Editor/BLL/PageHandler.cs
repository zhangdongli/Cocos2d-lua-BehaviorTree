using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BehaviorTreeEditor_Components;

namespace BehaviorTreeEditor_BLL
{
    /// <summary>
    /// 修改页面到文件的处理类
    /// </summary>
    public class PageHandler
    {
        private static PageHandler instance = null;
        private static string cPath = null;

        public static PageHandler getInstance()
        {
            if (instance == null)
            {
                instance = new PageHandler();
            }

            return instance;
        }

        private PageHandler()
        {
            cPath = Application.StartupPath;
            string currentPath = (string)cPath.Clone();
            string path = currentPath;
            path += "\\Resource\\";
            if (!File.FolderIsExist(path)) 
            {
                File.FolderCreate(currentPath, "Resource"); 
            }
            currentPath += "\\Resource\\";

            path += "LastPage\\";
            if (!File.FolderIsExist(path))
            {
                File.FolderCreate(currentPath, "LastPage");
            }
            currentPath += "LastPage\\";

            path += "LastPage.txt";
            if (!File.FileIsExist(path)) 
            {
                string resString = "";
                File.WriteFile(path, resString);
            }

            System.IO.Directory.SetCurrentDirectory(cPath);
            currentPath += "LastPage.txt";
        }

        public string getLastPage()
        {
            string path = cPath + "\\Resource\\LastPage\\LastPage.txt";
            string res = File.ReadFile(path);
            return res;
        }

        public void setLastPage(string lastPage)
        {
            string path = cPath + "\\Resource\\LastPage\\LastPage.txt";
            File.WriteFile(path, lastPage);
        }
    }
}
