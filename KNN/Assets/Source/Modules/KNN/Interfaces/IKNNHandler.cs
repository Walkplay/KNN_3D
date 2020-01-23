using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.KNN
{
    public interface IKNNHandler
    {
        List<Point> GetKNearest(Point point, int K);
        void Run();
    }
}
