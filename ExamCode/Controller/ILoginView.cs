using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCode
{
    public interface ILoginView
    {
        void SetController(LoginController controller);
        void ClearValue();
    }
}
