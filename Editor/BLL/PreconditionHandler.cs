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
    /// <summary>
    /// 条件到文件的处理类
    /// </summary>
    public class PreconditionHandler
    {
        private static PreconditionHandler instance = null;
        private static string cPath = null;

        public static PreconditionHandler getInstance()
        {
            if (instance == null)
            {
                instance = new PreconditionHandler();
            }

            return instance;
        }

        private PreconditionHandler()
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

            path += "BasePrecondition\\";
            if (!File.FolderIsExist(path))
            {
                File.FolderCreate(currentPath, "BasePrecondition");                
            }
            currentPath += "BasePrecondition\\";

            path += "BasePrecondition.json";
            if (!File.FileIsExist(path)) 
            {
                List<Precondition> res = new List<Precondition>();
                string resString = JsonConvert.SerializeObject(res);
                File.WriteFile(path, resString);  
            }
            System.IO.Directory.SetCurrentDirectory(cPath);
            currentPath += "BasePrecondition.json";
        }

        public List<Precondition> getBasePreconditions()
        {
            string path = cPath + "\\Resource\\BasePrecondition\\BasePrecondition.json";
            string json = File.ReadFile(path);
            List<Precondition> res = (List<Precondition>)JsonConvert.DeserializeObject(json,typeof(List<Precondition>));
            return res;
        }

        public void setBasePreconditions(List<Precondition> basePreconditions)
        {
            string path = cPath + "\\Resource\\BasePrecondition\\BasePrecondition.json";
            string json = JsonConvert.SerializeObject(basePreconditions);
            File.WriteFile(path, json);
        }
    }
}
