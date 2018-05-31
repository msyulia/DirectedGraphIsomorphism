using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGI.Model
{
    public class VerticeModel
    {
        int name;
        int inputEdgesCount;
        int outputEdgesCount;

        public VerticeModel(int name, int inputEdges, int outputEdges)
        {
            this.name = name;
            this.inputEdgesCount = inputEdges;
            this.outputEdgesCount = outputEdges;
        }

        public static bool operator ==(VerticeModel v1, VerticeModel v2)
        {
            return v1.inputEdgesCount == v2.inputEdgesCount && v1.outputEdgesCount == v2.outputEdgesCount;
        }
        public static bool operator !=(VerticeModel v1, VerticeModel v2)
        {
            return !(v1 == v2);
        }
    }
}
