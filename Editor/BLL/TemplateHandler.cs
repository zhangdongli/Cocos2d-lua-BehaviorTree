using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

using BehaviorTreeEditor_Model;
using BehaviorTreeEditor_Components;

namespace BehaviorTreeEditor_BLL
{
    public class TemplateHandler
    {
        private static TemplateHandler instance = null;
        private static string cPath = null;

        public static TemplateHandler getInstance()
        {
            if (instance == null)
            {
                instance = new TemplateHandler();
            }

            return instance;
        }

        private TemplateHandler()
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

            path += "BaseTree\\";
            if (!File.FolderIsExist(path))
            {
                File.FolderCreate(currentPath, "BaseTree");
            }
            currentPath += "BaseTree\\";

            path += "BaseTree.json";
            if (!File.FileIsExist(path)) 
            {
                List<Tree> res = new List<Tree>();
                string resString = JsonConvert.SerializeObject(res);
                File.WriteFile(path, resString); 
            }
            System.IO.Directory.SetCurrentDirectory(cPath);
            currentPath += "BaseTree.json";
        }

        public List<Tree> getBaseTrees()
        {
            string path = cPath + "\\Resource\\BaseTree\\BaseTree.json";
            string json = File.ReadFile(path);
            List<Tree> res = (List<Tree>)JsonConvert.DeserializeObject(json, typeof(List<Tree>));
            return res;
        }

        public void setBaseTrees(List<Tree> baseTrees)
        {
            string path = cPath + "\\Resource\\BaseTree\\BaseTree.json";
            string json = JsonConvert.SerializeObject(baseTrees);
            File.WriteFile(path, json);
        }
    }
}
