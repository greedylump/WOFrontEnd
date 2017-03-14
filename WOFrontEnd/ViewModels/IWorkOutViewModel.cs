using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOFrontEnd.Services;

namespace WOFrontEnd.ViewModels
{
    public interface IWorkOutViewModel
    {
         WorkOutDataService GetDataService();
    }
}
