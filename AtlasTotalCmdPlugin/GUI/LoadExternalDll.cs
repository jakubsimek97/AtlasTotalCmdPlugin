
using NetTopologySuite.Planargraph;
using System.Reflection;
using TCPoints.AllInterfaces;
using TCPoints.Exports;
using TCPoints.Imports;
using TCPoints.Operations;

namespace TCPoints.GUI
{
    public partial class LoadExternalDll : BaseDialog
    {
        public LoadExternalDll()
        {
            InitializeComponent();
        }

        private void getPathDll_Click(object sender, EventArgs e)
        {
            string file = SelectFile.FromWindows("Choose external library", "DLL file", "dll");

            if (file == string.Empty)
                return;

            List<IExport> newExports = LoadInterfacesFromAssebly<IExport>.Get(Assembly.LoadFrom(file));
            List<IReadCoords> newImports = LoadInterfacesFromAssebly<IReadCoords>.Get(Assembly.LoadFrom(file));
            List<IOperation> newOperations = LoadInterfacesFromAssebly<IOperation>.Get(Assembly.LoadFrom(file));

            TreeNode imports = new TreeNode("Imports");
            TreeNode operations = new TreeNode("Operations");
            TreeNode exports = new TreeNode("Exports");

            foreach (IReadCoords import in newImports)
            {
                TreeNode childNode = new TreeNode(import.GetExt());
                imports.Nodes.Add(childNode);
            }

            foreach (IOperation operation in newOperations)
            {
                TreeNode childNode = new TreeNode(operation.GetNameOperation());
                operations.Nodes.Add(childNode);
            }

            foreach (IExport export in newExports)
            {
                TreeNode childNode = new TreeNode(export.GetExportName());
                exports.Nodes.Add(childNode);
            }

            dllTypes.Nodes.Add(imports);
            dllTypes.Nodes.Add(operations);
            dllTypes.Nodes.Add(exports);
        }
    }
}
