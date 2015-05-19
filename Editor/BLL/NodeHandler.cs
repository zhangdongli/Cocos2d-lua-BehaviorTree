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
    /// 节点到文件的处理类
    /// </summary>
    public class NodeHandler
    {
        private static NodeHandler instance = null;
        private static string cPath = null;

        public static NodeHandler getInstance()
        {
            if (instance == null)
            {
                instance = new NodeHandler();
            }

            return instance;
        }

        private NodeHandler()
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

            path += "BaseNode\\";
            if (!File.FolderIsExist(path))
            {
                File.FolderCreate(currentPath, "BaseNode");
            }
            currentPath += "BaseNode\\";

            path += "BaseNode.json";
            if (!File.FileIsExist(path)) 
            {
                List<Node> res = new List<Node>();
                string resString = JsonConvert.SerializeObject(res);
                File.WriteFile(path, resString); 
            }
            System.IO.Directory.SetCurrentDirectory(cPath);
            currentPath += "BaseNode.json";
        }

        public List<Node> getBaseNodes()
        {
            string path = cPath + "\\Resource\\BaseNode\\BaseNode.json";
            string json = File.ReadFile(path);
            List<Node> res = (List<Node>)JsonConvert.DeserializeObject(json,typeof(List<Node>));
            return res;
        }

        public void setBaseNodes(List<Node> baseNodes)
        {
            string path = cPath + "\\Resource\\BaseNode\\BaseNode.json";
            string json = JsonConvert.SerializeObject(baseNodes);
            File.WriteFile(path, json);
        }
    }
}
